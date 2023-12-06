using System;
using System.Windows.Forms;
using ExpressDelivery.Controllers;

namespace ExpressDelivery
{
    public partial class FormPolitica : Form
    {
        private readonly PrivacyController _privacyController = new PrivacyController();

        public FormPolitica()
        {
            InitializeComponent();
        }

        public bool IsPrivacyAccept = false;
        public string User = "";

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://abnerdsilva.github.io/express-delivery/");
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            // var isSaved = _privacyController.AddPrivacy(User).Result;
            // if (isSaved)
            // {
            //     IsPrivacyAccept = true;
            //     Close();
            // }
            
            IsPrivacyAccept = true;
            Close();
        }
    }
}