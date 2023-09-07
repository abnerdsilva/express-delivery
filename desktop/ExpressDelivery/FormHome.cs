using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpressDelivery.Models;

namespace ExpressDelivery
{
    public partial class FormHome : Form
    {
        private Usuario _usuario;
        
        public FormHome(Task<Usuario> usuario)
        {
            InitializeComponent();

            CustomizeDesign();
            
            _usuario = usuario.Result;
        }

        private void CustomizeDesign()
        {
            // panelCadastros.Visible = false;
        }

        private void btnSair_Click(object sender, System.EventArgs e)
        {
            Close();
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
            AbrirFormularios<FormDashboard>();
        }

        private void btnFormCardapio_Click(object sender, EventArgs e)
        {
            AbrirFormularios<FormCardapio>();
        }

        private void btnFormClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularios<FormClientes>();
        }

        private void btnFormUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularios<FormUsuarios>();
        }

        private void btnFormPedido_Click(object sender, EventArgs e)
        {
            AbrirFormularios<FormPedido>();
            FormPedido.User = _usuario;
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            lbl_idOperador.Text = _usuario.Id;
            lbl_idOperador.Visible = false;
            
            if (_usuario.TipoUsuario.Equals("COMUM"))
            {
                // btnCadastro.Visible = false;
                btnFormDashbord.Visible = false;
                btnFormCardapio.Visible = false;
                btnFormUsuarios.Visible = false;
                btnFormClientes.Visible = false;
                // panelCadastros.Visible = false;

                AbrirFormularios<FormPedido>();
                FormPedido.User = _usuario;
            }
            else
                AbrirFormularios<FormDashboard>();
        }
    }
}