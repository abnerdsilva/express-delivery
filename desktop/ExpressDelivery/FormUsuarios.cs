using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ExpressDelivery.Controllers;
using ExpressDelivery.Models;

namespace ExpressDelivery
{
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private readonly UsuarioController _usuarioController = new UsuarioController();

        private List<Usuario> _users = new List<Usuario>();

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            listUsuarios.Clear();
            _users.Clear();

            listUsuarios.View = View.Details;
            listUsuarios.FullRowSelect = true;
            listUsuarios.GridLines = true;
            listUsuarios.LabelEdit = true;

            listUsuarios.Columns.Add("ID Produto", 80, HorizontalAlignment.Left);
            listUsuarios.Columns.Add("Usuário", 250, HorizontalAlignment.Left);
            listUsuarios.Columns.Add("Tipo Usuário", 120, HorizontalAlignment.Left);

            var statusPesquisa = cmbStatusPesquisa.Text;

            if (txtDescricaoPesquisa.Text.Equals(""))
                _users = _usuarioController.LoadAll();
            else
            {
                if (cmbTipoPesquisa.Text == "Usuário")
                    _users = _usuarioController.LoadByName(txtDescricaoPesquisa.Text);
                else
                    _users = _usuarioController.LoadById(txtDescricaoPesquisa.Text);
            }

            _users.FindAll(c => c.Status.ToUpper() == statusPesquisa.ToUpper()).ForEach(AddItemLista);
        }

        private void AddItemLista(Usuario user)
        {
            ListViewItem items = new ListViewItem(user.Id);
            items.SubItems.Add(user.Login);
            items.SubItems.Add(user.TipoUsuario);

            listUsuarios.Items.Add(items);
        }

        private void ClearDetailsUsuario()
        {
            txtIdUsuario.Text = "0";
            txtUsuario.Text = "";
            txtSenha.Text = "";
            cmbTipoUsuario.Text = "";
            txtNewPassword.Text = "";
            txtNewPasswordConfirm.Text = "";

            radioAtivo.Checked = true;
            radioInativo.Checked = false;
        }

        private void ClearSearchUsuario()
        {
            txtDescricaoPesquisa.Text = "";
            cmbStatusPesquisa.Text = "Ativo";
            cmbTipoPesquisa.Text = "Nome";

            listUsuarios.Clear();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            panelConsultaUsuario.Visible = false;
            panelCadastroUsuario.Visible = true;

            ClearDetailsUsuario();
            ClearSearchUsuario();
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            ClearDetailsUsuario();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals(""))
            {
                MessageBox.Show(@"O campo usuário é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtSenha.Text.Equals(""))
            {
                MessageBox.Show(@"O campo senha é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbTipoUsuario.Text.Equals(""))
            {
                MessageBox.Show(@"O campo tipo usuário é obrigatório.", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!txtNewPassword.Text.Equals(txtNewPasswordConfirm.Text))
            {
                MessageBox.Show(@"Senha não confere", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (txtNewPassword.Text.Equals("") && !txtIdUsuario.Text.Equals("0") && !txtIdUsuario.Text.Equals(""))
            {
                MessageBox.Show(@"Senha é obrigatório", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var status = "INATIVO";
            if (radioAtivo.Checked)
                status = "ATIVO";

            var isNewUser = txtIdUsuario.Text.Equals("") || txtIdUsuario.Text.Equals("0");

            var user = new Usuario
            {
                Id = txtIdUsuario.Text,
                Login = txtUsuario.Text,
                Senha = isNewUser ? txtSenha.Text : txtNewPassword.Text,
                SenhaAtual = txtSenha.Text,
                TipoUsuario = cmbTipoUsuario.Text,
                Status = status,
            };

            var isCreated = _usuarioController.Save(user, isNewUser ? "new" : "edit");
            if (!isCreated || !_usuarioController.MessageError.Equals(""))
            {
                MessageBox.Show($@"Erro ao salvar usuário. {_usuarioController.MessageError}");
                return;
            }

            _users = _usuarioController.LoadAll();
            ClearDetailsUsuario();

            MessageBox.Show(@"Salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            panelConsultaUsuario.Visible = true;
            panelCadastroUsuario.Visible = false;

            lblNewPassword.Visible = false;
            lblNewPasswordConfirm.Visible = false;
            txtNewPassword.Visible = false;
            txtNewPasswordConfirm.Visible = false;

            ClearDetailsUsuario();
            ClearSearchUsuario();
        }

        private void listUsuarios_DoubleClick(object sender, EventArgs e)
        {
            panelConsultaUsuario.Visible = false;
            panelCadastroUsuario.Visible = true;

            ClearDetailsUsuario();

            var idUser = listUsuarios.SelectedItems[0].SubItems[0].Text;
            var user = new Usuario();
            foreach (var c in _users)
            {
                if (c.Id != idUser) continue;
                user = c;
                break;
            }

            var password = txtNewPassword.Text;

            txtIdUsuario.Text = user.Id;
            txtUsuario.Text = user.Login;
            txtSenha.Text = password;
            cmbTipoUsuario.Text = user.TipoUsuario;

            if (!txtIdUsuario.Text.Equals("") && !txtIdUsuario.Text.Equals("0"))
            {
                lblNewPassword.Visible = true;
                lblNewPasswordConfirm.Visible = true;
                txtNewPassword.Visible = true;
                txtNewPasswordConfirm.Visible = true;
            }

            if (user.Status == "ATIVO")
                radioAtivo.Checked = true;
            else
                radioInativo.Checked = true;
        }
    }
}