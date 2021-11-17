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
            this.cmbTipoPesquisa = new System.Windows.Forms.ComboBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.cmbStatusPesquisa = new System.Windows.Forms.ComboBox();
            this.listProdutos = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelDetalheCardapio = new System.Windows.Forms.Panel();
            this.txtLocalizacao = new System.Windows.Forms.TextBox();
            this.txtMargemLucro = new System.Windows.Forms.TextBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodBarras = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrecoCompra = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrecoVenda = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnVoltarProduto = new System.Windows.Forms.Button();
            this.btnNovoProduto = new System.Windows.Forms.Button();
            this.btnSalvarProduto = new System.Windows.Forms.Button();
            this.txtIdProduto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radioProdutoInativo = new System.Windows.Forms.RadioButton();
            this.radioProdutoAtivo = new System.Windows.Forms.RadioButton();
            this.painelConsultaCardapio.SuspendLayout();
            this.panelDetalheCardapio.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Produto";
            // 
            // painelConsultaCardapio
            // 
            this.painelConsultaCardapio.Controls.Add(this.cmbTipoPesquisa);
            this.painelConsultaCardapio.Controls.Add(this.txtDescricao);
            this.painelConsultaCardapio.Controls.Add(this.cmbStatusPesquisa);
            this.painelConsultaCardapio.Controls.Add(this.listProdutos);
            this.painelConsultaCardapio.Controls.Add(this.label4);
            this.painelConsultaCardapio.Controls.Add(this.label3);
            this.painelConsultaCardapio.Controls.Add(this.btnNovo);
            this.painelConsultaCardapio.Controls.Add(this.btnPesquisar);
            this.painelConsultaCardapio.Controls.Add(this.label2);
            this.painelConsultaCardapio.Location = new System.Drawing.Point(12, 37);
            this.painelConsultaCardapio.Name = "painelConsultaCardapio";
            this.painelConsultaCardapio.Size = new System.Drawing.Size(776, 402);
            this.painelConsultaCardapio.TabIndex = 3;
            // 
            // cmbTipoPesquisa
            // 
            this.cmbTipoPesquisa.FormattingEnabled = true;
            this.cmbTipoPesquisa.Location = new System.Drawing.Point(541, 25);
            this.cmbTipoPesquisa.Name = "cmbTipoPesquisa";
            this.cmbTipoPesquisa.Size = new System.Drawing.Size(166, 21);
            this.cmbTipoPesquisa.TabIndex = 15;
            this.cmbTipoPesquisa.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(6, 25);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(403, 20);
            this.txtDescricao.TabIndex = 14;
            // 
            // cmbStatusPesquisa
            // 
            this.cmbStatusPesquisa.FormattingEnabled = true;
            this.cmbStatusPesquisa.Items.AddRange(new object[] {
            "Ativo",
            "Inativo"});
            this.cmbStatusPesquisa.Location = new System.Drawing.Point(420, 25);
            this.cmbStatusPesquisa.Name = "cmbStatusPesquisa";
            this.cmbStatusPesquisa.Size = new System.Drawing.Size(113, 21);
            this.cmbStatusPesquisa.TabIndex = 12;
            this.cmbStatusPesquisa.Text = "Ativo";
            // 
            // listProdutos
            // 
            this.listProdutos.HideSelection = false;
            this.listProdutos.Location = new System.Drawing.Point(3, 62);
            this.listProdutos.Name = "listProdutos";
            this.listProdutos.Size = new System.Drawing.Size(770, 335);
            this.listProdutos.TabIndex = 8;
            this.listProdutos.UseCompatibleStateImageBehavior = false;
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
            // btnNovo
            // 
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Image = global::ExpressDelivery.Properties.Resources.add1;
            this.btnNovo.Location = new System.Drawing.Point(749, 19);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(24, 24);
            this.btnNovo.TabIndex = 2;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descrição";
            // 
            // panelDetalheCardapio
            // 
            this.panelDetalheCardapio.Controls.Add(this.txtLocalizacao);
            this.panelDetalheCardapio.Controls.Add(this.txtMargemLucro);
            this.panelDetalheCardapio.Controls.Add(this.txtObservacao);
            this.panelDetalheCardapio.Controls.Add(this.label13);
            this.panelDetalheCardapio.Controls.Add(this.label11);
            this.panelDetalheCardapio.Controls.Add(this.txtCodBarras);
            this.panelDetalheCardapio.Controls.Add(this.label8);
            this.panelDetalheCardapio.Controls.Add(this.txtPrecoCompra);
            this.panelDetalheCardapio.Controls.Add(this.label12);
            this.panelDetalheCardapio.Controls.Add(this.txtPrecoVenda);
            this.panelDetalheCardapio.Controls.Add(this.label9);
            this.panelDetalheCardapio.Controls.Add(this.label10);
            this.panelDetalheCardapio.Controls.Add(this.txtCategoria);
            this.panelDetalheCardapio.Controls.Add(this.label7);
            this.panelDetalheCardapio.Controls.Add(this.txtNome);
            this.panelDetalheCardapio.Controls.Add(this.label6);
            this.panelDetalheCardapio.Controls.Add(this.btnVoltarProduto);
            this.panelDetalheCardapio.Controls.Add(this.btnNovoProduto);
            this.panelDetalheCardapio.Controls.Add(this.btnSalvarProduto);
            this.panelDetalheCardapio.Controls.Add(this.txtIdProduto);
            this.panelDetalheCardapio.Controls.Add(this.label5);
            this.panelDetalheCardapio.Controls.Add(this.radioProdutoInativo);
            this.panelDetalheCardapio.Controls.Add(this.radioProdutoAtivo);
            this.panelDetalheCardapio.Location = new System.Drawing.Point(12, 36);
            this.panelDetalheCardapio.Name = "panelDetalheCardapio";
            this.panelDetalheCardapio.Size = new System.Drawing.Size(776, 402);
            this.panelDetalheCardapio.TabIndex = 4;
            this.panelDetalheCardapio.Visible = false;
            // 
            // txtLocalizacao
            // 
            this.txtLocalizacao.Location = new System.Drawing.Point(445, 125);
            this.txtLocalizacao.Name = "txtLocalizacao";
            this.txtLocalizacao.Size = new System.Drawing.Size(328, 20);
            this.txtLocalizacao.TabIndex = 52;
            // 
            // txtMargemLucro
            // 
            this.txtMargemLucro.Location = new System.Drawing.Point(341, 161);
            this.txtMargemLucro.Name = "txtMargemLucro";
            this.txtMargemLucro.Size = new System.Drawing.Size(177, 20);
            this.txtMargemLucro.TabIndex = 51;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(3, 228);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(770, 95);
            this.txtObservacao.TabIndex = 50;
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
            // txtCodBarras
            // 
            this.txtCodBarras.Location = new System.Drawing.Point(86, 51);
            this.txtCodBarras.Name = "txtCodBarras";
            this.txtCodBarras.Size = new System.Drawing.Size(138, 20);
            this.txtCodBarras.TabIndex = 47;
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
            // txtPrecoCompra
            // 
            this.txtPrecoCompra.Location = new System.Drawing.Point(86, 161);
            this.txtPrecoCompra.Name = "txtPrecoCompra";
            this.txtPrecoCompra.Size = new System.Drawing.Size(168, 20);
            this.txtPrecoCompra.TabIndex = 45;
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
            // txtPrecoVenda
            // 
            this.txtPrecoVenda.Location = new System.Drawing.Point(599, 161);
            this.txtPrecoVenda.Name = "txtPrecoVenda";
            this.txtPrecoVenda.Size = new System.Drawing.Size(174, 20);
            this.txtPrecoVenda.TabIndex = 43;
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
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(86, 125);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(283, 20);
            this.txtCategoria.TabIndex = 38;
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
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(86, 90);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(687, 20);
            this.txtNome.TabIndex = 36;
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
            this.btnVoltarProduto.Click += new System.EventHandler(this.btnVoltarProduto_Click);
            // 
            // btnNovoProduto
            // 
            this.btnNovoProduto.Location = new System.Drawing.Point(501, 10);
            this.btnNovoProduto.Name = "btnNovoProduto";
            this.btnNovoProduto.Size = new System.Drawing.Size(87, 23);
            this.btnNovoProduto.TabIndex = 33;
            this.btnNovoProduto.Text = "Novo";
            this.btnNovoProduto.UseVisualStyleBackColor = true;
            this.btnNovoProduto.Click += new System.EventHandler(this.btnNovoProduto_Click);
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
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "ID Produto";
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
            // FormCardapio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.painelConsultaCardapio);
            this.Controls.Add(this.panelDetalheCardapio);
            this.Name = "FormCardapio";
            this.Text = "FormCardapio";
            this.painelConsultaCardapio.ResumeLayout(false);
            this.painelConsultaCardapio.PerformLayout();
            this.panelDetalheCardapio.ResumeLayout(false);
            this.panelDetalheCardapio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ComboBox cmbStatusPesquisa;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ListView listProdutos;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtMargemLucro;
        private System.Windows.Forms.TextBox txtLocalizacao;
        private System.Windows.Forms.TextBox txtPrecoCompra;
        private System.Windows.Forms.TextBox txtCodBarras;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPrecoVenda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelDetalheCardapio;
        private System.Windows.Forms.TextBox txtIdProduto;
        private System.Windows.Forms.RadioButton radioProdutoAtivo;
        private System.Windows.Forms.RadioButton radioProdutoInativo;
        private System.Windows.Forms.Button btnNovoProduto;
        private System.Windows.Forms.Button btnSalvarProduto;
        private System.Windows.Forms.Button btnVoltarProduto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel painelConsultaCardapio;
        private System.Windows.Forms.Label label1;

        #endregion

        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.ComboBox cmbTipoPesquisa;
    }
}