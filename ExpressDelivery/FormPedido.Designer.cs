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
            this.panelOrder = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelClient = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTaxaEntrega = new System.Windows.Forms.TextBox();
            this.cmbBairro = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDDD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelOrder.SuspendLayout();
            this.panelClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOrder
            // 
            this.panelOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOrder.Controls.Add(this.button3);
            this.panelOrder.Controls.Add(this.button2);
            this.panelOrder.Controls.Add(this.comboBox1);
            this.panelOrder.Controls.Add(this.label21);
            this.panelOrder.Controls.Add(this.label22);
            this.panelOrder.Controls.Add(this.textBox12);
            this.panelOrder.Controls.Add(this.label23);
            this.panelOrder.Controls.Add(this.textBox13);
            this.panelOrder.Controls.Add(this.label19);
            this.panelOrder.Controls.Add(this.textBox11);
            this.panelOrder.Controls.Add(this.label17);
            this.panelOrder.Controls.Add(this.textBox10);
            this.panelOrder.Controls.Add(this.label18);
            this.panelOrder.Controls.Add(this.textBox9);
            this.panelOrder.Controls.Add(this.listView1);
            this.panelOrder.Controls.Add(this.textBox6);
            this.panelOrder.Controls.Add(this.label16);
            this.panelOrder.Controls.Add(this.textBox5);
            this.panelOrder.Controls.Add(this.label15);
            this.panelOrder.Controls.Add(this.textBox4);
            this.panelOrder.Controls.Add(this.label14);
            this.panelOrder.Controls.Add(this.textBox2);
            this.panelOrder.Controls.Add(this.label13);
            this.panelOrder.Controls.Add(this.textBox1);
            this.panelOrder.Controls.Add(this.label12);
            this.panelOrder.Controls.Add(this.label11);
            this.panelOrder.Controls.Add(this.label1);
            this.panelOrder.Location = new System.Drawing.Point(2, 3);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(547, 443);
            this.panelOrder.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(288, 400);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 34);
            this.button3.TabIndex = 28;
            this.button3.Text = "Confirmar Pedido";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(83, 404);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 30);
            this.button2.TabIndex = 27;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {"Dinheiro", "Cartão"});
            this.comboBox1.Location = new System.Drawing.Point(375, 371);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 21);
            this.comboBox1.TabIndex = 26;
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
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(194, 371);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(160, 20);
            this.textBox12.TabIndex = 22;
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
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(9, 371);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(160, 20);
            this.textBox13.TabIndex = 20;
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
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(375, 327);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(160, 20);
            this.textBox11.TabIndex = 18;
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
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(194, 327);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(160, 20);
            this.textBox10.TabIndex = 16;
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
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(9, 327);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(160, 20);
            this.textBox9.TabIndex = 14;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(9, 166);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(526, 138);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(9, 140);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(526, 20);
            this.textBox6.TabIndex = 11;
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
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(9, 101);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(526, 20);
            this.textBox5.TabIndex = 9;
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
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(375, 53);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(160, 20);
            this.textBox4.TabIndex = 7;
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(175, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(194, 20);
            this.textBox2.TabIndex = 5;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 20);
            this.textBox1.TabIndex = 3;
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label11.Location = new System.Drawing.Point(400, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "10/11/2021 22:00:00";
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
            this.panelClient.Controls.Add(this.label20);
            this.panelClient.Controls.Add(this.txtTaxaEntrega);
            this.panelClient.Controls.Add(this.cmbBairro);
            this.panelClient.Controls.Add(this.button1);
            this.panelClient.Controls.Add(this.textBox8);
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
            this.panelClient.Controls.Add(this.textBox3);
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
            // 
            // cmbBairro
            // 
            this.cmbBairro.FormattingEnabled = true;
            this.cmbBairro.Location = new System.Drawing.Point(13, 247);
            this.cmbBairro.Name = "cmbBairro";
            this.cmbBairro.Size = new System.Drawing.Size(132, 21);
            this.cmbBairro.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 10;
            this.button1.Location = new System.Drawing.Point(13, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 34);
            this.button1.TabIndex = 20;
            this.button1.Text = "Salvar cliente";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(13, 295);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(211, 62);
            this.textBox8.TabIndex = 19;
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
            this.txtNome.TabIndex = 15;
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
            this.txtTelefone.TabIndex = 12;
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(12, 149);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(98, 20);
            this.txtCEP.TabIndex = 11;
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
            this.txtNumero.TabIndex = 9;
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
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 197);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(211, 20);
            this.textBox3.TabIndex = 7;
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
            // FormPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelClient);
            this.Controls.Add(this.panelOrder);
            this.Name = "FormPedido";
            this.Text = "FormPedido";
            this.panelOrder.ResumeLayout(false);
            this.panelOrder.PerformLayout();
            this.panelClient.ResumeLayout(false);
            this.panelClient.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.ComboBox comboBox1;

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox txtTaxaEntrega;
        private System.Windows.Forms.ComboBox cmbBairro;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox12;

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

        private System.Windows.Forms.TextBox txtDD;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Panel panelOrder;
        private System.Windows.Forms.Panel panelClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label10;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

        #endregion
    }
}