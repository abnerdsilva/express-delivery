using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ExpressDelivery.Controllers;
using ExpressDelivery.Models;

namespace ExpressDelivery
{
    public partial class FormPedido : Form
    {
        public static Usuario User { get; set; }

        public FormPedido()
        {
            InitializeComponent();
        }

        private readonly ClientController _clientController = new ClientController();
        private readonly ProdutoController _produtoController = new ProdutoController();
        private readonly PedidoController _pedidoController = new PedidoController();
        private readonly BairroController _bairroController = new BairroController();

        private Client _clientSelected = new Client();
        private Product _productSelected = new Product();
        private List<Product> _products = new List<Product>();
        private List<PedidoItem> _pedidoItens = new List<PedidoItem>();
        private List<PedidoItem> _pedidoItensNew = new List<PedidoItem>();
        private List<Bairro> _bairros = new List<Bairro>();
        private double _vrTotalPedido;
        private Pedido _orderSelected;

        private void FormPedido_Load(object sender, EventArgs e)
        {
            ClearClient();
            ClearOrder();

            lbl_notificaPedidoAberto.Text = "";
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

            cmbBairro.Items.Clear();
            foreach (var bairro in _bairros)
            {
                cmbBairro.Items.Add(bairro.Nome);
            }

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
            _pedidoItensNew.Clear();
            _clientSelected = null;
            _vrTotalPedido = 0.0;
            lblNrPedido.Text = "0";
            txtObservacaoPedido.Text = "";

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
                case (char)Keys.Enter:
                    txtTelefone.Focus();
                    break;
                case (char)Keys.Back:
                case (char)Keys.Delete:
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
                case (char)Keys.Back:
                case (char)Keys.Delete:
                    break;
                case (char)Keys.Enter:
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
            _clientSelected = _clientController.LoadByPhone(txtTelefone.Text.Replace("\r", "").Replace("\n", ""));
            if (_clientSelected != null && _clientSelected.Id != "")
            {
                txtIdCliente.Text = _clientSelected.Id;
                txtNome.Text = _clientSelected.Nome;
                txtEndereco.Text = _clientSelected.Endereco;
                cmbBairro.Text = _clientSelected.Bairro;
                txtObservacaoCliente.Text = _clientSelected.Observacao;
                txtCEP.Text = _clientSelected.CEP;
                txtNumero.Text = _clientSelected.Numero.ToString();

                foreach (var bairro in _bairros)
                {
                    if (bairro.Nome == _clientSelected.Bairro)
                    {
                        txtTaxaEntrega.Text = bairro.VrTaxa.ToString("0.00");
                        break;
                    }
                }

                if (txtTaxaEntrega.Text.Equals("0") || txtTaxaEntrega.Text.Equals("0.00"))
                {
                    txtTaxaEntrega.Enabled = true;
                }
            }

            txtNome.Focus();
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) txtCEP.Focus();
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    txtNumero.Focus();
                    break;
                case (char)Keys.Back:
                case (char)Keys.Delete:
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
                case (char)Keys.Enter:
                    txtEndereco.Focus();
                    break;
                case (char)Keys.Back:
                case (char)Keys.Delete:
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
            if (e.KeyChar == (char)Keys.Enter) cmbBairro.Focus();
        }

        private void cmbBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) txtObservacaoCliente.Focus();
        }

        private void txtObservacaoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) btnSalvarCliente.Focus();
        }

        private void btnSalvarCliente_Click(object sender, EventArgs e)
        {
            if (!VerificaCamposObrigatorios()) return;
            
            lblFormPedidoAguarde.Visible = true;

            var clientId = "";
            var city = "";
            var state = "";
            var email = "";
            var cpf = "";
            var rg = "";
            var status = 1;

            if (_clientSelected != null && _clientSelected.Id != "")
            {
                clientId = _clientSelected.Id ?? "";
                city = _clientSelected.Cidade ?? "Indaiatuba";
                state = _clientSelected.Estado ?? "SP";
                email = _clientSelected.Email ?? "";
                cpf = _clientSelected.CPF ?? "";
                rg = _clientSelected.RG ?? "";
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

            _clientController.Save(client, client.Id == "" ? "new" : "edit");
            if (!_clientController.MessageError.Equals(""))
            {
                MessageBox.Show(_clientController.MessageError, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _products = _produtoController.LoadAll();
            cmbDescricaoProduto.Items.Clear();
            _products.ForEach(product => cmbDescricaoProduto.Items.Add(product.Descricao));

            var clienteCadastrado = _clientController.LoadByPhone(client.Telefone);
            if (clienteCadastrado.Id == null || clienteCadastrado.Id.Equals(""))
            {
                MessageBox.Show("não foi possivel cadastrar cliente", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _clientSelected = clienteCadastrado;
            txtIdCliente.Text = clienteCadastrado.Id;

            InicializaPedido();

            panelClient.Enabled = false;
            panelOrder.Enabled = true;

            txtVrTaxaEntrega.Text = txtTaxaEntrega.Text;

            txtCodBarras.Focus();
            
            lblFormPedidoAguarde.Visible = false;
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
            listProdutos.Columns.Add("Descrição", 210, HorizontalAlignment.Left);
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
                case (char)Keys.Back:
                case (char)Keys.Delete:
                    break;
                case (char)Keys.Enter:
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
            if (e.KeyChar != (char)Keys.Enter) return;
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
            if (e.KeyChar == (char)Keys.Enter) txtQtde.Focus();
        }

        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                case (char)Keys.Back:
                case (char)Keys.Delete:
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

            try
            {
                // var lastOrder = _pedidoController.LoadLastOrderId();
                // if (!lblNrPedido.Text.Equals("0"))
                //     lastOrder.Id = Convert.ToInt16(lblNrPedido.Text);

                var qtde = Convert.ToInt16(txtQtde.Text);
                var vrTotalItem = _productSelected.PrecoVenda * qtde;

                ListViewItem items = new ListViewItem(_productSelected.Uid);
                // items.SubItems.Add(_productSelected.Id.ToString());
                items.SubItems.Add(_productSelected.Descricao);
                items.SubItems.Add(_productSelected.UnMedida);
                items.SubItems.Add(qtde.ToString());
                items.SubItems.Add(_productSelected.PrecoVenda.ToString("0.00"));
                items.SubItems.Add(vrTotalItem.ToString("0.00"));

                var item = new PedidoItem
                {
                    CodProduto = _productSelected.Uid,
                    VrUnitario = _productSelected.PrecoVenda,
                    Quantidade = qtde,
                    Observacao = txtObservacaoProduto.Text,
                    VrTotal = vrTotalItem,
                    CodPedido = _orderSelected?.CodPedido,
                };

                _pedidoItens.Add(item);
                _pedidoItensNew.Add(item);

                listProdutos.Items.Add(items);

                var vrTotalSemTaxa = 0.00;
                var vrTotalTaxa = Convert.ToDouble(txtVrTaxaEntrega.Text);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            lblFormPedidoAguarde.Visible = true;
            
            var vrTotal = 0.00;
            _pedidoItens.ForEach(item => vrTotal += item.VrTotal);

            var orderId = Convert.ToInt16(lblNrPedido.Text);
            var vrTroco = Convert.ToDouble(txtVrTroco.Text);
            var vrTaxa = Convert.ToDouble(txtVrTaxaEntrega.Text);
            var formaPagamento = cmbFormaPagamento.Text;

            var codPedido = _orderSelected?.CodPedido;

            var order = new Pedido
            {
                Id = orderId,
                CodPedido = codPedido,
                IdOperador = User.Id,
                Bairro = _clientSelected.Bairro,
                Cidade = _clientSelected.Cidade,
                Estado = _clientSelected.Estado,
                Logradouro = _clientSelected.Endereco,
                Numero = _clientSelected.Numero,
                Observacao = txtObservacaoPedido.Text,
                Origem = "LOCAL",
                CodCliente = _clientSelected.Id,
                DataEntrega = DateTime.Now,
                DataPedido = DateTime.Now,
                StatusPedido = "Confirmado",
                TipoPedido = "ENTREGA",
                VrTotal = vrTotal,
                VrTroco = vrTroco,
                VrTaxa = vrTaxa,
                Itens = orderId == 0 ? _pedidoItens : _pedidoItensNew,
                CEP = _clientSelected.CEP,
                FormaPagamento = formaPagamento,
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
            
            lblFormPedidoAguarde.Visible = false;
        }

        private void LimpaTelaPedidoConcluido()
        {
            LimpaCamposProdutoLancado();
            ClearClient();
            ClearOrder();
        }

        private void txtVrTrocoPara_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtVrTroco.Text = (Convert.ToDouble(txtVrTrocoPara.Text) - _vrTotalPedido).ToString("0.00");
                cmbFormaPagamento.Focus();
            }
        }

        private void btnVisualizaPedidos_Click(object sender, EventArgs e)
        {
            ClearClient();
            ClearOrder();

            timer_notificaPedidoAberto.Enabled = false;
            timer_notificaPedidoAberto.Stop();

            using (var formPedidos = new FormPedidos())
            {
                formPedidos.ShowDialog();

                timer_notificaPedidoAberto.Enabled = true;
                timer_notificaPedidoAberto.Start();

                if (formPedidos.PedidoSelecionado != null)
                {
                    CarregaPedidoSelecionado(formPedidos.PedidoSelecionado);
                    _orderSelected = formPedidos.PedidoSelecionado;
                }
                else
                    _orderSelected = null;
            }
        }

        private void CarregaPedidoSelecionado(Pedido pedido)
        {
            lblFormPedidoAguarde.Visible = true;
            
            InicializaPedido();

            // Carrega dados pedido
            panelOrder.Enabled = true;
            txtQtde.Text = "1";
            txtQtde.Enabled = false;
            txtCodBarras.Text = "";
            txtValorUnit.Text = "0.00";
            txtObservacaoProduto.Text = "";
            txtObservacaoProduto.Enabled = false;

            var vrTotalPedido = pedido.VrTotal + pedido.VrTaxa;

            lblNrPedido.Text = pedido.Id.ToString();
            txtVrTotalItens.Text = pedido.VrTotal.ToString("0.00");
            txtVrTroco.Text = pedido.VrTroco.ToString("0.00");
            txtVrTaxaEntrega.Text = pedido.VrTaxa.ToString("0.00");
            txtVrTotalPedido.Text = vrTotalPedido.ToString("0.00");
            txtVrTrocoPara.Text = "";
            txtVrTrocoPara.Enabled = true;
            cmbFormaPagamento.Text = pedido.FormaPagamento;
            txtObservacaoPedido.Text = pedido.Observacao;

            _vrTotalPedido = pedido.VrTaxa + pedido.VrTotal;

            _products = _produtoController.LoadAll();
            cmbDescricaoProduto.Items.Clear();
            _products.ForEach(product => cmbDescricaoProduto.Items.Add(product.Descricao));

            foreach (var item in pedido.Itens)
            {
                CarregaItensPedidoSelecionado(item);
            }

            // Carrega dados cliente
            panelClient.Enabled = false;

            // var cliente = _clientController.LoadById(pedido.Cliente.Id).First();
            _clientSelected = new Client
            {
                Id = pedido.Cliente.Id,
                Nome = pedido.Cliente.Nome,
                Telefone = pedido.Cliente.Telefone,
                Endereco = pedido.Cliente.Endereco,
                Bairro = pedido.Cliente.Bairro,
                Cidade = pedido.Cliente.Cidade,
                Email = pedido.Cliente.Email,
                Estado = pedido.Cliente.Estado,
                Numero = pedido.Cliente.Numero,
                Observacao = pedido.Observacao,
                Status = pedido.Cliente.Status,
                RG = pedido.Cliente.RG,
                CEP = pedido.Cliente.CEP,
                CPF = pedido.Cliente.CPF,
            };

            txtNome.Text = _clientSelected.Nome;
            txtTelefone.Text = _clientSelected.Telefone;
            txtDDD.Text = "19";
            txtNumero.Text = pedido.Numero.ToString();
            cmbBairro.Text = pedido.Bairro;
            txtCEP.Text = pedido.CEP;
            txtEndereco.Text = pedido.Logradouro;
            txtObservacaoCliente.Text = pedido.Observacao;
            txtIdCliente.Text = pedido.Cliente.Id;
            
            lblFormPedidoAguarde.Visible = false;
        }

        private void CarregaItensPedidoSelecionado(PedidoItem pedidoItem)
        {
            _productSelected = _products.Find(product => product.Descricao.Equals(pedidoItem.Nome));

            var vrTotalItem = pedidoItem.VrUnitario * pedidoItem.Quantidade;

            ListViewItem items = new ListViewItem(_productSelected.Uid);
            // items.SubItems.Add(_productSelected.Id.ToString());
            items.SubItems.Add(_productSelected.Descricao);
            items.SubItems.Add(_productSelected.UnMedida);
            items.SubItems.Add(pedidoItem.Quantidade.ToString("0"));
            items.SubItems.Add(pedidoItem.VrUnitario.ToString("0.00"));
            items.SubItems.Add(vrTotalItem.ToString("0.00"));

            var item = new PedidoItem
            {
                CodProduto = _productSelected.Uid,
                VrUnitario = _productSelected.PrecoVenda,
                Quantidade = pedidoItem.Quantidade,
                Observacao = txtObservacaoProduto.Text,
                VrTotal = vrTotalItem,
                CodPedido = pedidoItem.CodPedido,
                StatusEditar = 2
            };

            _pedidoItens.Add(item);

            items.BackColor = Color.Brown;
            listProdutos.Items.Add(items);
        }

        private void btnCadastroBairros_Click(object sender, EventArgs e)
        {
            using (var formBairro = new FormBairroTaxa())
            {
                formBairro.ShowDialog();

                lblFormPedidoAguarde.Visible = true;
                _bairros = _bairroController.LoadAll();

                ClearClient();
                ClearOrder();
                
                lblFormPedidoAguarde.Visible = false;
            }
        }

        private void cmbBairro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_clientSelected != null)
            {
                foreach (var bairro in _bairros)
                {
                    if (_clientSelected.Bairro != null)
                    {
                        if (bairro.Nome.ToUpper().Equals(_clientSelected.Bairro.ToUpper()))
                        {
                            txtTaxaEntrega.Text = bairro.VrTaxa.ToString("0.00");
                            break;
                        }
                    }
                    else
                    {
                        if (bairro.Nome.ToUpper().Equals(cmbBairro.Text.ToUpper()))
                        {
                            txtTaxaEntrega.Text = bairro.VrTaxa.ToString("0.00");
                            break;
                        }
                    }
                }
            }

            if (txtTaxaEntrega.Text.Equals("0") || txtTaxaEntrega.Text.Equals("0.00"))
            {
                txtTaxaEntrega.Enabled = true;
            }
        }

        private void threadLoadOpenedPending()
        {
            var pedidoAberto = _pedidoController.LoadPedidosAberto();
            if (pedidoAberto != null)
            {
                if (!pedidoAberto.Equals(""))
                {
                    lbl_notificaPedidoAberto.BackColor = Color.OrangeRed;
                    lbl_notificaPedidoAberto.Text = pedidoAberto;
                }
                else
                {
                    lbl_notificaPedidoAberto.BackColor = Color.Transparent;
                    lbl_notificaPedidoAberto.Text = "";
                }
            }
            else
            {
                lbl_notificaPedidoAberto.BackColor = Color.Transparent;
                lbl_notificaPedidoAberto.Text = "";
            }
        }

        private void timer_notificaPedidoAberto_Tick(object sender, EventArgs e)
        {
            var thre = new Thread(threadLoadOpenedPending);
            thre.Start();
        }

        private void FormPedido_Shown(object sender, EventArgs e)
        {
            lblFormPedidoAguarde.Visible = true;
            _bairros = _bairroController.LoadAll();
            lblFormPedidoAguarde.Visible = false;
        }
    }
}