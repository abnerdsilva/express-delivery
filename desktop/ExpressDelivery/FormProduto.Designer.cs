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
            this.label8 = new System.Windows.Forms.Label();
            this.cmbUnMedida = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtLocalizacao = new System.Windows.Forms.TextBox();
            this.txtMargemLucro = new System.Windows.Forms.TextBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodBarras = new System.Windows.Forms.TextBox();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_loading_produto = new System.Windows.Forms.Label();
            this.painelConsultaCardapio.SuspendLayout();
            this.panelDetalheCardapio.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
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
            this.painelConsultaCardapio.Location = new System.Drawing.Point(9, 69);
            this.painelConsultaCardapio.Name = "painelConsultaCardapio";
            this.painelConsultaCardapio.Size = new System.Drawing.Size(776, 517);
            this.painelConsultaCardapio.TabIndex = 3;
            // 
            // cmbTipoPesquisa
            // 
            this.cmbTipoPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmbTipoPesquisa.FormattingEnabled = true;
            this.cmbTipoPesquisa.Items.AddRange(new object[] {"Descrição", "ID Produto"});
            this.cmbTipoPesquisa.Location = new System.Drawing.Point(541, 25);
            this.cmbTipoPesquisa.Name = "cmbTipoPesquisa";
            this.cmbTipoPesquisa.Size = new System.Drawing.Size(166, 24);
            this.cmbTipoPesquisa.TabIndex = 15;
            this.cmbTipoPesquisa.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtDescricao.Location = new System.Drawing.Point(6, 25);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(403, 22);
            this.txtDescricao.TabIndex = 14;
            // 
            // cmbStatusPesquisa
            // 
            this.cmbStatusPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmbStatusPesquisa.FormattingEnabled = true;
            this.cmbStatusPesquisa.Items.AddRange(new object[] {"Ativo", "Inativo"});
            this.cmbStatusPesquisa.Location = new System.Drawing.Point(420, 25);
            this.cmbStatusPesquisa.Name = "cmbStatusPesquisa";
            this.cmbStatusPesquisa.Size = new System.Drawing.Size(113, 24);
            this.cmbStatusPesquisa.TabIndex = 12;
            this.cmbStatusPesquisa.Text = "Ativo";
            // 
            // listProdutos
            // 
            this.listProdutos.HideSelection = false;
            this.listProdutos.Location = new System.Drawing.Point(3, 62);
            this.listProdutos.Name = "listProdutos";
            this.listProdutos.Size = new System.Drawing.Size(770, 452);
            this.listProdutos.TabIndex = 8;
            this.listProdutos.UseCompatibleStateImageBehavior = false;
            this.listProdutos.DoubleClick += new System.EventHandler(this.listProdutos_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.Location = new System.Drawing.Point(538, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Filtrar por";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(417, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
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
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descrição";
            // 
            // panelDetalheCardapio
            // 
            this.panelDetalheCardapio.Controls.Add(this.label8);
            this.panelDetalheCardapio.Controls.Add(this.cmbUnMedida);
            this.panelDetalheCardapio.Controls.Add(this.label14);
            this.panelDetalheCardapio.Controls.Add(this.txtLocalizacao);
            this.panelDetalheCardapio.Controls.Add(this.txtMargemLucro);
            this.panelDetalheCardapio.Controls.Add(this.txtObservacao);
            this.panelDetalheCardapio.Controls.Add(this.label13);
            this.panelDetalheCardapio.Controls.Add(this.label11);
            this.panelDetalheCardapio.Controls.Add(this.txtCodBarras);
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
            this.panelDetalheCardapio.Location = new System.Drawing.Point(9, 69);
            this.panelDetalheCardapio.Name = "panelDetalheCardapio";
            this.panelDetalheCardapio.Size = new System.Drawing.Size(776, 568);
            this.panelDetalheCardapio.TabIndex = 4;
            this.panelDetalheCardapio.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label8.Location = new System.Drawing.Point(6, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 46;
            this.label8.Text = "Código Barras*";
            // 
            // cmbUnMedida
            // 
            this.cmbUnMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmbUnMedida.FormattingEnabled = true;
            this.cmbUnMedida.Items.AddRange(new object[] {"UN", "KG"});
            this.cmbUnMedida.Location = new System.Drawing.Point(637, 126);
            this.cmbUnMedida.Name = "cmbUnMedida";
            this.cmbUnMedida.Size = new System.Drawing.Size(136, 24);
            this.cmbUnMedida.TabIndex = 54;
            this.cmbUnMedida.Text = "UN";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label14.Location = new System.Drawing.Point(634, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 16);
            this.label14.TabIndex = 53;
            this.label14.Text = "UN Medida*";
            // 
            // txtLocalizacao
            // 
            this.txtLocalizacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtLocalizacao.Location = new System.Drawing.Point(314, 180);
            this.txtLocalizacao.Name = "txtLocalizacao";
            this.txtLocalizacao.Size = new System.Drawing.Size(459, 22);
            this.txtLocalizacao.TabIndex = 52;
            // 
            // txtMargemLucro
            // 
            this.txtMargemLucro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtMargemLucro.Location = new System.Drawing.Point(203, 241);
            this.txtMargemLucro.Name = "txtMargemLucro";
            this.txtMargemLucro.Size = new System.Drawing.Size(177, 22);
            this.txtMargemLucro.TabIndex = 51;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtObservacao.Location = new System.Drawing.Point(12, 305);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(762, 95);
            this.txtObservacao.TabIndex = 50;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label13.Location = new System.Drawing.Point(9, 286);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 16);
            this.label13.TabIndex = 49;
            this.label13.Text = "Observação";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label11.Location = new System.Drawing.Point(311, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 16);
            this.label11.TabIndex = 48;
            this.label11.Text = "Localização";
            // 
            // txtCodBarras
            // 
            this.txtCodBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtCodBarras.Location = new System.Drawing.Point(9, 73);
            this.txtCodBarras.Name = "txtCodBarras";
            this.txtCodBarras.Size = new System.Drawing.Size(206, 22);
            this.txtCodBarras.TabIndex = 47;
            // 
            // txtPrecoCompra
            // 
            this.txtPrecoCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtPrecoCompra.Location = new System.Drawing.Point(11, 241);
            this.txtPrecoCompra.Name = "txtPrecoCompra";
            this.txtPrecoCompra.Size = new System.Drawing.Size(168, 22);
            this.txtPrecoCompra.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label12.Location = new System.Drawing.Point(8, 222);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 16);
            this.label12.TabIndex = 44;
            this.label12.Text = "Preço Compra*";
            // 
            // txtPrecoVenda
            // 
            this.txtPrecoVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtPrecoVenda.Location = new System.Drawing.Point(401, 241);
            this.txtPrecoVenda.Name = "txtPrecoVenda";
            this.txtPrecoVenda.Size = new System.Drawing.Size(174, 22);
            this.txtPrecoVenda.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label9.Location = new System.Drawing.Point(398, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 16);
            this.label9.TabIndex = 42;
            this.label9.Text = "Preço Venda";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label10.Location = new System.Drawing.Point(200, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 16);
            this.label10.TabIndex = 40;
            this.label10.Text = "Margem Lucro";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtCategoria.Location = new System.Drawing.Point(11, 180);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(283, 22);
            this.txtCategoria.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label7.Location = new System.Drawing.Point(8, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "Categoria*";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtNome.Location = new System.Drawing.Point(11, 126);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(607, 22);
            this.txtNome.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label6.Location = new System.Drawing.Point(8, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 35;
            this.label6.Text = "Nome*";
            // 
            // btnVoltarProduto
            // 
            this.btnVoltarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
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
            this.btnNovoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
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
            this.btnSalvarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnSalvarProduto.Location = new System.Drawing.Point(594, 10);
            this.btnSalvarProduto.Name = "btnSalvarProduto";
            this.btnSalvarProduto.Size = new System.Drawing.Size(87, 23);
            this.btnSalvarProduto.TabIndex = 32;
            this.btnSalvarProduto.Text = "Salvar";
            this.btnSalvarProduto.UseVisualStyleBackColor = true;
            this.btnSalvarProduto.Click += new System.EventHandler(this.btnSalvarProduto_Click);
            // 
            // txtIdProduto
            // 
            this.txtIdProduto.Enabled = false;
            this.txtIdProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtIdProduto.Location = new System.Drawing.Point(79, 12);
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.Size = new System.Drawing.Size(88, 22);
            this.txtIdProduto.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.Location = new System.Drawing.Point(5, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "ID Produto";
            // 
            // radioProdutoInativo
            // 
            this.radioProdutoInativo.AutoSize = true;
            this.radioProdutoInativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.radioProdutoInativo.Location = new System.Drawing.Point(243, 14);
            this.radioProdutoInativo.Name = "radioProdutoInativo";
            this.radioProdutoInativo.Size = new System.Drawing.Size(65, 20);
            this.radioProdutoInativo.TabIndex = 6;
            this.radioProdutoInativo.TabStop = true;
            this.radioProdutoInativo.Text = "Inativo";
            this.radioProdutoInativo.UseVisualStyleBackColor = true;
            // 
            // radioProdutoAtivo
            // 
            this.radioProdutoAtivo.AutoSize = true;
            this.radioProdutoAtivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.radioProdutoAtivo.Location = new System.Drawing.Point(185, 14);
            this.radioProdutoAtivo.Name = "radioProdutoAtivo";
            this.radioProdutoAtivo.Size = new System.Drawing.Size(56, 20);
            this.radioProdutoAtivo.TabIndex = 5;
            this.radioProdutoAtivo.TabStop = true;
            this.radioProdutoAtivo.Text = "Ativo";
            this.radioProdutoAtivo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_loading_produto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 63);
            this.panel1.TabIndex = 5;
            // 
            // lbl_loading_produto
            // 
            this.lbl_loading_produto.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_loading_produto.AutoSize = true;
            this.lbl_loading_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lbl_loading_produto.ForeColor = System.Drawing.Color.Red;
            this.lbl_loading_produto.Location = new System.Drawing.Point(646, 22);
            this.lbl_loading_produto.Name = "lbl_loading_produto";
            this.lbl_loading_produto.Size = new System.Drawing.Size(143, 25);
            this.lbl_loading_produto.TabIndex = 3;
            this.lbl_loading_produto.Text = "Carregando...";
            this.lbl_loading_produto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_loading_produto.Visible = false;
            // 
            // FormCardapio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 690);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDetalheCardapio);
            this.Controls.Add(this.painelConsultaCardapio);
            this.Name = "FormCardapio";
            this.Text = "FormCardapio";
            this.painelConsultaCardapio.ResumeLayout(false);
            this.painelConsultaCardapio.PerformLayout();
            this.panelDetalheCardapio.ResumeLayout(false);
            this.panelDetalheCardapio.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lbl_loading_produto;

        private System.Windows.Forms.Label label15;

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbUnMedida;
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
        private System.Windows.Forms.Panel panel1;
    }
}