using System;
using System.Windows.Forms;

namespace ExpressDelivery
{
    public partial class FormPedido : Form
    {
        public FormPedido()
        {
            InitializeComponent();
        }

        private void FormPedido_Load(object sender, EventArgs e)
        {
            panelOrder.Enabled = false;
            panelClient.Enabled = true;

            ClearClient();
            ClearOrder();

            txtTelefone.Focus();
        }

        private void ClearClient()
        {
            txtIdCliente.Text = "0";
            txtNome.Text = "";
            txtDDD.Text = "19";
            txtTelefone.Text = "";
            txtCEP.Text = "";
            txtNumero.Text = "";
            txtEndereco.Text = "";
            cmbBairro.Text = "";
            txtObservacaoCliente.Text = "";
            txtTaxaEntrega.Text = "0.00";
        }

        private void ClearOrder()
        {
            txtQtde.Text = "0";
            txtCodBarras.Text = "";
            txtValorUnit.Text = "";
            txtObservacaoProduto.Text = "";
            txtVrTotalItens.Text = "";
            txtVrTroco.Text = "";
            txtVrTaxaEntrega.Text = "";
            txtVrTotalPedido.Text = "";
            txtVrTrocoPara.Text = "";
            cmbDescricaoProduto.Text = "";
            cmbFormaPagamento.Text = "";
            listProdutos.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelOrder.Enabled = false;
            panelClient.Enabled = true;

            ClearClient();
            ClearOrder();

            txtTelefone.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDataHora.Text = $@"{DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        private void VeriricaTeclaDigitadaNumero(KeyPressEventArgs e)
        {
            if (!IsNumeric(e.KeyChar.ToString()))
            {
                MessageBox.Show(@"Informe apenas números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }
        
        private static bool IsNumeric(string value)
        {
            var aimStDatachars = value.ToCharArray();

            foreach (var datachar in aimStDatachars)
            {
                if (!char.IsDigit(datachar))
                    return false;
            }

            return true;
        }
        
        private void txtDDD_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char) Keys.Enter:
                    txtTelefone.Focus();
                    break;
                case (char) Keys.Back:
                case (char) Keys.Tab:
                case (char) Keys.Delete:
                    break;
                default:
                    VeriricaTeclaDigitadaNumero(e);
                    break;
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char) Keys.Back:
                case (char) Keys.Tab:
                case (char) Keys.Delete:
                    break;
                case (char) Keys.Enter:
                    txtNome.Focus();
                    break;
                default:
                    VeriricaTeclaDigitadaNumero(e);
                    break;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) txtCEP.Focus();
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char) Keys.Enter:
                    txtNumero.Focus();
                    break;
                case (char) Keys.Back:
                case (char) Keys.Tab:
                case (char) Keys.Delete:
                    break;
                default:
                    VeriricaTeclaDigitadaNumero(e);
                    break;
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char) Keys.Enter:
                    txtEndereco.Focus();
                    break;
                case (char) Keys.Back:
                case (char) Keys.Tab:
                case (char) Keys.Delete:
                    break;
                default:
                    VeriricaTeclaDigitadaNumero(e);
                    break;
            }
        }

        private void txtEndereco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) cmbBairro.Focus();
        }

        private void cmbBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) txtObservacaoCliente.Focus();
        }

        private void txtObservacaoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) btnSalvarCliente.Focus();
        }

        private void btnSalvarCliente_Click(object sender, EventArgs e)
        {
            if(!VerificaCamposObrigatorios()) return;
            
            panelClient.Enabled = false;
            panelOrder.Enabled = true;

            txtCodBarras.Focus();
        }

        private bool VerificaCamposObrigatorios()
        {
            if (txtDDD.Text.Equals(""))
            {
                MessageBox.Show(@"Campo DDD é obrigatório", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTelefone.Text.Equals(""))
            {
                MessageBox.Show(@"Campo Telefone é obrigatório", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtNome.Text.Equals(""))
            {
                MessageBox.Show(@"Campo Nome é obrigatório", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtNumero.Text.Equals(""))
            {
                MessageBox.Show(@"Campo Número é obrigatório", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEndereco.Text.Equals(""))
            {
                MessageBox.Show(@"Campo Endereço é obrigatório", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbBairro.Text.Equals(""))
            {
                MessageBox.Show(@"Campo Bairro é obrigatório", @"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}