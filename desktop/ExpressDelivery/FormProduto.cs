using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ExpressDelivery.Controllers;
using ExpressDelivery.Models;

namespace ExpressDelivery
{
    public partial class FormCardapio : Form
    {
        public FormCardapio()
        {
            InitializeComponent();
        }

        private readonly ProdutoController _produtoController = new ProdutoController();
        
        private List<Product> _products = new List<Product>();

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            listProdutos.Clear();
            _products.Clear();

            listProdutos.View = View.Details;
            listProdutos.FullRowSelect = true;
            listProdutos.GridLines = true;
            listProdutos.LabelEdit = true;

            listProdutos.Columns.Add("ID Produto", 80, HorizontalAlignment.Left);
            listProdutos.Columns.Add("Descrição", 250, HorizontalAlignment.Left);
            listProdutos.Columns.Add("Preço Compra", 120, HorizontalAlignment.Left);
            listProdutos.Columns.Add("Unidade", 80, HorizontalAlignment.Left);
            listProdutos.Columns.Add("Preço Venda", 120, HorizontalAlignment.Left);

            var statusPesquisa = 0;
            if (cmbStatusPesquisa.Text == "Ativo")
                statusPesquisa = 1;

            if (txtDescricao.Text.Equals(""))
                _products = _produtoController.LoadAll();
            else
            {
                if (cmbTipoPesquisa.Text == "Descrição")
                    _products = _produtoController.LoadByName(txtDescricao.Text);
                else
                    _products = _produtoController.LoadById(txtDescricao.Text);
            }

            _products.FindAll(c => c.Status == statusPesquisa).ForEach(AddItemLista);
        }

        private void AddItemLista(Product product)
        {
            ListViewItem items = new ListViewItem(product.Id.ToString());
            items.SubItems.Add(product.Descricao);
            items.SubItems.Add(product.PrecoCompra.ToString("0.00"));
            items.SubItems.Add(product.UnMedida);
            items.SubItems.Add(product.PrecoVenda.ToString("0.00"));

            listProdutos.Items.Add(items);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            painelConsultaCardapio.Visible = false;
            panelDetalheCardapio.Visible = true;

            ClearDetailsProduct();
            ClearSearchProduct();
        }

        private void ClearDetailsProduct()
        {
            txtIdProduto.Text = "0";
            txtNome.Text = "";
            txtCodBarras.Text = "";
            txtCategoria.Text = "";
            txtLocalizacao.Text = "";
            txtPrecoCompra.Text = "";
            txtPrecoVenda.Text = "";
            txtMargemLucro.Text = "";
            radioProdutoInativo.Checked = false;
            radioProdutoAtivo.Checked = true;
        }

        private void ClearSearchProduct()
        {
            txtDescricao.Text = "";
            cmbTipoPesquisa.Text = "Nome";
            cmbStatusPesquisa.Text = "Ativo";

            listProdutos.Clear();
        }

        private void btnVoltarProduto_Click(object sender, EventArgs e)
        {
            painelConsultaCardapio.Visible = true;
            panelDetalheCardapio.Visible = false;

            ClearDetailsProduct();
            ClearSearchProduct();
        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            ClearDetailsProduct();
        }

        private void listProdutos_DoubleClick(object sender, EventArgs e)
        {
            painelConsultaCardapio.Visible = false;
            panelDetalheCardapio.Visible = true;

            ClearDetailsProduct();

            var idProduct = listProdutos.SelectedItems[0].SubItems[0].Text;
            var product = new Product();
            foreach (var c in _products)
            {
                if (c.Id != int.Parse(idProduct)) continue;
                product = c;
                break;
            }

            txtIdProduto.Text = idProduct;
            txtNome.Text = product.Descricao;
            txtCodBarras.Text = product.CodBarras;
            txtCategoria.Text = product.Categoria;
            txtLocalizacao.Text = product.Localizacao;
            txtObservacao.Text = product.Observacao;
            txtPrecoCompra.Text = Convert.ToDouble(product.PrecoCompra).ToString("0.00");
            txtPrecoVenda.Text = Convert.ToDouble(product.PrecoVenda).ToString("0.00");
            txtMargemLucro.Text = Convert.ToDouble(product.MargemLucro).ToString("0.00");
            cmbUnMedida.Text = product.UnMedida;
            if (product.Status == 1)
                radioProdutoAtivo.Checked = true;
            else
                radioProdutoInativo.Checked = true;
        }

        private void btnSalvarProduto_Click(object sender, EventArgs e)
        {
            var status = 0;
            if (radioProdutoAtivo.Checked)
                status = 1;

            var idProduct = _produtoController.LastProductId() + 1;
            if (!txtIdProduto.Text.Equals("0"))
                idProduct = Convert.ToInt16(txtIdProduto.Text);

            if (txtCodBarras.Text.Equals(""))
            {
                MessageBox.Show(@"O campo códico de barras é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (txtNome.Text.Equals(""))
            {
                MessageBox.Show(@"O campo nome é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbUnMedida.Text.Equals(""))
            {
                MessageBox.Show(@"O campo unidade de medida é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (txtPrecoVenda.Text.Equals(""))
            {
                MessageBox.Show(@"O campo preço de venda é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            var product = new Product
            {
                Descricao = txtNome.Text,
                CodBarras = txtCodBarras.Text,
                Categoria = txtCategoria.Text,
                Localizacao = txtLocalizacao.Text,
                Observacao = txtObservacao.Text,
                UnMedida = cmbUnMedida.Text,
                PrecoCompra = ConvertToDouble(txtPrecoCompra.Text),
                PrecoVenda = ConvertToDouble(txtPrecoVenda.Text),
                Status = status,
                MargemLucro = ConvertToDouble(txtMargemLucro.Text),
                Id = idProduct,
            };
            
            _produtoController.Save(product, txtIdProduto.Text.Equals("0") ? "new" : "edit");
            
            if (!_produtoController.MessageError.Equals(""))
            {
                MessageBox.Show($@"Erro ao salvar produto. {_produtoController.MessageError}");
                return;
            }
            
            _products.Add(product);
            
            txtIdProduto.Text = idProduct.ToString();
            
            MessageBox.Show(@"Salvo com sucesso!","Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private static double ConvertToDouble(string value)
        {
            if (value == "")
                return 0.00;

            return Convert.ToDouble(value);
        }
    }
}