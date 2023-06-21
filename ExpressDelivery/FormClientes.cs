using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ExpressDelivery.Controllers;
using ExpressDelivery.Models;

namespace ExpressDelivery
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private readonly ClientController _clientController = new ClientController();

        private List<Client> _clients = new List<Client>();

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            listClientes.Clear();
            _clients.Clear();

            listClientes.View = View.Details;
            listClientes.FullRowSelect = true;
            listClientes.GridLines = true;
            listClientes.LabelEdit = true;

            listClientes.Columns.Add("ID Cliente", 80, HorizontalAlignment.Left);
            listClientes.Columns.Add("Nome", 250, HorizontalAlignment.Left);
            listClientes.Columns.Add("Telefone", 120, HorizontalAlignment.Left);
            listClientes.Columns.Add("Email", 250, HorizontalAlignment.Left);

            var statusClientes = 0;
            if (cmbStatusPesquisa.Text == "Ativo")
                statusClientes = 1;

            if (txtDescricaoPesquisa.Text.Equals(""))
                _clients = _clientController.LoadAll();
            else
            {
                if (cmbTipoPesquisa.Text == "Nome")
                    _clients = _clientController.LoadByName(txtDescricaoPesquisa.Text);
                else
                    _clients = _clientController.LoadById(txtDescricaoPesquisa.Text);
            }

            _clients.FindAll(c => c.Status == statusClientes).ForEach(AddItemLista);
        }

        private void AddItemLista(Client client)
        {
            ListViewItem items = new ListViewItem(client.Id.ToString());
            items.SubItems.Add(client.Nome);
            items.SubItems.Add(client.Telefone);
            items.SubItems.Add(client.Email);

            listClientes.Items.Add(items);
        }

        private void ClearDetailsClient()
        {
            txtIdClient.Text = "0";
            txtNome.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtCEP.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtCPF.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtRG.Text = "";
            cmbEstado.Text = "";
            radioAtivo.Checked = true;
            radioInativo.Checked = false;
        }

        private void ClearSearchClient()
        {
            txtDescricaoPesquisa.Text = "";
            cmbStatusPesquisa.Text = "Ativo";
            cmbTipoPesquisa.Text = "Nome";

            listClientes.Clear();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            panelConsultaCliente.Visible = false;
            panelDetalheCliente.Visible = true;

            ClearDetailsClient();
            ClearSearchClient();
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            panelConsultaCliente.Visible = true;
            panelDetalheCliente.Visible = false;

            ClearDetailsClient();
            ClearSearchClient();
        }

        private void listClientes_DoubleClick(object sender, EventArgs e)
        {
            panelConsultaCliente.Visible = false;
            panelDetalheCliente.Visible = true;

            ClearDetailsClient();

            var idClient = listClientes.SelectedItems[0].SubItems[0].Text;
            var client = new Client();
            foreach (var c in _clients)
            {
                if (c.Id != int.Parse(idClient)) continue;
                client = c;
                break;
            }

            txtIdClient.Text = idClient;
            txtNome.Text = client.Nome;
            txtTelefone.Text = client.Telefone;
            txtEmail.Text = client.Email;
            txtCEP.Text = client.CEP;
            txtBairro.Text = client.Bairro;
            txtCidade.Text = client.Cidade;
            txtCPF.Text = client.CPF;
            txtEndereco.Text = client.Endereco;
            txtNumero.Text = client.Numero.ToString();
            txtRG.Text = client.RG;
            cmbEstado.Text = client.Estado;
            txtInfoAdicional.Text = client.Observacao;
            if (client.Status == 1)
                radioAtivo.Checked = true;
            else
                radioInativo.Checked = true;
        }

        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            ClearDetailsClient();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var status = 0;
            if (radioAtivo.Checked)
                status = 1;

            var idClient = _clientController.LastClientId() + 1;
            if (!txtIdClient.Text.Equals("0"))
                idClient = Convert.ToInt16(txtIdClient.Text);

            if (txtNome.Text.Equals(""))
            {
                MessageBox.Show(@"O campo nome é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtCEP.Text.Equals(""))
            {
                MessageBox.Show(@"O campo cep é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtEndereco.Text.Equals(""))
            {
                MessageBox.Show(@"O campo endereço é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNumero.Text.Equals(""))
            {
                MessageBox.Show(@"O campo número é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtBairro.Text.Equals(""))
            {
                MessageBox.Show(@"O campo bairro é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtTelefone.Text.Equals(""))
            {
                MessageBox.Show(@"O campo telefone é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cpf = txtCPF.Text;
            if (!cpf.Equals(""))
                cpf = Convert.ToUInt64(txtCPF.Text.Replace(".", "").Replace("-", "")).ToString(@"000\.000\.000\-00");

            var client = new Client
            {
                Nome = txtNome.Text,
                CPF = cpf,
                RG = txtRG.Text,
                Endereco = txtEndereco.Text,
                Numero = Convert.ToInt16(txtNumero.Text),
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                Status = status,
                Telefone = txtTelefone.Text,
                CEP = txtCEP.Text,
                Email = txtEmail.Text,
                Estado = cmbEstado.Text,
                Observacao = txtInfoAdicional.Text,
                Id = idClient,
            };

            _clientController.Save(client, txtIdClient.Text.Equals("0") ? "new" : "edit");

            if (!_clientController.MessageError.Equals(""))
            {
                MessageBox.Show($@"Erro ao salvar cliente. {_clientController.MessageError}");
                return;
            }

            _clients.Add(client);

            txtIdClient.Text = idClient.ToString();

            MessageBox.Show(@"Salvo com sucesso!");
        }
    }
}