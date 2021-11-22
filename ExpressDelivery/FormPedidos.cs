using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ExpressDelivery.Controllers;
using ExpressDelivery.Models;

namespace ExpressDelivery
{
    public partial class FormPedidos : Form
    {
        // private readonly ClientController _clientController = new ClientController();
        // private readonly ProdutoController _produtoController = new ProdutoController();
        private readonly PedidoController _pedidoController = new PedidoController();

        private List<Pedido> _pedidos = new List<Pedido>();

        public FormPedidos()
        {
            InitializeComponent();
        }

        public Pedido PedidoSelecionado { get; private set; }

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            listPedidos.Clear();
            listPedidos.Clear();

            _pedidos = _pedidoController.LoadAll();
            if (!_pedidoController.MessageError.Equals(""))
                MessageBox.Show(_pedidoController.MessageError);
            else if (_pedidos != null)
                CarregaListaPedidos();
        }

        private void CarregaListaPedidos()
        {
            listPedidos.View = View.Details;
            listPedidos.FullRowSelect = true;
            listPedidos.GridLines = true;
            listPedidos.LabelEdit = true;

            listPedidos.Columns.Add("ID", 70, HorizontalAlignment.Center);
            listPedidos.Columns.Add("Nome", 220, HorizontalAlignment.Left);
            listPedidos.Columns.Add("Data Pedido", 100, HorizontalAlignment.Center);
            listPedidos.Columns.Add("Origem Pedido", 100, HorizontalAlignment.Center);
            listPedidos.Columns.Add("Status", 100, HorizontalAlignment.Center);
            listPedidos.Columns.Add("Vr Pedido", 100, HorizontalAlignment.Center);

            foreach (var pedido in _pedidos)
            {
                var items = new ListViewItem(pedido.Id.ToString());
                items.SubItems.Add(pedido.Nome);
                items.SubItems.Add(pedido.DataPedido.ToString("dd/MM/yyy"));
                items.SubItems.Add(pedido.Origem);
                items.SubItems.Add(pedido.StatusPedido);
                items.SubItems.Add((pedido.VrTotal + pedido.VrTaxa).ToString("0.00"));

                if (pedido.StatusPedido == "FECHADO")
                    items.ForeColor = Color.Green;
                if (pedido.StatusPedido == "CONCLUIDO")
                    items.ForeColor = Color.Blue;

                listPedidos.Items.Add(items);
            }
        }

        private void btnBuscaCodigoPedido_Click(object sender, EventArgs e)
        {
            if (txtCodigoPedido.Text.Equals(""))
            {
                MessageBox.Show(@"Código do pedido não foi informado", @"Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            listPedidos.Clear();
            listPedidos.Clear();

            _pedidos = _pedidoController.LoadByCode(Convert.ToInt16(txtCodigoPedido.Text), cmbStatusPedidoCodigo.Text);
            if (!_pedidoController.MessageError.Equals(""))
                MessageBox.Show(_pedidoController.MessageError);
            else if (_pedidos != null)
                CarregaListaPedidos();
        }

        private void btnBuscaDataPedido_Click(object sender, EventArgs e)
        {
            listPedidos.Clear();
            _pedidos.Clear();

            _pedidos = _pedidoController.LoadByDate(dtInicio.Value.ToString("yyyy-MM-dd"),
                dtFim.Value.ToString("yyyy-MM-dd"));
            if (!_pedidoController.MessageError.Equals(""))
                MessageBox.Show(_pedidoController.MessageError);
            else if (_pedidos != null)
                CarregaListaPedidos();
        }

        private void btnBuscarTodosDoDia_Click(object sender, EventArgs e)
        {
            listPedidos.Clear();
            _pedidos.Clear();

            _pedidos = _pedidoController.LoadAll();
            if (!_pedidoController.MessageError.Equals(""))
                MessageBox.Show(_pedidoController.MessageError);
            else if (_pedidos != null)
                CarregaListaPedidos();
        }

        private void listPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listPedidos.SelectedItems.Count > 0)
                {
                    var index = listPedidos.SelectedItems[0].SubItems[0].Text;

                    listDetalhePedido.Clear();
                    listDetalhePedido.View = View.Details;
                    listDetalhePedido.FullRowSelect = true;
                    listDetalhePedido.GridLines = true;
                    listDetalhePedido.LabelEdit = true;

                    listDetalhePedido.Columns.Add("CodProduto", 70, HorizontalAlignment.Center);
                    listDetalhePedido.Columns.Add("Nome", 220, HorizontalAlignment.Left);
                    listDetalhePedido.Columns.Add("Quantidade", 70, HorizontalAlignment.Center);
                    listDetalhePedido.Columns.Add("Vr Unitario", 70, HorizontalAlignment.Right);
                    listDetalhePedido.Columns.Add("Vr Total", 70, HorizontalAlignment.Right);
                    listDetalhePedido.Columns.Add("Observação", 250, HorizontalAlignment.Left);

                    var pedido = _pedidos.Single(pedido1 => pedido1.Id.Equals(Convert.ToInt16(index)));
                    foreach (var item in pedido.Itens)
                    {
                        var items = new ListViewItem(item.CodProduto.ToString());
                        items.SubItems.Add(item.Nome);
                        items.SubItems.Add(item.Quantidade.ToString("0"));
                        items.SubItems.Add(item.VrUnitario.ToString("0.00"));
                        items.SubItems.Add(item.VrTotal.ToString("0.00"));
                        items.SubItems.Add(item.Observacao);

                        listDetalhePedido.Items.Add(items);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void listPedidos_DoubleClick(object sender, EventArgs e)
        {
            var index = listPedidos.SelectedItems[0].SubItems[0].Text;
            PedidoSelecionado = _pedidos.Single(pedido1 => pedido1.Id.Equals(Convert.ToInt16(index)));
            this.Dispose();
            // Close();
        }
    }
}