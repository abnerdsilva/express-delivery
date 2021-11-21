using System;
using System.Collections.Generic;
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

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            _pedidos.Clear();
            
            _pedidos = _pedidoController.LoadAll();
            if (!_pedidoController.MessageError.Equals(""))
                MessageBox.Show(_pedidoController.MessageError);
            else if (_pedidos != null)
                CarregaListaPedidos();
        }

        private void CarregaListaPedidos()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.LabelEdit = true;

            listView1.Columns.Add("ID", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("Nome", 220, HorizontalAlignment.Left);
            listView1.Columns.Add("Data Pedido", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Origem Pedido", 100, HorizontalAlignment.Center);

            foreach (var pedido in _pedidos)
            {
                var items = new ListViewItem(pedido.Id.ToString());
                items.SubItems.Add(pedido.Nome);
                items.SubItems.Add(pedido.DataPedido.ToString("dd/MM/yyy"));
                items.SubItems.Add(pedido.Origem);

                listView1.Items.Add(items);
            }
        }

        private void btnBuscaCodigoPedido_Click(object sender, EventArgs e)
        {
            if (txtCodigoPedido.Text.Equals(""))
            {
                MessageBox.Show("Código do pedido não foi informado", "Atenção", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            
            listView1.Clear();
            _pedidos.Clear();

            _pedidos = _pedidoController.LoadByCode(Convert.ToInt16(txtCodigoPedido.Text), cmbStatusPedidoCodigo.Text);
            if (!_pedidoController.MessageError.Equals(""))
                MessageBox.Show(_pedidoController.MessageError);
            else if (_pedidos != null)
                CarregaListaPedidos();
        }

        private void btnBuscaDataPedido_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _pedidos.Clear();

            _pedidos = _pedidoController.LoadByDate(dtInicio.Value.ToString("yyyy-MM-dd"), dtFim.Value.ToString("yyyy-MM-dd"));
            if (!_pedidoController.MessageError.Equals(""))
                MessageBox.Show(_pedidoController.MessageError);
            else if (_pedidos != null)
                CarregaListaPedidos();
        }

        private void btnBuscarTodosDoDia_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            _pedidos.Clear();
            
            _pedidos = _pedidoController.LoadAll();
            if (!_pedidoController.MessageError.Equals(""))
                MessageBox.Show(_pedidoController.MessageError);
            else if (_pedidos != null)
                CarregaListaPedidos();
        }
    }
}