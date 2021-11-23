using System.ComponentModel;

namespace ExpressDelivery
{
    partial class FormUsuarios
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelConsultaUsuario = new System.Windows.Forms.Panel();
            this.btnNovo = new System.Windows.Forms.Button();
            this.listUsuarios = new System.Windows.Forms.ListView();
            this.cmbStatusPesquisa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricaoPesquisa = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.cmbTipoPesquisa = new System.Windows.Forms.ComboBox();
            this.panelCadastroUsuario = new System.Windows.Forms.Panel();
            this.cmbTipoUsuario = new System.Windows.Forms.ComboBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnNovoUsuario = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radioInativo = new System.Windows.Forms.RadioButton();
            this.radioAtivo = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panelConsultaUsuario.SuspendLayout();
            this.panelCadastroUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuários";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 63);
            this.panel1.TabIndex = 3;
            // 
            // panelConsultaUsuario
            // 
            this.panelConsultaUsuario.Controls.Add(this.btnNovo);
            this.panelConsultaUsuario.Controls.Add(this.listUsuarios);
            this.panelConsultaUsuario.Controls.Add(this.cmbStatusPesquisa);
            this.panelConsultaUsuario.Controls.Add(this.label4);
            this.panelConsultaUsuario.Controls.Add(this.label3);
            this.panelConsultaUsuario.Controls.Add(this.label2);
            this.panelConsultaUsuario.Controls.Add(this.txtDescricaoPesquisa);
            this.panelConsultaUsuario.Controls.Add(this.btnPesquisar);
            this.panelConsultaUsuario.Controls.Add(this.cmbTipoPesquisa);
            this.panelConsultaUsuario.Location = new System.Drawing.Point(12, 69);
            this.panelConsultaUsuario.Name = "panelConsultaUsuario";
            this.panelConsultaUsuario.Size = new System.Drawing.Size(768, 572);
            this.panelConsultaUsuario.TabIndex = 4;
            // 
            // btnNovo
            // 
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Image = global::ExpressDelivery.Properties.Resources.add1;
            this.btnNovo.Location = new System.Drawing.Point(736, 19);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(24, 24);
            this.btnNovo.TabIndex = 17;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // listUsuarios
            // 
            this.listUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listUsuarios.HideSelection = false;
            this.listUsuarios.Location = new System.Drawing.Point(3, 52);
            this.listUsuarios.Name = "listUsuarios";
            this.listUsuarios.Size = new System.Drawing.Size(759, 476);
            this.listUsuarios.TabIndex = 16;
            this.listUsuarios.UseCompatibleStateImageBehavior = false;
            this.listUsuarios.DoubleClick += new System.EventHandler(this.listUsuarios_DoubleClick);
            // 
            // cmbStatusPesquisa
            // 
            this.cmbStatusPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatusPesquisa.FormattingEnabled = true;
            this.cmbStatusPesquisa.Items.AddRange(new object[] {
            "Ativo",
            "Inativo"});
            this.cmbStatusPesquisa.Location = new System.Drawing.Point(423, 22);
            this.cmbStatusPesquisa.Name = "cmbStatusPesquisa";
            this.cmbStatusPesquisa.Size = new System.Drawing.Size(112, 24);
            this.cmbStatusPesquisa.TabIndex = 15;
            this.cmbStatusPesquisa.Text = "Ativo";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(423, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(541, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Filtrar por";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Descrição";
            // 
            // txtDescricaoPesquisa
            // 
            this.txtDescricaoPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoPesquisa.Location = new System.Drawing.Point(6, 24);
            this.txtDescricaoPesquisa.Name = "txtDescricaoPesquisa";
            this.txtDescricaoPesquisa.Size = new System.Drawing.Size(411, 22);
            this.txtDescricaoPesquisa.TabIndex = 11;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.FlatAppearance.BorderSize = 0;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Image = global::ExpressDelivery.Properties.Resources.search_list_black;
            this.btnPesquisar.Location = new System.Drawing.Point(700, 16);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(30, 30);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // cmbTipoPesquisa
            // 
            this.cmbTipoPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoPesquisa.FormattingEnabled = true;
            this.cmbTipoPesquisa.Items.AddRange(new object[] {
            "Usuário",
            "ID Usuário"});
            this.cmbTipoPesquisa.Location = new System.Drawing.Point(541, 22);
            this.cmbTipoPesquisa.Name = "cmbTipoPesquisa";
            this.cmbTipoPesquisa.Size = new System.Drawing.Size(153, 24);
            this.cmbTipoPesquisa.TabIndex = 9;
            this.cmbTipoPesquisa.Text = "Usuário";
            // 
            // panelCadastroUsuario
            // 
            this.panelCadastroUsuario.Controls.Add(this.cmbTipoUsuario);
            this.panelCadastroUsuario.Controls.Add(this.btnVoltar);
            this.panelCadastroUsuario.Controls.Add(this.btnNovoUsuario);
            this.panelCadastroUsuario.Controls.Add(this.btnSalvar);
            this.panelCadastroUsuario.Controls.Add(this.label11);
            this.panelCadastroUsuario.Controls.Add(this.txtSenha);
            this.panelCadastroUsuario.Controls.Add(this.label7);
            this.panelCadastroUsuario.Controls.Add(this.txtUsuario);
            this.panelCadastroUsuario.Controls.Add(this.label6);
            this.panelCadastroUsuario.Controls.Add(this.txtIdUsuario);
            this.panelCadastroUsuario.Controls.Add(this.label5);
            this.panelCadastroUsuario.Controls.Add(this.radioInativo);
            this.panelCadastroUsuario.Controls.Add(this.radioAtivo);
            this.panelCadastroUsuario.Location = new System.Drawing.Point(12, 69);
            this.panelCadastroUsuario.Name = "panelCadastroUsuario";
            this.panelCadastroUsuario.Size = new System.Drawing.Size(768, 609);
            this.panelCadastroUsuario.TabIndex = 5;
            this.panelCadastroUsuario.Visible = false;
            // 
            // cmbTipoUsuario
            // 
            this.cmbTipoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoUsuario.FormattingEnabled = true;
            this.cmbTipoUsuario.Items.AddRange(new object[] {
            "ADMIN",
            "COMUM"});
            this.cmbTipoUsuario.Location = new System.Drawing.Point(6, 179);
            this.cmbTipoUsuario.Name = "cmbTipoUsuario";
            this.cmbTipoUsuario.Size = new System.Drawing.Size(220, 24);
            this.cmbTipoUsuario.TabIndex = 50;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(675, 8);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(87, 23);
            this.btnVoltar.TabIndex = 49;
            this.btnVoltar.Text = "Cancelar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnNovoUsuario
            // 
            this.btnNovoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoUsuario.Location = new System.Drawing.Point(489, 8);
            this.btnNovoUsuario.Name = "btnNovoUsuario";
            this.btnNovoUsuario.Size = new System.Drawing.Size(87, 23);
            this.btnNovoUsuario.TabIndex = 48;
            this.btnNovoUsuario.Text = "Novo";
            this.btnNovoUsuario.UseVisualStyleBackColor = true;
            this.btnNovoUsuario.Click += new System.EventHandler(this.btnNovoUsuario_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(582, 8);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(87, 23);
            this.btnSalvar.TabIndex = 47;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 16);
            this.label11.TabIndex = 46;
            this.label11.Text = "Tipo Usuário";
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(6, 124);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(388, 22);
            this.txtSenha.TabIndex = 39;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 38;
            this.label7.Text = "Senha*";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(6, 71);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(388, 22);
            this.txtUsuario.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Usuário*";
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Enabled = false;
            this.txtIdUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdUsuario.Location = new System.Drawing.Point(77, 7);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(88, 22);
            this.txtIdUsuario.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "ID Usuário";
            // 
            // radioInativo
            // 
            this.radioInativo.AutoSize = true;
            this.radioInativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioInativo.Location = new System.Drawing.Point(242, 9);
            this.radioInativo.Name = "radioInativo";
            this.radioInativo.Size = new System.Drawing.Size(65, 20);
            this.radioInativo.TabIndex = 33;
            this.radioInativo.TabStop = true;
            this.radioInativo.Text = "Inativo";
            this.radioInativo.UseVisualStyleBackColor = true;
            // 
            // radioAtivo
            // 
            this.radioAtivo.AutoSize = true;
            this.radioAtivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAtivo.Location = new System.Drawing.Point(184, 9);
            this.radioAtivo.Name = "radioAtivo";
            this.radioAtivo.Size = new System.Drawing.Size(56, 20);
            this.radioAtivo.TabIndex = 32;
            this.radioAtivo.TabStop = true;
            this.radioAtivo.Text = "Ativo";
            this.radioAtivo.UseVisualStyleBackColor = true;
            // 
            // FormUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 690);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelConsultaUsuario);
            this.Controls.Add(this.panelCadastroUsuario);
            this.Name = "FormUsuarios";
            this.Text = "FormUsuarios";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelConsultaUsuario.ResumeLayout(false);
            this.panelConsultaUsuario.PerformLayout();
            this.panelCadastroUsuario.ResumeLayout(false);
            this.panelCadastroUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label label1;

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelConsultaUsuario;
        private System.Windows.Forms.Panel panelCadastroUsuario;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ListView listUsuarios;
        private System.Windows.Forms.ComboBox cmbStatusPesquisa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricaoPesquisa;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.ComboBox cmbTipoPesquisa;
        private System.Windows.Forms.ComboBox cmbTipoUsuario;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnNovoUsuario;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioInativo;
        private System.Windows.Forms.RadioButton radioAtivo;
    }
}