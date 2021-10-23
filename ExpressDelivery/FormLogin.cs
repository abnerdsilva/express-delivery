using System;
using System.Windows.Forms;

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
                MessageBox.Show("Usuário e/ou senha inválido(s)", "Alerta!");
                return;
            }

            Hide();
            Form f = new FormHome();
            f.Closed += (s, args) => Close();
            f.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}