using System;
using System.Windows.Forms;
using ExpressDelivery.Controllers;

namespace ExpressDelivery
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtLoginUsuario.Text == "" || txtLoginSenha.Text == "")
            {
                txtLoginSenha.Focus();
                MessageBox.Show(@"Usuário e/ou senha inválido(s)", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GeraLog.PrintError("Usuário e/ou senha inválido(s)");
                return;
            }

            LoginController controle = new LoginController();
            var usuario = controle.Acessar(txtLoginUsuario.Text, txtLoginSenha.Text).Result;
            if (usuario == null || controle.Message != "")
            {
                MessageBox.Show(controle.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GeraLog.PrintError(controle.Message);
                return;
            }

            Hide();
            Form f = new FormHome(usuario);
            f.Closed += (s, args) => Close();
            f.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtLoginSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) btnEntrar.Focus();
        }

        private void txtLoginUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) txtLoginSenha.Focus();
        }
    }
}