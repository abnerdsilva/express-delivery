using System;
using System.Linq;
using System.Windows.Forms;

namespace ExpressDelivery
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();

            CustomizeDesign();
            
            AbrirFormularios<FormDashboard>();
        }

        private void CustomizeDesign()
        {
            panelCadastros.Visible = false;
        }

        private void HideSubMenu()
        {
            if (panelCadastros.Visible)
                panelCadastros.Visible = false;
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnSair_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnCadastro_Click(object sender, System.EventArgs e)
        {
            ShowSubMenu(panelCadastros);
        }

        private void AbrirFormularios<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelHomeBody.Controls.OfType<MiForm>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;

                panelHomeBody.Controls.Add(formulario);
                panelHomeBody.Tag = formulario;
                
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void btnFormDashbord_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            AbrirFormularios<FormDashboard>();
        }

        private void btnFormCardapio_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            AbrirFormularios<FormCardapio>();
        }

        private void btnFormClientes_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            AbrirFormularios<FormClientes>();
        }

        private void btnFormUsuarios_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            AbrirFormularios<FormUsuarios>();
        }

        private void btnFormPedido_Click(object sender, EventArgs e)
        {
            HideSubMenu();
            AbrirFormularios<FormPedido>();
        }
    }
}