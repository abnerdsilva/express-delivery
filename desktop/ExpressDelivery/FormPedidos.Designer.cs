using System.ComponentModel;

namespace ExpressDelivery
{
    partial class FormPedidos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAguarde = new System.Windows.Forms.Label();
            this.btnBuscarTodosDoDia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbStatusPedidoCodigo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBuscaCodigoPedido = new System.Windows.Forms.Button();
            this.txtCodigoPedido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbStatusPedidoData = new System.Windows.Forms.ComboBox();
            this.dtFim = new System.Windows.Forms.DateTimePicker();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.btnBuscaDataPedido = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listPedidos = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.listDetalhePedido = new System.Windows.Forms.ListView();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancelaPedido = new System.Windows.Forms.Button();
            this.btnBaixarPedido = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAguarde);
            this.panel1.Controls.Add(this.btnBuscarTodosDoDia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 63);
            this.panel1.TabIndex = 1;
            // 
            // lblAguarde
            // 
            this.lblAguarde.AutoSize = true;
            this.lblAguarde.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAguarde.ForeColor = System.Drawing.Color.Red;
            this.lblAguarde.Location = new System.Drawing.Point(341, 25);
            this.lblAguarde.Name = "lblAguarde";
            this.lblAguarde.Size = new System.Drawing.Size(122, 29);
            this.lblAguarde.TabIndex = 2;
            this.lblAguarde.Text = "Aguarde...";
            this.lblAguarde.Visible = false;
            // 
            // btnBuscarTodosDoDia
            // 
            this.btnBuscarTodosDoDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarTodosDoDia.Image = global::ExpressDelivery.Properties.Resources.search_list_black;
            this.btnBuscarTodosDoDia.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarTodosDoDia.Location = new System.Drawing.Point(640, 25);
            this.btnBuscarTodosDoDia.Name = "btnBuscarTodosDoDia";
            this.btnBuscarTodosDoDia.Size = new System.Drawing.Size(140, 34);
            this.btnBuscarTodosDoDia.TabIndex = 1;
            this.btnBuscarTodosDoDia.Text = "Listar do dia";
            this.btnBuscarTodosDoDia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarTodosDoDia.UseVisualStyleBackColor = true;
            this.btnBuscarTodosDoDia.Click += new System.EventHandler(this.btnBuscarTodosDoDia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Meus Pedidos";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmbStatusPedidoCodigo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btnBuscaCodigoPedido);
            this.panel2.Controls.Add(this.txtCodigoPedido);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 73);
            this.panel2.TabIndex = 2;
            // 
            // cmbStatusPedidoCodigo
            // 
            this.cmbStatusPedidoCodigo.FormattingEnabled = true;
            this.cmbStatusPedidoCodigo.Items.AddRange(new object[] { "TODOS", "ABERTO", "BAIXADO", "CANCELADO" });
            this.cmbStatusPedidoCodigo.Location = new System.Drawing.Point(142, 34);
            this.cmbStatusPedidoCodigo.Name = "cmbStatusPedidoCodigo";
            this.cmbStatusPedidoCodigo.Size = new System.Drawing.Size(101, 21);
            this.cmbStatusPedidoCodigo.TabIndex = 4;
            this.cmbStatusPedidoCodigo.Text = "ABERTO";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(142, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Status";
            // 
            // btnBuscaCodigoPedido
            // 
            this.btnBuscaCodigoPedido.FlatAppearance.BorderSize = 0;
            this.btnBuscaCodigoPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaCodigoPedido.Image = global::ExpressDelivery.Properties.Resources.search_list_black;
            this.btnBuscaCodigoPedido.Location = new System.Drawing.Point(249, 25);
            this.btnBuscaCodigoPedido.Name = "btnBuscaCodigoPedido";
            this.btnBuscaCodigoPedido.Size = new System.Drawing.Size(41, 36);
            this.btnBuscaCodigoPedido.TabIndex = 2;
            this.btnBuscaCodigoPedido.UseVisualStyleBackColor = true;
            this.btnBuscaCodigoPedido.Click += new System.EventHandler(this.btnBuscaCodigoPedido_Click);
            // 
            // txtCodigoPedido
            // 
            this.txtCodigoPedido.Location = new System.Drawing.Point(12, 34);
            this.txtCodigoPedido.Name = "txtCodigoPedido";
            this.txtCodigoPedido.Size = new System.Drawing.Size(115, 20);
            this.txtCodigoPedido.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Código Pedido";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cmbStatusPedidoData);
            this.panel3.Controls.Add(this.dtFim);
            this.panel3.Controls.Add(this.dtInicio);
            this.panel3.Controls.Add(this.btnBuscaDataPedido);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(316, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(447, 73);
            this.panel3.TabIndex = 3;
            // 
            // cmbStatusPedidoData
            // 
            this.cmbStatusPedidoData.FormattingEnabled = true;
            this.cmbStatusPedidoData.Items.AddRange(new object[] { "TODOS", "ABERTO", "BAIXADO", "CANCELADO" });
            this.cmbStatusPedidoData.Location = new System.Drawing.Point(310, 35);
            this.cmbStatusPedidoData.Name = "cmbStatusPedidoData";
            this.cmbStatusPedidoData.Size = new System.Drawing.Size(89, 21);
            this.cmbStatusPedidoData.TabIndex = 8;
            this.cmbStatusPedidoData.Text = "ABERTO";
            // 
            // dtFim
            // 
            this.dtFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFim.Location = new System.Drawing.Point(196, 35);
            this.dtFim.Name = "dtFim";
            this.dtFim.Size = new System.Drawing.Size(99, 20);
            this.dtFim.TabIndex = 7;
            this.dtFim.Value = new System.DateTime(2021, 11, 21, 9, 0, 59, 0);
            // 
            // dtInicio
            // 
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(51, 35);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(106, 20);
            this.dtInicio.TabIndex = 6;
            this.dtInicio.Value = new System.DateTime(2021, 11, 21, 9, 0, 59, 0);
            // 
            // btnBuscaDataPedido
            // 
            this.btnBuscaDataPedido.FlatAppearance.BorderSize = 0;
            this.btnBuscaDataPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaDataPedido.Image = global::ExpressDelivery.Properties.Resources.search_list_black;
            this.btnBuscaDataPedido.Location = new System.Drawing.Point(401, 25);
            this.btnBuscaDataPedido.Name = "btnBuscaDataPedido";
            this.btnBuscaDataPedido.Size = new System.Drawing.Size(41, 36);
            this.btnBuscaDataPedido.TabIndex = 5;
            this.btnBuscaDataPedido.UseVisualStyleBackColor = true;
            this.btnBuscaDataPedido.Click += new System.EventHandler(this.btnBuscaDataPedido_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(163, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fim";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Início";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Data Pedido";
            // 
            // listPedidos
            // 
            this.listPedidos.HideSelection = false;
            this.listPedidos.Location = new System.Drawing.Point(12, 208);
            this.listPedidos.Name = "listPedidos";
            this.listPedidos.Size = new System.Drawing.Size(768, 304);
            this.listPedidos.TabIndex = 4;
            this.listPedidos.UseCompatibleStateImageBehavior = false;
            this.listPedidos.SelectedIndexChanged += new System.EventHandler(this.listPedidos_SelectedIndexChanged);
            this.listPedidos.DoubleClick += new System.EventHandler(this.listPedidos_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Pedidos";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Location = new System.Drawing.Point(12, 82);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(768, 93);
            this.panel4.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Buscar por: ";
            // 
            // listDetalhePedido
            // 
            this.listDetalhePedido.HideSelection = false;
            this.listDetalhePedido.Location = new System.Drawing.Point(12, 544);
            this.listDetalhePedido.Name = "listDetalhePedido";
            this.listDetalhePedido.Size = new System.Drawing.Size(768, 134);
            this.listDetalhePedido.TabIndex = 9;
            this.listDetalhePedido.UseCompatibleStateImageBehavior = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 528);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Itens";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancelaPedido
            // 
            this.btnCancelaPedido.Location = new System.Drawing.Point(665, 518);
            this.btnCancelaPedido.Name = "btnCancelaPedido";
            this.btnCancelaPedido.Size = new System.Drawing.Size(115, 23);
            this.btnCancelaPedido.TabIndex = 11;
            this.btnCancelaPedido.Text = "Cancelar Pedido";
            this.btnCancelaPedido.UseVisualStyleBackColor = true;
            this.btnCancelaPedido.Visible = false;
            this.btnCancelaPedido.Click += new System.EventHandler(this.btnCancelaPedido_Click);
            // 
            // btnBaixarPedido
            // 
            this.btnBaixarPedido.Location = new System.Drawing.Point(544, 518);
            this.btnBaixarPedido.Name = "btnBaixarPedido";
            this.btnBaixarPedido.Size = new System.Drawing.Size(115, 23);
            this.btnBaixarPedido.TabIndex = 12;
            this.btnBaixarPedido.Text = "Baixar Pedido";
            this.btnBaixarPedido.UseVisualStyleBackColor = true;
            this.btnBaixarPedido.Visible = false;
            this.btnBaixarPedido.Click += new System.EventHandler(this.btnBaixarPedido_Click);
            // 
            // FormPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 690);
            this.Controls.Add(this.btnBaixarPedido);
            this.Controls.Add(this.btnCancelaPedido);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listDetalhePedido);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listPedidos);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormPedidos";
            this.Load += new System.EventHandler(this.FormPedidos_Load);
            this.Shown += new System.EventHandler(this.FormPedidos_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblAguarde;

        private System.Windows.Forms.Button btnCancelaPedido;

        private System.Windows.Forms.Button btnBaixarPedido;

        private System.Windows.Forms.ListView listDetalhePedido;

        private System.Windows.Forms.ListView listPedidos;

        private System.Windows.Forms.Button btnBuscarTodosDoDia;

        private System.Windows.Forms.Button btnBuscaDataPedido;

        private System.Windows.Forms.Button btnBuscaCodigoPedido;

        private System.Windows.Forms.ComboBox cmbStatusPedidoData;

        private System.Windows.Forms.DateTimePicker dtFim;
        private System.Windows.Forms.ComboBox cmbStatusPedidoCodigo;

        private System.Windows.Forms.DateTimePicker dtInicio;

        private System.Windows.Forms.TextBox txtCodigoPedido;

        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.Panel panel4;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;

        #endregion
    }
}