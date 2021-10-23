using System.Windows.Forms;

namespace ExpressDelivery
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();

            CustomizeDesign();
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
    }
}