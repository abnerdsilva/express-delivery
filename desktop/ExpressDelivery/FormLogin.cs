using System;
using System.Windows.Forms;
using ExpressDelivery.Controllers;

namespace ExpressDelivery
{
    public partial class FormLogin : Form
    {
        private readonly LoginController _loginController = new LoginController();
        private readonly PrivacyController _privacyController = new PrivacyController();

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

            var usuario = _loginController.Acessar(txtLoginUsuario.Text, txtLoginSenha.Text).Result;
            if (usuario == null || _loginController.Message != "")
            {
                MessageBox.Show(_loginController.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GeraLog.PrintError(_loginController.Message);
                return;
            }

            var hasPrivacy = _privacyController.HasPrivacy().Result;
            if (!hasPrivacy)
            {
                using (var formPolitica = new FormPolitica())
                {
                    formPolitica.User = usuario.Id;
                    formPolitica.ShowDialog();

                    if (!formPolitica.IsPrivacyAccept)
                    {
                        return;
                    }
                }
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
            if (e.KeyChar == (char)Keys.Enter) btnEntrar.Focus();
        }

        private void txtLoginUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) txtLoginSenha.Focus();
        }
    }
}