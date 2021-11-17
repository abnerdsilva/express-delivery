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
            items.SubItems.Add(product.PrecoCompra.ToString());
            items.SubItems.Add(product.UnMedida);
            items.SubItems.Add(product.PrecoVenda.ToString());

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
            painelConsultaCardapio.Visible = false;
            panelDetalheCardapio.Visible = true;

            ClearDetailsProduct();
            ClearSearchProduct();
        }
    }
}