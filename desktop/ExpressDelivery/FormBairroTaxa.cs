using ExpressDelivery.Controllers;
using ExpressDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpressDelivery
{
    public partial class FormBairroTaxa : Form
    {
        private readonly BairroController _bairroController = new BairroController();

        private List<Bairro> _bairros = new List<Bairro>();
        private Bairro _bairroSelecionado = new Bairro();

        public FormBairroTaxa()
        {
            InitializeComponent();
        }

        private void LimpaCampos()
        {
            txtBairro.Text = "";
            txtIdBairro.Text = "0";
            txtVrTaxa.Text = "";
            listBairros.Items.Clear();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var bairro = new Bairro
            {
                Nome = txtBairro.Text,
                VrTaxa = Convert.ToDouble(txtVrTaxa.Text),
                Id = txtIdBairro.Text,
                Status = 1
            };

            var resp = _bairroController.Save(bairro, "new");
            if (!_bairroController.MessageError.Equals(""))
                MessageBox.Show(_bairroController.MessageError, @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("Bairro cadastrado com sucesso", @"Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);

                LimpaCampos();

                _bairros = _bairroController.LoadAll();

                CarregaListaBairros();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void txtBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) txtVrTaxa.Focus();
        }

        private void txtVrTaxa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) btnCadastrar.Focus();
        }

        private void btnListarBairros_Click(object sender, EventArgs e)
        {
            LimpaCampos();

            _bairros = _bairroController.LoadAll();

            CarregaListaBairros();
        }

        private void listBairros_DoubleClick(object sender, EventArgs e)
        {
            var idBairroSeleiconado = listBairros.SelectedItems[0].SubItems[0].Text;
            var bairro = _bairros.Single(pedido1 => pedido1.Id.Equals(idBairroSeleiconado));

            txtBairro.Text = bairro.Nome;
            txtIdBairro.Text = bairro.Id;
            txtVrTaxa.Text = bairro.VrTaxa.ToString("0.00");
        }

        private void CarregaListaBairros()
        {
            listBairros.Clear();

            listBairros.View = View.Details;
            listBairros.FullRowSelect = true;
            listBairros.GridLines = true;
            listBairros.LabelEdit = true;

            listBairros.Columns.Add("ID", 70, HorizontalAlignment.Center);
            listBairros.Columns.Add("Nome", 210, HorizontalAlignment.Left);
            listBairros.Columns.Add("Vr Taxa", 80, HorizontalAlignment.Center);

            foreach (var bairro in _bairros)
            {
                ListViewItem items = new ListViewItem(bairro.Id.ToString());
                items.SubItems.Add(bairro.Nome);
                items.SubItems.Add(bairro.VrTaxa.ToString("0.00"));

                listBairros.Items.Add(items);
            }
        }
    }
}