using System.ComponentModel;

namespace ExpressDelivery
{
    partial class FormPedido
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
            this.components = new System.ComponentModel.Container();
            this.panelOrder = new System.Windows.Forms.Panel();
            this.btnVisualizaPedidos = new System.Windows.Forms.Button();
            this.lblNrPedido = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnExcluirPedido = new System.Windows.Forms.Button();
            this.cmbDescricaoProduto = new System.Windows.Forms.ComboBox();
            this.btnConfirmarPedido = new System.Windows.Forms.Button();
            this.cmbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtVrTroco = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtVrTrocoPara = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtVrTotalPedido = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtVrTaxaEntrega = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtVrTotalItens = new System.Windows.Forms.TextBox();
            this.listProdutos = new System.Windows.Forms.ListView();
            this.txtObservacaoProduto = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtValorUnit = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCodBarras = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtQtde = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDataHora = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelClient = new System.Windows.Forms.Panel();
            this.btnCancelarCliente = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTaxaEntrega = new System.Windows.Forms.TextBox();
            this.cmbBairro = new System.Windows.Forms.ComboBox();
            this.btnSalvarCliente = new System.Windows.Forms.Button();
            this.txtObservacaoCliente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDDD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timerDataHora = new System.Windows.Forms.Timer(this.components);
            this.panelOrder.SuspendLayout();
            this.panelClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOrder
            // 
            this.panelOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOrder.Controls.Add(this.btnVisualizaPedidos);
            this.panelOrder.Controls.Add(this.lblNrPedido);
            this.panelOrder.Controls.Add(this.btnCancelar);
            this.panelOrder.Controls.Add(this.btnExcluirPedido);
            this.panelOrder.Controls.Add(this.cmbDescricaoProduto);
            this.panelOrder.Controls.Add(this.btnConfirmarPedido);
            this.panelOrder.Controls.Add(this.cmbFormaPagamento);
            this.panelOrder.Controls.Add(this.label21);
            this.panelOrder.Controls.Add(this.label22);
            this.panelOrder.Controls.Add(this.txtVrTroco);
            this.panelOrder.Controls.Add(this.label23);
            this.panelOrder.Controls.Add(this.txtVrTrocoPara);
            this.panelOrder.Controls.Add(this.label19);
            this.panelOrder.Controls.Add(this.txtVrTotalPedido);
            this.panelOrder.Controls.Add(this.label17);
            this.panelOrder.Controls.Add(this.txtVrTaxaEntrega);
            this.panelOrder.Controls.Add(this.label18);
            this.panelOrder.Controls.Add(this.txtVrTotalItens);
            this.panelOrder.Controls.Add(this.listProdutos);
            this.panelOrder.Controls.Add(this.txtObservacaoProduto);
            this.panelOrder.Controls.Add(this.label16);
            this.panelOrder.Controls.Add(this.label15);
            this.panelOrder.Controls.Add(this.txtValorUnit);
            this.panelOrder.Controls.Add(this.label14);
            this.panelOrder.Controls.Add(this.txtCodBarras);
            this.panelOrder.Controls.Add(this.label13);
            this.panelOrder.Controls.Add(this.txtQtde);
            this.panelOrder.Controls.Add(this.label12);
            this.panelOrder.Controls.Add(this.lblDataHora);
            this.panelOrder.Controls.Add(this.label1);
            this.panelOrder.Enabled = false;
            this.panelOrder.Location = new System.Drawing.Point(2, 3);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(547, 443);
            this.panelOrder.TabIndex = 2;
            // 
            // btnVisualizaPedidos
            // 
            this.btnVisualizaPedidos.Location = new System.Drawing.Point(283, 400);
            this.btnVisualizaPedidos.Name = "btnVisualizaPedidos";
            this.btnVisualizaPedidos.Size = new System.Drawing.Size(110, 34);
            this.btnVisualizaPedidos.TabIndex = 33;
            this.btnVisualizaPedidos.Text = "Pedidos";
            this.btnVisualizaPedidos.UseVisualStyleBackColor = true;
            // 
            // lblNrPedido
            // 
            this.lblNrPedido.AutoSize = true;
            this.lblNrPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblNrPedido.Location = new System.Drawing.Point(70, 6);
            this.lblNrPedido.Name = "lblNrPedido";
            this.lblNrPedido.Size = new System.Drawing.Size(16, 16);
            this.lblNrPedido.TabIndex = 32;
            this.lblNrPedido.Text = "0";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(19, 400);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 34);
            this.btnCancelar.TabIndex = 31;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluirPedido
            // 
            this.btnExcluirPedido.Location = new System.Drawing.Point(151, 400);
            this.btnExcluirPedido.Name = "btnExcluirPedido";
            this.btnExcluirPedido.Size = new System.Drawing.Size(110, 34);
            this.btnExcluirPedido.TabIndex = 30;
            this.btnExcluirPedido.Text = "Excluir Pedido";
            this.btnExcluirPedido.UseVisualStyleBackColor = true;
            // 
            // cmbDescricaoProduto
            // 
            this.cmbDescricaoProduto.FormattingEnabled = true;
            this.cmbDescricaoProduto.Location = new System.Drawing.Point(9, 100);
            this.cmbDescricaoProduto.Name = "cmbDescricaoProduto";
            this.cmbDescricaoProduto.Size = new System.Drawing.Size(526, 21);
            this.cmbDescricaoProduto.TabIndex = 14;
            this.cmbDescricaoProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDescricaoProduto_KeyPress);
            // 
            // btnConfirmarPedido
            // 
            this.btnConfirmarPedido.Location = new System.Drawing.Point(415, 400);
            this.btnConfirmarPedido.Name = "btnConfirmarPedido";
            this.btnConfirmarPedido.Size = new System.Drawing.Size(110, 34);
            this.btnConfirmarPedido.TabIndex = 18;
            this.btnConfirmarPedido.Text = "Confirmar Pedido";
            this.btnConfirmarPedido.UseVisualStyleBackColor = true;
            this.btnConfirmarPedido.Click += new System.EventHandler(this.btnConfirmarPedido_Click);
            // 
            // cmbFormaPagamento
            // 
            this.cmbFormaPagamento.FormattingEnabled = true;
            this.cmbFormaPagamento.Items.AddRange(new object[] {"Dinheiro", "Cartão"});
            this.cmbFormaPagamento.Location = new System.Drawing.Point(375, 371);
            this.cmbFormaPagamento.Name = "cmbFormaPagamento";
            this.cmbFormaPagamento.Size = new System.Drawing.Size(160, 21);
            this.cmbFormaPagamento.TabIndex = 17;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(375, 355);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(160, 13);
            this.label21.TabIndex = 25;
            this.label21.Text = "Forma Pagamento";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(194, 355);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(160, 13);
            this.label22.TabIndex = 23;
            this.label22.Text = "Troco";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtVrTroco
            // 
            this.txtVrTroco.Enabled = false;
            this.txtVrTroco.Location = new System.Drawing.Point(194, 371);
            this.txtVrTroco.Name = "txtVrTroco";
            this.txtVrTroco.Size = new System.Drawing.Size(160, 20);
            this.txtVrTroco.TabIndex = 22;
            this.txtVrTroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(9, 355);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(160, 13);
            this.label23.TabIndex = 21;
            this.label23.Text = "Troco para";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtVrTrocoPara
            // 
            this.txtVrTrocoPara.Enabled = false;
            this.txtVrTrocoPara.Location = new System.Drawing.Point(9, 371);
            this.txtVrTrocoPara.Name = "txtVrTrocoPara";
            this.txtVrTrocoPara.Size = new System.Drawing.Size(160, 20);
            this.txtVrTrocoPara.TabIndex = 20;
            this.txtVrTrocoPara.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVrTrocoPara.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVrTrocoPara_KeyPress);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(375, 311);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(160, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "Total Pedido";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtVrTotalPedido
            // 
            this.txtVrTotalPedido.Enabled = false;
            this.txtVrTotalPedido.Location = new System.Drawing.Point(375, 327);
            this.txtVrTotalPedido.Name = "txtVrTotalPedido";
            this.txtVrTotalPedido.Size = new System.Drawing.Size(160, 20);
            this.txtVrTotalPedido.TabIndex = 18;
            this.txtVrTotalPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(194, 311);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(160, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Taxa Entrega";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtVrTaxaEntrega
            // 
            this.txtVrTaxaEntrega.Enabled = false;
            this.txtVrTaxaEntrega.Location = new System.Drawing.Point(194, 327);
            this.txtVrTaxaEntrega.Name = "txtVrTaxaEntrega";
            this.txtVrTaxaEntrega.Size = new System.Drawing.Size(160, 20);
            this.txtVrTaxaEntrega.TabIndex = 16;
            this.txtVrTaxaEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(9, 311);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(160, 13);
            this.label18.TabIndex = 15;
            this.label18.Text = "Total itens";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtVrTotalItens
            // 
            this.txtVrTotalItens.Enabled = false;
            this.txtVrTotalItens.Location = new System.Drawing.Point(9, 327);
            this.txtVrTotalItens.Name = "txtVrTotalItens";
            this.txtVrTotalItens.Size = new System.Drawing.Size(160, 20);
            this.txtVrTotalItens.TabIndex = 14;
            this.txtVrTotalItens.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listProdutos
            // 
            this.listProdutos.Location = new System.Drawing.Point(9, 166);
            this.listProdutos.Name = "listProdutos";
            this.listProdutos.Size = new System.Drawing.Size(526, 138);
            this.listProdutos.TabIndex = 12;
            this.listProdutos.UseCompatibleStateImageBehavior = false;
            // 
            // txtObservacaoProduto
            // 
            this.txtObservacaoProduto.Location = new System.Drawing.Point(9, 140);
            this.txtObservacaoProduto.Name = "txtObservacaoProduto";
            this.txtObservacaoProduto.Size = new System.Drawing.Size(526, 20);
            this.txtObservacaoProduto.TabIndex = 15;
            this.txtObservacaoProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObservacaoProduto_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 124);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Observação";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Descrição do Produto";
            // 
            // txtValorUnit
            // 
            this.txtValorUnit.Enabled = false;
            this.txtValorUnit.Location = new System.Drawing.Point(375, 53);
            this.txtValorUnit.Name = "txtValorUnit";
            this.txtValorUnit.Size = new System.Drawing.Size(160, 20);
            this.txtValorUnit.TabIndex = 7;
            this.txtValorUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(375, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(167, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Valor Unitário";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCodBarras
            // 
            this.txtCodBarras.Location = new System.Drawing.Point(175, 53);
            this.txtCodBarras.Name = "txtCodBarras";
            this.txtCodBarras.Size = new System.Drawing.Size(194, 20);
            this.txtCodBarras.TabIndex = 13;
            this.txtCodBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodBarras_KeyPress);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(175, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(194, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Código";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtQtde
            // 
            this.txtQtde.Location = new System.Drawing.Point(9, 53);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(160, 20);
            this.txtQtde.TabIndex = 16;
            this.txtQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQtde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtde_KeyPress);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(9, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Quantidade";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDataHora
            // 
            this.lblDataHora.AutoSize = true;
            this.lblDataHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblDataHora.Location = new System.Drawing.Point(400, 7);
            this.lblDataHora.Name = "lblDataHora";
            this.lblDataHora.Size = new System.Drawing.Size(142, 16);
            this.lblDataHora.TabIndex = 1;
            this.lblDataHora.Text = "10/11/2021 22:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pedido: ";
            // 
            // panelClient
            // 
            this.panelClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClient.Controls.Add(this.btnCancelarCliente);
            this.panelClient.Controls.Add(this.label20);
            this.panelClient.Controls.Add(this.txtTaxaEntrega);
            this.panelClient.Controls.Add(this.cmbBairro);
            this.panelClient.Controls.Add(this.btnSalvarCliente);
            this.panelClient.Controls.Add(this.txtObservacaoCliente);
            this.panelClient.Controls.Add(this.label10);
            this.panelClient.Controls.Add(this.label9);
            this.panelClient.Controls.Add(this.txtNome);
            this.panelClient.Controls.Add(this.label4);
            this.panelClient.Controls.Add(this.label8);
            this.panelClient.Controls.Add(this.txtTelefone);
            this.panelClient.Controls.Add(this.txtCEP);
            this.panelClient.Controls.Add(this.label7);
            this.panelClient.Controls.Add(this.txtNumero);
            this.panelClient.Controls.Add(this.label6);
            this.panelClient.Controls.Add(this.txtEndereco);
            this.panelClient.Controls.Add(this.label5);
            this.panelClient.Controls.Add(this.txtDDD);
            this.panelClient.Controls.Add(this.label3);
            this.panelClient.Controls.Add(this.txtIdCliente);
            this.panelClient.Controls.Add(this.label2);
            this.panelClient.Location = new System.Drawing.Point(555, 3);
            this.panelClient.Name = "panelClient";
            this.panelClient.Size = new System.Drawing.Size(240, 443);
            this.panelClient.TabIndex = 3;
            // 
            // btnCancelarCliente
            // 
            this.btnCancelarCliente.FlatAppearance.BorderSize = 10;
            this.btnCancelarCliente.Location = new System.Drawing.Point(11, 400);
            this.btnCancelarCliente.Name = "btnCancelarCliente";
            this.btnCancelarCliente.Size = new System.Drawing.Size(99, 34);
            this.btnCancelarCliente.TabIndex = 24;
            this.btnCancelarCliente.Text = "Cancelar";
            this.btnCancelarCliente.UseVisualStyleBackColor = true;
            this.btnCancelarCliente.Click += new System.EventHandler(this.btnCancelarCliente_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(151, 231);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 13);
            this.label20.TabIndex = 23;
            this.label20.Text = "Taxa Entrega";
            // 
            // txtTaxaEntrega
            // 
            this.txtTaxaEntrega.Enabled = false;
            this.txtTaxaEntrega.Location = new System.Drawing.Point(152, 247);
            this.txtTaxaEntrega.Name = "txtTaxaEntrega";
            this.txtTaxaEntrega.Size = new System.Drawing.Size(72, 20);
            this.txtTaxaEntrega.TabIndex = 22;
            this.txtTaxaEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbBairro
            // 
            this.cmbBairro.FormattingEnabled = true;
            this.cmbBairro.Location = new System.Drawing.Point(13, 247);
            this.cmbBairro.Name = "cmbBairro";
            this.cmbBairro.Size = new System.Drawing.Size(132, 21);
            this.cmbBairro.TabIndex = 9;
            this.cmbBairro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBairro_KeyPress);
            // 
            // btnSalvarCliente
            // 
            this.btnSalvarCliente.FlatAppearance.BorderSize = 10;
            this.btnSalvarCliente.Location = new System.Drawing.Point(124, 400);
            this.btnSalvarCliente.Name = "btnSalvarCliente";
            this.btnSalvarCliente.Size = new System.Drawing.Size(99, 34);
            this.btnSalvarCliente.TabIndex = 12;
            this.btnSalvarCliente.Text = "Salvar cliente";
            this.btnSalvarCliente.UseVisualStyleBackColor = true;
            this.btnSalvarCliente.Click += new System.EventHandler(this.btnSalvarCliente_Click);
            // 
            // txtObservacaoCliente
            // 
            this.txtObservacaoCliente.Location = new System.Drawing.Point(13, 295);
            this.txtObservacaoCliente.Multiline = true;
            this.txtObservacaoCliente.Name = "txtObservacaoCliente";
            this.txtObservacaoCliente.Size = new System.Drawing.Size(211, 62);
            this.txtObservacaoCliente.TabIndex = 10;
            this.txtObservacaoCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObservacaoCliente_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Observação";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Bairro";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(12, 101);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(211, 20);
            this.txtNome.TabIndex = 5;
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nome";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(69, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Telefone";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(69, 53);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(154, 20);
            this.txtTelefone.TabIndex = 4;
            this.txtTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTelefone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefone_KeyPress);
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(12, 149);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(98, 20);
            this.txtCEP.TabIndex = 6;
            this.txtCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCEP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCEP_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "CEP";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(116, 149);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(107, 20);
            this.txtNumero.TabIndex = 7;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Número";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(12, 197);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(211, 20);
            this.txtEndereco.TabIndex = 8;
            this.txtEndereco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEndereco_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Endereço";
            // 
            // txtDDD
            // 
            this.txtDDD.Location = new System.Drawing.Point(12, 53);
            this.txtDDD.Name = "txtDDD";
            this.txtDDD.Size = new System.Drawing.Size(51, 20);
            this.txtDDD.TabIndex = 3;
            this.txtDDD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDDD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDDD_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "DDD";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Enabled = false;
            this.txtIdCliente.Location = new System.Drawing.Point(151, 3);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(72, 20);
            this.txtIdCliente.TabIndex = 1;
            this.txtIdCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID Cliente";
            // 
            // timerDataHora
            // 
            this.timerDataHora.Enabled = true;
            this.timerDataHora.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelClient);
            this.Controls.Add(this.panelOrder);
            this.Name = "FormPedido";
            this.Text = "FormPedido";
            this.Load += new System.EventHandler(this.FormPedido_Load);
            this.panelOrder.ResumeLayout(false);
            this.panelOrder.PerformLayout();
            this.panelClient.ResumeLayout(false);
            this.panelClient.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnCancelarCliente;

        private System.Windows.Forms.Button btnVisualizaPedidos;

        private System.Windows.Forms.Timer timerDataHora;

        private System.Windows.Forms.Label lblDataHora;

        private System.Windows.Forms.Timer timer1;

        private System.Windows.Forms.Button btnSalvarCliente;

        private System.Windows.Forms.Button btnSalvar;

        private System.Windows.Forms.ListView listProdutos;

        private System.Windows.Forms.Label lblNrPedido;
        private System.Windows.Forms.Button btnExcluirPedido;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmarPedido;
        private System.Windows.Forms.ComboBox cmbFormaPagamento;
        private System.Windows.Forms.TextBox txtVrTroco;
        private System.Windows.Forms.TextBox txtVrTrocoPara;
        private System.Windows.Forms.TextBox txtVrTaxaEntrega;
        private System.Windows.Forms.TextBox txtVrTotalPedido;
        private System.Windows.Forms.TextBox txtVrTotalItens;
        private System.Windows.Forms.TextBox txtObservacaoCliente;
        private System.Windows.Forms.TextBox txtObservacaoProduto;
        private System.Windows.Forms.ComboBox cmbDescricaoProduto;
        private System.Windows.Forms.TextBox txtCodBarras;
        private System.Windows.Forms.TextBox txtValorUnit;
        private System.Windows.Forms.TextBox txtQtde;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTaxaEntrega;
        private System.Windows.Forms.ComboBox cmbBairro;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtDDD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelOrder;
        private System.Windows.Forms.Panel panelClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;

        #endregion
    }
}