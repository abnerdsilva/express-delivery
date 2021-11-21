using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ExpressDelivery.Controllers;
using ExpressDelivery.Models;

namespace ExpressDelivery
{
    public partial class FormPedido : Form
    {
        public FormPedido()
        {
            InitializeComponent();
        }

        private readonly ClientController _clientController = new ClientController();
        private readonly ProdutoController _produtoController = new ProdutoController();
        private readonly PedidoController _pedidoController = new PedidoController();

        private Client _clientSelected = new Client();
        private Product _productSelected = new Product();
        private List<Product> _products = new List<Product>();
        private List<PedidoItem> _pedidoItens = new List<PedidoItem>();
        private double _vrTotalPedido;

        private void FormPedido_Load(object sender, EventArgs e)
        {
            ClearClient();
            ClearOrder();
        }

        private void ClearClient()
        {
            panelOrder.Enabled = false;

            txtIdCliente.Text = "0";
            txtNome.Text = "";
            txtDDD.Text = "19";
            txtTelefone.Text = "";
            txtCEP.Text = "";
            txtNumero.Text = "";
            txtEndereco.Text = "";
            cmbBairro.Text = "";
            txtObservacaoCliente.Text = "";
            txtTaxaEntrega.Text = "0.00";

            _clientSelected = null;
            txtTelefone.Focus();
        }

        private void ClearOrder()
        {
            panelClient.Enabled = true;

            txtQtde.Text = "1";
            txtQtde.Enabled = false;
            txtCodBarras.Text = "";
            txtValorUnit.Text = "0.00";
            txtObservacaoProduto.Text = "";
            txtObservacaoProduto.Enabled = false;
            txtVrTotalItens.Text = "0.00";
            txtVrTroco.Text = "0.00";
            txtVrTaxaEntrega.Text = "0.00";
            txtVrTotalPedido.Text = "0.00";
            txtVrTrocoPara.Text = "";
            txtVrTrocoPara.Enabled = false;
            cmbDescricaoProduto.Text = "";
            cmbFormaPagamento.Text = "";
            listProdutos.Clear();
            _products.Clear();
            _productSelected = null;
            _pedidoItens.Clear();
            _clientSelected = null;
            _vrTotalPedido = 0.0;
            lblNrPedido.Text = "0";

            txtTelefone.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearClient();
            ClearOrder();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDataHora.Text = $@"{DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        private void txtDDD_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char) Keys.Enter:
                    txtTelefone.Focus();
                    break;
                case (char) Keys.Back:
                case (char) Keys.Delete:
                    break;
                default:
                    if (!char.IsNumber(e.KeyChar))
                    {
                        MessageBox.Show(@"Informe apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Handled = true;
                    }

                    break;
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char) Keys.Back:
                case (char) Keys.Delete:
                    break;
                case (char) Keys.Enter:
                    LoadClientByPhone();
                    break;
                default:
                    if (!char.IsNumber(e.KeyChar))
                    {
                        MessageBox.Show(@"Informe apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Handled = true;
                    }

                    break;
            }
        }

        private void LoadClientByPhone()
        {
            _clientSelected = _clientController.LoadByPhone(txtTelefone.Text);
            if (_clientSelected != null)
            {
                txtIdCliente.Text = _clientSelected.Id.ToString();
                txtNome.Text = _clientSelected.Nome;
                txtEndereco.Text = _clientSelected.Endereco;
                cmbBairro.Text = _clientSelected.Bairro;
                txtObservacaoCliente.Text = _clientSelected.Observacao;
                txtCEP.Text = _clientSelected.CEP;
                txtNumero.Text = _clientSelected.Numero.ToString();
            }

            txtNome.Focus();
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) txtCEP.Focus();
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char) Keys.Enter:
                    txtNumero.Focus();
                    break;
                case (char) Keys.Back:
                case (char) Keys.Delete:
                    break;
                default:
                    if (!char.IsNumber(e.KeyChar))
                    {
                        MessageBox.Show(@"Informe apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Handled = true;
                    }

                    break;
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char) Keys.Enter:
                    txtEndereco.Focus();
                    break;
                case (char) Keys.Back:
                case (char) Keys.Delete:
                    break;
                default:
                    if (!char.IsNumber(e.KeyChar))
                    {
                        MessageBox.Show(@"Informe apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Handled = true;
                    }

                    break;
            }
        }

        private void txtEndereco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) cmbBairro.Focus();
        }

        private void cmbBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) txtObservacaoCliente.Focus();
        }

        private void txtObservacaoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) btnSalvarCliente.Focus();
        }

        private void btnSalvarCliente_Click(object sender, EventArgs e)
        {
            if (!VerificaCamposObrigatorios()) return;

            var clientId = 0;
            var city = "";
            var state = "";
            var email = "";
            var cpf = "";
            var rg = "";
            var status = 1;

            if (_clientSelected != null)
            {
                clientId = _clientSelected.Id;
                city = _clientSelected.Cidade;
                state = _clientSelected.Estado;
                email = _clientSelected.Email;
                cpf = _clientSelected.CPF;
                rg = _clientSelected.RG;
                status = _clientSelected.Status;
            }

            var client = new Client
            {
                Id = clientId,
                Nome = txtNome.Text,
                Telefone = txtTelefone.Text,
                Endereco = txtEndereco.Text,
                Numero = Convert.ToInt16(txtNumero.Text),
                Bairro = cmbBairro.Text,
                Cidade = city,
                Estado = state,
                CEP = txtCEP.Text,
                Email = email,
                Status = status,
                CPF = cpf,
                RG = rg,
                Observacao = txtObservacaoCliente.Text
            };

            _clientController.Save(client, client.Id == 0 ? "new" : "edit");
            if (!_clientController.MessageError.Equals(""))
            {
                MessageBox.Show(_clientController.MessageError, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _products = _produtoController.LoadAll();
            _products.ForEach(product => cmbDescricaoProduto.Items.Add(product.Descricao));

            InicializaPedido();

            panelClient.Enabled = false;
            panelOrder.Enabled = true;

            txtCodBarras.Focus();
        }

        private void InicializaPedido()
        {
            txtQtde.Text = "1";
            txtVrTotalItens.Text = "0.00";
            txtVrTotalPedido.Text = "0.00";
            txtVrTroco.Text = "0.00";
            txtVrTaxaEntrega.Text = "0.00";
            txtVrTrocoPara.Text = "0";
            txtValorUnit.Text = "0.00";

            listProdutos.Clear();

            listProdutos.View = View.Details;
            listProdutos.FullRowSelect = true;
            listProdutos.GridLines = true;
            listProdutos.LabelEdit = true;

            listProdutos.Columns.Add("ID", 70, HorizontalAlignment.Center);
            listProdutos.Columns.Add("Descrição", 230, HorizontalAlignment.Left);
            listProdutos.Columns.Add("Unidade", 50, HorizontalAlignment.Center);
            listProdutos.Columns.Add("Qtde", 50, HorizontalAlignment.Center);
            listProdutos.Columns.Add("VrUnitario", 60, HorizontalAlignment.Right);
            listProdutos.Columns.Add("VrTotal", 60, HorizontalAlignment.Right);
        }

        private bool VerificaCamposObrigatorios()
        {
            if (txtDDD.Text.Equals(""))
            {
                MessageBox.Show(@"Campo DDD é obrigatório", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtTelefone.Text.Equals(""))
            {
                MessageBox.Show(@"Campo Telefone é obrigatório", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtNome.Text.Equals(""))
            {
                MessageBox.Show(@"Campo Nome é obrigatório", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtNumero.Text.Equals(""))
            {
                MessageBox.Show(@"Campo Número é obrigatório", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtEndereco.Text.Equals(""))
            {
                MessageBox.Show(@"Campo Endereço é obrigatório", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbBairro.Text.Equals(""))
            {
                MessageBox.Show(@"Campo Bairro é obrigatório", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnCancelarCliente_Click(object sender, EventArgs e)
        {
            ClearClient();
        }

        private void txtCodBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char) Keys.Back:
                case (char) Keys.Delete:
                    break;
                case (char) Keys.Enter:
                    if (txtCodBarras.Text.Equals(""))
                    {
                        cmbDescricaoProduto.Focus();
                        cmbDescricaoProduto.DroppedDown = true;
                    }
                    else
                    {
                        var prod = _products.Find(product => product.CodBarras.Equals(txtCodBarras.Text));
                        if (prod == null)
                        {
                            MessageBox.Show(@"Produto não encontrado.", "Erro", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }

                        cmbDescricaoProduto.Text = prod.Descricao;
                        PreencheCamposProdutoSelecionado(cmbDescricaoProduto.Text);

                        txtQtde.Enabled = true;
                        txtObservacaoProduto.Enabled = true;
                        txtObservacaoProduto.Focus();
                    }

                    break;
                default:
                    if (!char.IsNumber(e.KeyChar))
                    {
                        MessageBox.Show(@"Informe apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void PreencheCamposProdutoSelecionado(string produto)
        {
            _productSelected = _products.Find(product => product.Descricao.Contains(produto));

            if (_productSelected == null) return;
            txtCodBarras.Text = _productSelected.CodBarras;
            txtValorUnit.Text = _productSelected.PrecoVenda.ToString("0.00");
        }

        private void cmbDescricaoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) Keys.Enter) return;
            if (cmbDescricaoProduto.Text.Equals(""))
            {
                txtQtde.Enabled = false;
                txtObservacaoProduto.Enabled = false;
                txtCodBarras.Focus();
                return;
            }

            PreencheCamposProdutoSelecionado(cmbDescricaoProduto.Text);

            txtQtde.Enabled = true;
            txtObservacaoProduto.Enabled = true;
            txtObservacaoProduto.Focus();
        }

        private void txtObservacaoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) txtQtde.Focus();
        }

        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char) Keys.Enter:
                case (char) Keys.Back:
                case (char) Keys.Delete:
                    e.Handled = true;
                    break;
                default:
                    if (!char.IsNumber(e.KeyChar))
                    {
                        MessageBox.Show(@"Informe apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Handled = true;
                    }

                    return;
            }

            if (txtQtde.Text.Equals(""))
            {
                MessageBox.Show(@"Informe uma quantidade válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var lastOrderId = _pedidoController.LoadLastOrderId();

            var qtde = Convert.ToInt16(txtQtde.Text);
            var vrTotalItem = _productSelected.PrecoVenda * qtde;

            ListViewItem items = new ListViewItem(_productSelected.Id.ToString());
            // items.SubItems.Add(_productSelected.Id.ToString());
            items.SubItems.Add(_productSelected.Descricao);
            items.SubItems.Add(_productSelected.UnMedida);
            items.SubItems.Add(qtde.ToString());
            items.SubItems.Add(_productSelected.PrecoVenda.ToString("0.00"));
            items.SubItems.Add(vrTotalItem.ToString("0.00"));

            var item = new PedidoItem
            {
                CodProduto = _productSelected.Id,
                VrUnitario = _productSelected.PrecoVenda,
                Quantidade = qtde,
                Observacao = txtObservacaoProduto.Text,
                VrTotal = vrTotalItem,
                CodPedido = lastOrderId + 1,
            };

            _pedidoItens.Add(item);

            listProdutos.Items.Add(items);

            var vrTotalSemTaxa = 0.00;
            var vrTotalTaxa = 3.00;
            _pedidoItens.ForEach(i => vrTotalSemTaxa += i.VrTotal);
            _vrTotalPedido = vrTotalSemTaxa + vrTotalTaxa;

            txtVrTotalItens.Text = vrTotalSemTaxa.ToString("0.00");
            txtVrTaxaEntrega.Text = vrTotalTaxa.ToString("0.00");
            txtVrTotalPedido.Text = _vrTotalPedido.ToString("0.00");

            txtVrTrocoPara.Enabled = true;
            txtQtde.Enabled = false;
            txtObservacaoProduto.Enabled = false;
            txtCodBarras.Focus();
            LimpaCamposProdutoLancado();
        }

        private void LimpaCamposProdutoLancado()
        {
            txtQtde.Text = "1";
            txtCodBarras.Text = "";
            txtValorUnit.Text = "";
            txtObservacaoProduto.Text = "";
            cmbDescricaoProduto.Text = "";
            _productSelected = null;
        }

        private void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            if (_pedidoItens.Count.Equals(0))
            {
                MessageBox.Show(@"Pedido não consta nenhum item lançado");
                return;
            }

            if (cmbFormaPagamento.Text.Equals(""))
            {
                MessageBox.Show(@"Selecione uma forma de pagamento");
                return;
            }

            if (_clientSelected.Id.Equals(0))
            {
                MessageBox.Show(@"Pedido não possui nenhum cliente vinculado");
                return;
            }

            var vrTotal = 0.00;
            _pedidoItens.ForEach(item => vrTotal += item.VrTotal);

            var orderId = Convert.ToInt16(lblNrPedido.Text);
            var vrTroco = Convert.ToDouble(txtVrTroco.Text);

            var order = new Pedido
            {
                Id = orderId,
                Bairro = _clientSelected.Bairro,
                Cidade = _clientSelected.Cidade,
                Estado = _clientSelected.Estado,
                Logradouro = _clientSelected.Endereco,
                Numero = _clientSelected.Numero,
                Observacao = _clientSelected.Observacao,
                Origem = "LOCAL",
                CodCliente = _clientSelected.Id,
                DataEntrega = DateTime.Now,
                DataPedido = DateTime.Now,
                StatusPedido = "ABERTO",
                TipoPedido = "ENTREGA",
                VrTotal = vrTotal,
                VrTroco = vrTroco,
                Itens = _pedidoItens
            };

            var resp = _pedidoController.SaveOrder(order, orderId == 0 ? "new" : "edit");
            if (!_pedidoController.MessageError.Equals(""))
                MessageBox.Show(_pedidoController.MessageError, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (resp == -1)
                MessageBox.Show(@"Erro ao lançar pedido", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (resp > 0)
            {
                lblNrPedido.Text = resp.ToString();
                MessageBox.Show($@"Pedido {resp} lançado com sucesso", @"Sucesso", MessageBoxButtons.OK,
                    MessageBoxIcon.None);
                LimpaTelaPedidoConcluido();
            }
        }

        private void LimpaTelaPedidoConcluido()
        {
            LimpaCamposProdutoLancado();
            ClearClient();
            ClearOrder();
        }

        private void txtVrTrocoPara_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                txtVrTroco.Text = (Convert.ToDouble(txtVrTrocoPara.Text) - _vrTotalPedido).ToString("0.00");
                cmbFormaPagamento.Focus();
            }
        }
    }
}