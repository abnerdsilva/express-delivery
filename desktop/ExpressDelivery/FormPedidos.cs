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
        private readonly PedidoController _pedidoController = new PedidoController();

        private List<Pedido> _pedidos = new List<Pedido>();
        private string _localBusca;
        private int _idPedidoSelecionado;
        private string _statusPedidoSelecionado = "FECHADO";

        public FormPedidos()
        {
            InitializeComponent();
        }

        public Pedido PedidoSelecionado { get; private set; }

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            listPedidos.Clear();
            listPedidos.Clear();
            dtInicio.Value = DateTime.Today;
            dtFim.Value = DateTime.Today;
            _localBusca = "GERAL";

            cmbStatusPedidoData.Items.Clear();
            cmbStatusPedidoCodigo.Items.Clear();
            cmbStatusPedidoData.Items.Add("ABERTO");
            cmbStatusPedidoData.Items.Add("BAIXADO");
            cmbStatusPedidoData.Items.Add("CANCELADO");
            cmbStatusPedidoData.Items.Add("TODOS");
            cmbStatusPedidoCodigo.Items.Add("ABERTO");
            cmbStatusPedidoCodigo.Items.Add("BAIXADO");
            cmbStatusPedidoCodigo.Items.Add("CANCELADO");
            cmbStatusPedidoCodigo.Items.Add("TODOS");

            CarregaDadosPedidos();
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

                if (pedido.StatusPedido == "CANCELADO")
                    items.ForeColor = Color.Red;
                else if (pedido.StatusPedido == "BAIXADO")
                    items.ForeColor = Color.Green;
                else if (pedido.Origem.Equals("IFOOD") && pedido.StatusPedido.Equals("ABERTO") && pedido.DataAtualizacao.ToString().Contains("00:00:00"))
                    items.BackColor = Color.OrangeRed;

                listPedidos.Items.Add(items);
            }
            
            if (!_statusPedidoSelecionado.ToUpper().Equals("CONCLUIDO") && !_statusPedidoSelecionado.ToUpper().Equals("CANCELADO"))
            {
                btnBaixarPedido.Visible = true;
                btnCancelaPedido.Visible = true;
            }
            else
            {
                btnBaixarPedido.Visible = false;
                btnCancelaPedido.Visible = false;
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
            _localBusca = "CODIGO";

            CarregaDadosPedidos();
        }

        private void btnBuscaDataPedido_Click(object sender, EventArgs e)
        {
            listPedidos.Clear();
            _pedidos.Clear();
            _localBusca = "DATA";

            CarregaDadosPedidos();
        }

        private void btnBuscarTodosDoDia_Click(object sender, EventArgs e)
        {
            listPedidos.Clear();
            _pedidos.Clear();
            _localBusca = "GERAL";

            CarregaDadosPedidos();
        }

        private void CarregaDadosPedidos()
        {
            _pedidos.Clear();
            listPedidos.Clear();

            if (_localBusca.Equals("DATA"))
                _pedidos = _pedidoController.LoadByDate(dtInicio.Value.ToString("yyyy-MM-dd"),
                    dtFim.Value.ToString("yyyy-MM-dd"), cmbStatusPedidoData.Text);
            else if (_localBusca.Equals("CODIGO"))
                _pedidos = _pedidoController.LoadByCode(Convert.ToInt16(txtCodigoPedido.Text), cmbStatusPedidoCodigo.Text);
            else
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
                    _idPedidoSelecionado = Convert.ToInt16(listPedidos.SelectedItems[0].SubItems[0].Text);
                    _statusPedidoSelecionado = listPedidos.SelectedItems[0].SubItems[4].Text;

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

                    var pedido = _pedidos.Single(pedido1 => pedido1.Id.Equals(_idPedidoSelecionado));
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
            
            if (!_statusPedidoSelecionado.ToUpper().Equals("CONCLUIDO") && !_statusPedidoSelecionado.ToUpper().Equals("CANCELADO"))
            {
                btnBaixarPedido.Visible = true;
                btnCancelaPedido.Visible = true;
            }
            else
            {
                btnBaixarPedido.Visible = false;
                btnCancelaPedido.Visible = false;
            }
        }

        private void listPedidos_DoubleClick(object sender, EventArgs e)
        {
            var index = listPedidos.SelectedItems[0].SubItems[0].Text;
            PedidoSelecionado = _pedidos.Single(pedido1 => pedido1.Id.Equals(Convert.ToInt16(index)));
            if (PedidoSelecionado.StatusPedido.Equals("BAIXADO") || PedidoSelecionado.StatusPedido.Equals("CANCELADO")) return;
            Dispose();
        }

        private void btnBaixarPedido_Click(object sender, EventArgs e)
        {
            var atualizado = _pedidoController.UpdateOrder("BAIXADO", _idPedidoSelecionado);
            if (!_pedidoController.MessageError.Equals(""))
                MessageBox.Show(_pedidoController.MessageError, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (atualizado > 0)
            {
                CarregaDadosPedidos();
                
                btnCancelaPedido.Visible = false;
                btnBaixarPedido.Visible = false;
                MessageBox.Show(@"Pedido baixado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void btnCancelaPedido_Click(object sender, EventArgs e)
        {
            var atualizado = _pedidoController.UpdateOrder("CANCELADO", _idPedidoSelecionado);
            if (!_pedidoController.MessageError.Equals(""))
                MessageBox.Show(_pedidoController.MessageError, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (atualizado > 0)
            {
                CarregaDadosPedidos();
                
                btnCancelaPedido.Visible = false;
                btnBaixarPedido.Visible = false;
                MessageBox.Show(@"Pedido cancelado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
    }
}