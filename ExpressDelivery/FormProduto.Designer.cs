using System.ComponentModel;

namespace ExpressDelivery
{
    partial class FormCardapio
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
            this.painelConsultaCardapio = new System.Windows.Forms.Panel();
            this.panelDetalheCardapio = new System.Windows.Forms.Panel();
            this.txtLocalizacaoProduto = new System.Windows.Forms.TextBox();
            this.txtMargemLucroProduto = new System.Windows.Forms.TextBox();
            this.txtObservacaoProduto = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodBarrasProduto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrecoCompraProduto = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrecoVendaProduto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCategoriaProduto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnVoltarProduto = new System.Windows.Forms.Button();
            this.btnNovoProduto = new System.Windows.Forms.Button();
            this.btnSalvarProduto = new System.Windows.Forms.Button();
            this.txtIdProduto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radioProdutoInativo = new System.Windows.Forms.RadioButton();
            this.radioProdutoAtivo = new System.Windows.Forms.RadioButton();
            this.listViewCardapio = new System.Windows.Forms.ListView();
            this.cmbTipoPesquisaCardapio = new System.Windows.Forms.ComboBox();
            this.cmbStatusPesquisaCardapio = new System.Windows.Forms.ComboBox();
            this.txtDescricaoCardapio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNovoCardapio = new System.Windows.Forms.Button();
            this.btnPesquisarCardapio = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.painelConsultaCardapio.SuspendLayout();
            this.panelDetalheCardapio.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Produto";
            // 
            // painelConsultaCardapio
            // 
            this.painelConsultaCardapio.Controls.Add(this.panelDetalheCardapio);
            this.painelConsultaCardapio.Controls.Add(this.listViewCardapio);
            this.painelConsultaCardapio.Controls.Add(this.cmbTipoPesquisaCardapio);
            this.painelConsultaCardapio.Controls.Add(this.cmbStatusPesquisaCardapio);
            this.painelConsultaCardapio.Controls.Add(this.txtDescricaoCardapio);
            this.painelConsultaCardapio.Controls.Add(this.label4);
            this.painelConsultaCardapio.Controls.Add(this.label3);
            this.painelConsultaCardapio.Controls.Add(this.btnNovoCardapio);
            this.painelConsultaCardapio.Controls.Add(this.btnPesquisarCardapio);
            this.painelConsultaCardapio.Controls.Add(this.label2);
            this.painelConsultaCardapio.Location = new System.Drawing.Point(12, 37);
            this.painelConsultaCardapio.Name = "painelConsultaCardapio";
            this.painelConsultaCardapio.Size = new System.Drawing.Size(776, 402);
            this.painelConsultaCardapio.TabIndex = 3;
            // 
            // panelDetalheCardapio
            // 
            this.panelDetalheCardapio.Controls.Add(this.txtLocalizacaoProduto);
            this.panelDetalheCardapio.Controls.Add(this.txtMargemLucroProduto);
            this.panelDetalheCardapio.Controls.Add(this.txtObservacaoProduto);
            this.panelDetalheCardapio.Controls.Add(this.label13);
            this.panelDetalheCardapio.Controls.Add(this.label11);
            this.panelDetalheCardapio.Controls.Add(this.txtCodBarrasProduto);
            this.panelDetalheCardapio.Controls.Add(this.label8);
            this.panelDetalheCardapio.Controls.Add(this.txtPrecoCompraProduto);
            this.panelDetalheCardapio.Controls.Add(this.label12);
            this.panelDetalheCardapio.Controls.Add(this.txtPrecoVendaProduto);
            this.panelDetalheCardapio.Controls.Add(this.label9);
            this.panelDetalheCardapio.Controls.Add(this.label10);
            this.panelDetalheCardapio.Controls.Add(this.txtCategoriaProduto);
            this.panelDetalheCardapio.Controls.Add(this.label7);
            this.panelDetalheCardapio.Controls.Add(this.txtNomeProduto);
            this.panelDetalheCardapio.Controls.Add(this.label6);
            this.panelDetalheCardapio.Controls.Add(this.btnVoltarProduto);
            this.panelDetalheCardapio.Controls.Add(this.btnNovoProduto);
            this.panelDetalheCardapio.Controls.Add(this.btnSalvarProduto);
            this.panelDetalheCardapio.Controls.Add(this.txtIdProduto);
            this.panelDetalheCardapio.Controls.Add(this.label5);
            this.panelDetalheCardapio.Controls.Add(this.radioProdutoInativo);
            this.panelDetalheCardapio.Controls.Add(this.radioProdutoAtivo);
            this.panelDetalheCardapio.Location = new System.Drawing.Point(0, 0);
            this.panelDetalheCardapio.Name = "panelDetalheCardapio";
            this.panelDetalheCardapio.Size = new System.Drawing.Size(776, 402);
            this.panelDetalheCardapio.TabIndex = 4;
            this.panelDetalheCardapio.Visible = false;
            // 
            // txtLocalizacaoProduto
            // 
            this.txtLocalizacaoProduto.Location = new System.Drawing.Point(445, 125);
            this.txtLocalizacaoProduto.Name = "txtLocalizacaoProduto";
            this.txtLocalizacaoProduto.Size = new System.Drawing.Size(328, 20);
            this.txtLocalizacaoProduto.TabIndex = 52;
            // 
            // txtMargemLucroProduto
            // 
            this.txtMargemLucroProduto.Location = new System.Drawing.Point(341, 161);
            this.txtMargemLucroProduto.Name = "txtMargemLucroProduto";
            this.txtMargemLucroProduto.Size = new System.Drawing.Size(177, 20);
            this.txtMargemLucroProduto.TabIndex = 51;
            // 
            // txtObservacaoProduto
            // 
            this.txtObservacaoProduto.Location = new System.Drawing.Point(3, 228);
            this.txtObservacaoProduto.Multiline = true;
            this.txtObservacaoProduto.Name = "txtObservacaoProduto";
            this.txtObservacaoProduto.Size = new System.Drawing.Size(770, 95);
            this.txtObservacaoProduto.TabIndex = 50;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 212);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 49;
            this.label13.Text = "Observação";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(375, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "Localização";
            // 
            // txtCodBarrasProduto
            // 
            this.txtCodBarrasProduto.Location = new System.Drawing.Point(86, 51);
            this.txtCodBarrasProduto.Name = "txtCodBarrasProduto";
            this.txtCodBarrasProduto.Size = new System.Drawing.Size(138, 20);
            this.txtCodBarrasProduto.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Código Barras*";
            // 
            // txtPrecoCompraProduto
            // 
            this.txtPrecoCompraProduto.Location = new System.Drawing.Point(86, 161);
            this.txtPrecoCompraProduto.Name = "txtPrecoCompraProduto";
            this.txtPrecoCompraProduto.Size = new System.Drawing.Size(168, 20);
            this.txtPrecoCompraProduto.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Preço Compra*";
            // 
            // txtPrecoVendaProduto
            // 
            this.txtPrecoVendaProduto.Location = new System.Drawing.Point(599, 161);
            this.txtPrecoVendaProduto.Name = "txtPrecoVendaProduto";
            this.txtPrecoVendaProduto.Size = new System.Drawing.Size(174, 20);
            this.txtPrecoVendaProduto.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(524, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Preço Venda";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(260, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Margem Lucro";
            // 
            // txtCategoriaProduto
            // 
            this.txtCategoriaProduto.Location = new System.Drawing.Point(86, 125);
            this.txtCategoriaProduto.Name = "txtCategoriaProduto";
            this.txtCategoriaProduto.Size = new System.Drawing.Size(283, 20);
            this.txtCategoriaProduto.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Categoria*";
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Location = new System.Drawing.Point(86, 90);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(687, 20);
            this.txtNomeProduto.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Nome*";
            // 
            // btnVoltarProduto
            // 
            this.btnVoltarProduto.Location = new System.Drawing.Point(687, 10);
            this.btnVoltarProduto.Name = "btnVoltarProduto";
            this.btnVoltarProduto.Size = new System.Drawing.Size(87, 23);
            this.btnVoltarProduto.TabIndex = 34;
            this.btnVoltarProduto.Text = "Cancelar";
            this.btnVoltarProduto.UseVisualStyleBackColor = true;
            // 
            // btnNovoProduto
            // 
            this.btnNovoProduto.Location = new System.Drawing.Point(501, 10);
            this.btnNovoProduto.Name = "btnNovoProduto";
            this.btnNovoProduto.Size = new System.Drawing.Size(87, 23);
            this.btnNovoProduto.TabIndex = 33;
            this.btnNovoProduto.Text = "Novo";
            this.btnNovoProduto.UseVisualStyleBackColor = true;
            // 
            // btnSalvarProduto
            // 
            this.btnSalvarProduto.Location = new System.Drawing.Point(594, 10);
            this.btnSalvarProduto.Name = "btnSalvarProduto";
            this.btnSalvarProduto.Size = new System.Drawing.Size(87, 23);
            this.btnSalvarProduto.TabIndex = 32;
            this.btnSalvarProduto.Text = "Salvar";
            this.btnSalvarProduto.UseVisualStyleBackColor = true;
            // 
            // txtIdProduto
            // 
            this.txtIdProduto.Enabled = false;
            this.txtIdProduto.Location = new System.Drawing.Point(64, 12);
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.Size = new System.Drawing.Size(88, 20);
            this.txtIdProduto.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "ID Cliente";
            // 
            // radioProdutoInativo
            // 
            this.radioProdutoInativo.AutoSize = true;
            this.radioProdutoInativo.Location = new System.Drawing.Point(226, 13);
            this.radioProdutoInativo.Name = "radioProdutoInativo";
            this.radioProdutoInativo.Size = new System.Drawing.Size(57, 17);
            this.radioProdutoInativo.TabIndex = 6;
            this.radioProdutoInativo.TabStop = true;
            this.radioProdutoInativo.Text = "Inativo";
            this.radioProdutoInativo.UseVisualStyleBackColor = true;
            // 
            // radioProdutoAtivo
            // 
            this.radioProdutoAtivo.AutoSize = true;
            this.radioProdutoAtivo.Location = new System.Drawing.Point(168, 13);
            this.radioProdutoAtivo.Name = "radioProdutoAtivo";
            this.radioProdutoAtivo.Size = new System.Drawing.Size(49, 17);
            this.radioProdutoAtivo.TabIndex = 5;
            this.radioProdutoAtivo.TabStop = true;
            this.radioProdutoAtivo.Text = "Ativo";
            this.radioProdutoAtivo.UseVisualStyleBackColor = true;
            // 
            // listViewCardapio
            // 
            this.listViewCardapio.Location = new System.Drawing.Point(3, 62);
            this.listViewCardapio.Name = "listViewCardapio";
            this.listViewCardapio.Size = new System.Drawing.Size(770, 335);
            this.listViewCardapio.TabIndex = 8;
            this.listViewCardapio.UseCompatibleStateImageBehavior = false;
            // 
            // cmbTipoPesquisaCardapio
            // 
            this.cmbTipoPesquisaCardapio.FormattingEnabled = true;
            this.cmbTipoPesquisaCardapio.Items.AddRange(new object[] {"Nome", "ID Cliente"});
            this.cmbTipoPesquisaCardapio.Location = new System.Drawing.Point(538, 25);
            this.cmbTipoPesquisaCardapio.Name = "cmbTipoPesquisaCardapio";
            this.cmbTipoPesquisaCardapio.Size = new System.Drawing.Size(169, 21);
            this.cmbTipoPesquisaCardapio.TabIndex = 7;
            this.cmbTipoPesquisaCardapio.Text = "Nome";
            // 
            // cmbStatusPesquisaCardapio
            // 
            this.cmbStatusPesquisaCardapio.FormattingEnabled = true;
            this.cmbStatusPesquisaCardapio.Items.AddRange(new object[] {"Ativo", "Inativo"});
            this.cmbStatusPesquisaCardapio.Location = new System.Drawing.Point(420, 25);
            this.cmbStatusPesquisaCardapio.Name = "cmbStatusPesquisaCardapio";
            this.cmbStatusPesquisaCardapio.Size = new System.Drawing.Size(112, 21);
            this.cmbStatusPesquisaCardapio.TabIndex = 6;
            this.cmbStatusPesquisaCardapio.Text = "Ativo";
            // 
            // txtDescricaoCardapio
            // 
            this.txtDescricaoCardapio.Location = new System.Drawing.Point(3, 25);
            this.txtDescricaoCardapio.Name = "txtDescricaoCardapio";
            this.txtDescricaoCardapio.Size = new System.Drawing.Size(411, 20);
            this.txtDescricaoCardapio.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(538, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Filtrar por";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Status";
            // 
            // btnNovoCardapio
            // 
            this.btnNovoCardapio.FlatAppearance.BorderSize = 0;
            this.btnNovoCardapio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoCardapio.Image = global::ExpressDelivery.Properties.Resources.add1;
            this.btnNovoCardapio.Location = new System.Drawing.Point(749, 19);
            this.btnNovoCardapio.Name = "btnNovoCardapio";
            this.btnNovoCardapio.Size = new System.Drawing.Size(24, 24);
            this.btnNovoCardapio.TabIndex = 2;
            this.btnNovoCardapio.UseVisualStyleBackColor = true;
            // 
            // btnPesquisarCardapio
            // 
            this.btnPesquisarCardapio.FlatAppearance.BorderSize = 0;
            this.btnPesquisarCardapio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarCardapio.Image = global::ExpressDelivery.Properties.Resources.search_list_black;
            this.btnPesquisarCardapio.Location = new System.Drawing.Point(713, 16);
            this.btnPesquisarCardapio.Name = "btnPesquisarCardapio";
            this.btnPesquisarCardapio.Size = new System.Drawing.Size(30, 30);
            this.btnPesquisarCardapio.TabIndex = 1;
            this.btnPesquisarCardapio.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descrição";
            // 
            // FormCardapio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.painelConsultaCardapio);
            this.Controls.Add(this.label1);
            this.Name = "FormCardapio";
            this.Text = "FormCardapio";
            this.painelConsultaCardapio.ResumeLayout(false);
            this.painelConsultaCardapio.PerformLayout();
            this.panelDetalheCardapio.ResumeLayout(false);
            this.panelDetalheCardapio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtMargemLucroProduto;
        private System.Windows.Forms.TextBox txtLocalizacaoProduto;

        private System.Windows.Forms.TextBox txtPrecoVendaProdut;
        private System.Windows.Forms.TextBox txtMargemLucroProdut;

        private System.Windows.Forms.TextBox txtPrecoCompraProduto;

        private System.Windows.Forms.TextBox txtCodBarrasProduto;

        private System.Windows.Forms.TextBox txtCodBarrasProdut;

        private System.Windows.Forms.TextBox txtObservacaoProduto;

        private System.Windows.Forms.Label label13;

        private System.Windows.Forms.TextBox txtPrecoVendaProduto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCategoriaProduto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelDetalheCardapio;
        private System.Windows.Forms.TextBox txtIdProduto;
        private System.Windows.Forms.RadioButton radioProdutoAtivo;
        private System.Windows.Forms.RadioButton radioProdutoInativo;
        private System.Windows.Forms.Button btnNovoProduto;
        private System.Windows.Forms.Button btnSalvarProduto;
        private System.Windows.Forms.Button btnVoltarProduto;
        private System.Windows.Forms.ListView listViewCardapio;
        private System.Windows.Forms.TextBox txtDescricaoCardapio;
        private System.Windows.Forms.ComboBox cmbTipoPesquisaCardapio;
        private System.Windows.Forms.Button btnPesquisarCardapio;
        private System.Windows.Forms.Button btnNovoCardapio;
        private System.Windows.Forms.ComboBox cmbStatusPesquisaCardapio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel painelConsultaCardapio;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}