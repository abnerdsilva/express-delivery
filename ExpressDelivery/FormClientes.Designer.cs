using System.ComponentModel;

namespace ExpressDelivery
{
    partial class FormClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panelConsultaCliente = new System.Windows.Forms.Panel();
            this.btnNovo = new System.Windows.Forms.Button();
            this.listClientes = new System.Windows.Forms.ListView();
            this.cmbStatusPesquisa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricaoPesquisa = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.cmbTipoPesquisa = new System.Windows.Forms.ComboBox();
            this.panelDetalheCliente = new System.Windows.Forms.Panel();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnNovoCliente = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtInfoAdicional = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdClient = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radioInativo = new System.Windows.Forms.RadioButton();
            this.radioAtivo = new System.Windows.Forms.RadioButton();
            this.panelConsultaCliente.SuspendLayout();
            this.panelDetalheCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Clientes";
            // 
            // panelConsultaCliente
            // 
            this.panelConsultaCliente.Controls.Add(this.btnNovo);
            this.panelConsultaCliente.Controls.Add(this.listClientes);
            this.panelConsultaCliente.Controls.Add(this.cmbStatusPesquisa);
            this.panelConsultaCliente.Controls.Add(this.label4);
            this.panelConsultaCliente.Controls.Add(this.label3);
            this.panelConsultaCliente.Controls.Add(this.label2);
            this.panelConsultaCliente.Controls.Add(this.txtDescricaoPesquisa);
            this.panelConsultaCliente.Controls.Add(this.btnPesquisar);
            this.panelConsultaCliente.Controls.Add(this.cmbTipoPesquisa);
            this.panelConsultaCliente.Location = new System.Drawing.Point(12, 36);
            this.panelConsultaCliente.Name = "panelConsultaCliente";
            this.panelConsultaCliente.Size = new System.Drawing.Size(776, 400);
            this.panelConsultaCliente.TabIndex = 3;
            // 
            // btnNovo
            // 
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Image = global::ExpressDelivery.Properties.Resources.add1;
            this.btnNovo.Location = new System.Drawing.Point(749, 19);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(24, 24);
            this.btnNovo.TabIndex = 8;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // listClientes
            // 
            this.listClientes.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.listClientes.HideSelection = false;
            this.listClientes.Location = new System.Drawing.Point(3, 62);
            this.listClientes.Name = "listClientes";
            this.listClientes.Size = new System.Drawing.Size(770, 335);
            this.listClientes.TabIndex = 7;
            this.listClientes.UseCompatibleStateImageBehavior = false;
            this.listClientes.DoubleClick += new System.EventHandler(this.listClientes_DoubleClick);
            // 
            // cmbStatusPesquisa
            // 
            this.cmbStatusPesquisa.FormattingEnabled = true;
            this.cmbStatusPesquisa.Items.AddRange(new object[] {"Ativo", "Inativo"});
            this.cmbStatusPesquisa.Location = new System.Drawing.Point(420, 25);
            this.cmbStatusPesquisa.Name = "cmbStatusPesquisa";
            this.cmbStatusPesquisa.Size = new System.Drawing.Size(112, 21);
            this.cmbStatusPesquisa.TabIndex = 6;
            this.cmbStatusPesquisa.Text = "Ativo";
            this.cmbStatusPesquisa.SelectedIndexChanged += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(420, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(538, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Filtrar por";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descrição";
            // 
            // txtDescricaoPesquisa
            // 
            this.txtDescricaoPesquisa.Location = new System.Drawing.Point(3, 25);
            this.txtDescricaoPesquisa.Name = "txtDescricaoPesquisa";
            this.txtDescricaoPesquisa.Size = new System.Drawing.Size(411, 20);
            this.txtDescricaoPesquisa.TabIndex = 2;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.FlatAppearance.BorderSize = 0;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Image = global::ExpressDelivery.Properties.Resources.search_list_black;
            this.btnPesquisar.Location = new System.Drawing.Point(713, 16);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(30, 30);
            this.btnPesquisar.TabIndex = 1;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // cmbTipoPesquisa
            // 
            this.cmbTipoPesquisa.FormattingEnabled = true;
            this.cmbTipoPesquisa.Items.AddRange(new object[] {"Nome", "ID Cliente"});
            this.cmbTipoPesquisa.Location = new System.Drawing.Point(538, 25);
            this.cmbTipoPesquisa.Name = "cmbTipoPesquisa";
            this.cmbTipoPesquisa.Size = new System.Drawing.Size(169, 21);
            this.cmbTipoPesquisa.TabIndex = 0;
            this.cmbTipoPesquisa.Text = "Nome";
            // 
            // panelDetalheCliente
            // 
            this.panelDetalheCliente.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetalheCliente.Controls.Add(this.btnVoltar);
            this.panelDetalheCliente.Controls.Add(this.btnNovoCliente);
            this.panelDetalheCliente.Controls.Add(this.btnSalvar);
            this.panelDetalheCliente.Controls.Add(this.txtInfoAdicional);
            this.panelDetalheCliente.Controls.Add(this.label17);
            this.panelDetalheCliente.Controls.Add(this.txtEmail);
            this.panelDetalheCliente.Controls.Add(this.label15);
            this.panelDetalheCliente.Controls.Add(this.txtTelefone);
            this.panelDetalheCliente.Controls.Add(this.label16);
            this.panelDetalheCliente.Controls.Add(this.cmbEstado);
            this.panelDetalheCliente.Controls.Add(this.label14);
            this.panelDetalheCliente.Controls.Add(this.txtCEP);
            this.panelDetalheCliente.Controls.Add(this.label12);
            this.panelDetalheCliente.Controls.Add(this.txtCidade);
            this.panelDetalheCliente.Controls.Add(this.label13);
            this.panelDetalheCliente.Controls.Add(this.txtBairro);
            this.panelDetalheCliente.Controls.Add(this.label11);
            this.panelDetalheCliente.Controls.Add(this.txtNumero);
            this.panelDetalheCliente.Controls.Add(this.label9);
            this.panelDetalheCliente.Controls.Add(this.txtEndereco);
            this.panelDetalheCliente.Controls.Add(this.label10);
            this.panelDetalheCliente.Controls.Add(this.txtRG);
            this.panelDetalheCliente.Controls.Add(this.label8);
            this.panelDetalheCliente.Controls.Add(this.txtCPF);
            this.panelDetalheCliente.Controls.Add(this.label7);
            this.panelDetalheCliente.Controls.Add(this.txtNome);
            this.panelDetalheCliente.Controls.Add(this.label6);
            this.panelDetalheCliente.Controls.Add(this.txtIdClient);
            this.panelDetalheCliente.Controls.Add(this.label5);
            this.panelDetalheCliente.Controls.Add(this.radioInativo);
            this.panelDetalheCliente.Controls.Add(this.radioAtivo);
            this.panelDetalheCliente.Location = new System.Drawing.Point(12, 37);
            this.panelDetalheCliente.Name = "panelDetalheCliente";
            this.panelDetalheCliente.Size = new System.Drawing.Size(776, 399);
            this.panelDetalheCliente.TabIndex = 9;
            this.panelDetalheCliente.Visible = false;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(686, 7);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(87, 23);
            this.btnVoltar.TabIndex = 31;
            this.btnVoltar.Text = "Cancelar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click_1);
            // 
            // btnNovoCliente
            // 
            this.btnNovoCliente.Location = new System.Drawing.Point(500, 7);
            this.btnNovoCliente.Name = "btnNovoCliente";
            this.btnNovoCliente.Size = new System.Drawing.Size(87, 23);
            this.btnNovoCliente.TabIndex = 30;
            this.btnNovoCliente.Text = "Novo";
            this.btnNovoCliente.UseVisualStyleBackColor = true;
            this.btnNovoCliente.Click += new System.EventHandler(this.btnNovoCliente_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(593, 7);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(87, 23);
            this.btnSalvar.TabIndex = 29;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtInfoAdicional
            // 
            this.txtInfoAdicional.Location = new System.Drawing.Point(3, 292);
            this.txtInfoAdicional.Multiline = true;
            this.txtInfoAdicional.Name = "txtInfoAdicional";
            this.txtInfoAdicional.Size = new System.Drawing.Size(770, 105);
            this.txtInfoAdicional.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 276);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(115, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "Informações adicionais";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(281, 233);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(492, 20);
            this.txtEmail.TabIndex = 26;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(243, 236);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "Email";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(62, 233);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(175, 20);
            this.txtTelefone.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 236);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Telefone*";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {"AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"});
            this.cmbEstado.Location = new System.Drawing.Point(420, 197);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(353, 21);
            this.cmbEstado.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(370, 200);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Estado*";
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(62, 121);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(93, 20);
            this.txtCEP.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "CEP*";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(62, 197);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(302, 20);
            this.txtCidade.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Cidade*";
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(62, 159);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(711, 20);
            this.txtBairro.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Bairro*";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(701, 121);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(72, 20);
            this.txtNumero.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(651, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Número*";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(224, 121);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(421, 20);
            this.txtEndereco.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(165, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Endereço*";
            // 
            // txtRG
            // 
            this.txtRG.Location = new System.Drawing.Point(443, 85);
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(330, 20);
            this.txtRG.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(411, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "RG";
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(62, 85);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(343, 20);
            this.txtCPF.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "CPF*";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(62, 49);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(711, 20);
            this.txtNome.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nome*";
            // 
            // txtIdClient
            // 
            this.txtIdClient.Enabled = false;
            this.txtIdClient.Location = new System.Drawing.Point(62, 10);
            this.txtIdClient.Name = "txtIdClient";
            this.txtIdClient.Size = new System.Drawing.Size(88, 20);
            this.txtIdClient.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "ID Cliente";
            // 
            // radioInativo
            // 
            this.radioInativo.AutoSize = true;
            this.radioInativo.Location = new System.Drawing.Point(224, 11);
            this.radioInativo.Name = "radioInativo";
            this.radioInativo.Size = new System.Drawing.Size(57, 17);
            this.radioInativo.TabIndex = 2;
            this.radioInativo.TabStop = true;
            this.radioInativo.Text = "Inativo";
            this.radioInativo.UseVisualStyleBackColor = true;
            // 
            // radioAtivo
            // 
            this.radioAtivo.AutoSize = true;
            this.radioAtivo.Location = new System.Drawing.Point(166, 11);
            this.radioAtivo.Name = "radioAtivo";
            this.radioAtivo.Size = new System.Drawing.Size(49, 17);
            this.radioAtivo.TabIndex = 1;
            this.radioAtivo.TabStop = true;
            this.radioAtivo.Text = "Ativo";
            this.radioAtivo.UseVisualStyleBackColor = true;
            // 
            // FormClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 447);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelDetalheCliente);
            this.Controls.Add(this.panelConsultaCliente);
            this.Name = "FormClientes";
            this.Text = "FormClientes";
            this.panelConsultaCliente.ResumeLayout(false);
            this.panelConsultaCliente.PerformLayout();
            this.panelDetalheCliente.ResumeLayout(false);
            this.panelDetalheCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListView listClientes;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStatusPesquisa;

        private System.Windows.Forms.TextBox txtDescricaoPesquisa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoPesquisa;
        private System.Windows.Forms.Button btnPesquisar;

        private System.Windows.Forms.Panel panelConsultaCliente;

        private System.Windows.Forms.Label label1;

        #endregion

        private System.Windows.Forms.Panel panelDetalheCliente;
        private System.Windows.Forms.Button btnNovoCliente;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtInfoAdicional;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioInativo;
        private System.Windows.Forms.RadioButton radioAtivo;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnVoltar;
    }
}