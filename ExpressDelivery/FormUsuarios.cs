using ExpressDelivery.Controllers;
using ExpressDelivery.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

        private void btnPesquisar_Click(object sender, System.EventArgs e)
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

            var statusPesquisa = 0;
            if (cmbStatusPesquisa.Text == "Ativo")
                statusPesquisa = 1;

            if (txtDescricaoPesquisa.Text.Equals(""))
                _users = _usuarioController.LoadAll();
            else
            {
                if (cmbTipoPesquisa.Text == "Usuário")
                    _users = _usuarioController.LoadByName(txtDescricaoPesquisa.Text);
                else
                    _users = _usuarioController.LoadById(txtDescricaoPesquisa.Text);
            }

            _users.FindAll(c => c.Status == statusPesquisa).ForEach(AddItemLista);
        }

        private void AddItemLista(Usuario user)
        {
            ListViewItem items = new ListViewItem(user.Id.ToString());
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

        private void btnNovo_Click(object sender, System.EventArgs e)
        {
            panelConsultaUsuario.Visible = false;
            panelCadastroUsuario.Visible = true;

            ClearDetailsUsuario();
            ClearSearchUsuario();
        }

        private void btnNovoUsuario_Click(object sender, System.EventArgs e)
        {
            ClearDetailsUsuario();
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
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
                MessageBox.Show(@"O campo tipo usuário é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var status = 0;
            if (radioAtivo.Checked)
                status = 1;

            var idUser = _usuarioController.LastUserId() + 1;
            if (!txtIdUsuario.Text.Equals("0"))
                idUser = Convert.ToInt16(txtIdUsuario.Text);

            var user = new Usuario
            {
                Id = idUser,
                Login = txtUsuario.Text,
                Senha = txtSenha.Text,
                TipoUsuario = cmbTipoUsuario.Text,
                Status = status,
            };

            _usuarioController.Save(user, txtIdUsuario.Text.Equals("0") ? "new" : "edit");

            if (!_usuarioController.MessageError.Equals(""))
            {
                MessageBox.Show($@"Erro ao salvar usuário. {_usuarioController.MessageError}");
                return;
            }

            _users.Add(user);

            txtIdUsuario.Text = idUser.ToString();

            MessageBox.Show(@"Salvo com sucesso!");
        }

        private void btnVoltar_Click(object sender, System.EventArgs e)
        {
            panelConsultaUsuario.Visible = true;
            panelCadastroUsuario.Visible = false;

            ClearDetailsUsuario();
            ClearSearchUsuario();
        }

        private void listUsuarios_DoubleClick(object sender, System.EventArgs e)
        {
            panelConsultaUsuario.Visible = false;
            panelCadastroUsuario.Visible = true;

            ClearDetailsUsuario();

            var idUser = listUsuarios.SelectedItems[0].SubItems[0].Text;
            var user = new Usuario();
            foreach (var c in _users)
            {
                if (c.Id != int.Parse(idUser)) continue;
                user = c;
                break;
            }

            txtIdUsuario.Text = user.Id.ToString();
            txtUsuario.Text = user.Login;
            txtSenha.Text = user.Senha;
            cmbTipoUsuario.Text = user.TipoUsuario;

            if (user.Status == 1)
                radioAtivo.Checked = true;
            else
                radioInativo.Checked = true;
        }
    }
}