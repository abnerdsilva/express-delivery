using System.ComponentModel;

namespace ExpressDelivery
{
    partial class FormHome
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
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.lbl_idOperador = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFormUsuarios = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnFormClientes = new System.Windows.Forms.Button();
            this.btnFormPedido = new System.Windows.Forms.Button();
            this.btnFormCardapio = new System.Windows.Forms.Button();
            this.btnFormDashbord = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelHomeBody = new System.Windows.Forms.Panel();
            this.panelSideMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.SystemColors.Desktop;
            this.panelSideMenu.Controls.Add(this.lbl_idOperador);
            this.panelSideMenu.Controls.Add(this.label1);
            this.panelSideMenu.Controls.Add(this.btnFormUsuarios);
            this.panelSideMenu.Controls.Add(this.btnSair);
            this.panelSideMenu.Controls.Add(this.btnFormClientes);
            this.panelSideMenu.Controls.Add(this.btnFormPedido);
            this.panelSideMenu.Controls.Add(this.btnFormCardapio);
            this.panelSideMenu.Controls.Add(this.btnFormDashbord);
            this.panelSideMenu.Controls.Add(this.panel1);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(200, 729);
            this.panelSideMenu.TabIndex = 0;
            // 
            // lbl_idOperador
            // 
            this.lbl_idOperador.AutoSize = true;
            this.lbl_idOperador.Location = new System.Drawing.Point(82, 650);
            this.lbl_idOperador.Name = "lbl_idOperador";
            this.lbl_idOperador.Size = new System.Drawing.Size(0, 18);
            this.lbl_idOperador.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 650);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Usuário:";
            // 
            // btnFormUsuarios
            // 
            this.btnFormUsuarios.BackColor = System.Drawing.Color.Silver;
            this.btnFormUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFormUsuarios.FlatAppearance.BorderSize = 0;
            this.btnFormUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormUsuarios.Location = new System.Drawing.Point(0, 280);
            this.btnFormUsuarios.Name = "btnFormUsuarios";
            this.btnFormUsuarios.Size = new System.Drawing.Size(200, 33);
            this.btnFormUsuarios.TabIndex = 2;
            this.btnFormUsuarios.Text = "Usuário";
            this.btnFormUsuarios.UseVisualStyleBackColor = false;
            this.btnFormUsuarios.Click += new System.EventHandler(this.btnFormUsuarios_Click);
            // 
            // btnSair
            // 
            this.btnSair.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.Location = new System.Drawing.Point(0, 689);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(200, 40);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnFormClientes
            // 
            this.btnFormClientes.BackColor = System.Drawing.Color.Silver;
            this.btnFormClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFormClientes.FlatAppearance.BorderSize = 0;
            this.btnFormClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormClientes.Location = new System.Drawing.Point(0, 247);
            this.btnFormClientes.Name = "btnFormClientes";
            this.btnFormClientes.Size = new System.Drawing.Size(200, 33);
            this.btnFormClientes.TabIndex = 1;
            this.btnFormClientes.Text = "Cliente";
            this.btnFormClientes.UseVisualStyleBackColor = false;
            this.btnFormClientes.Click += new System.EventHandler(this.btnFormClientes_Click);
            // 
            // btnFormPedido
            // 
            this.btnFormPedido.BackColor = System.Drawing.Color.Silver;
            this.btnFormPedido.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFormPedido.FlatAppearance.BorderSize = 0;
            this.btnFormPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormPedido.Location = new System.Drawing.Point(0, 207);
            this.btnFormPedido.Name = "btnFormPedido";
            this.btnFormPedido.Size = new System.Drawing.Size(200, 40);
            this.btnFormPedido.TabIndex = 5;
            this.btnFormPedido.Text = "Pedido";
            this.btnFormPedido.UseVisualStyleBackColor = false;
            this.btnFormPedido.Click += new System.EventHandler(this.btnFormPedido_Click);
            // 
            // btnFormCardapio
            // 
            this.btnFormCardapio.BackColor = System.Drawing.Color.Silver;
            this.btnFormCardapio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFormCardapio.FlatAppearance.BorderSize = 0;
            this.btnFormCardapio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormCardapio.Location = new System.Drawing.Point(0, 174);
            this.btnFormCardapio.Name = "btnFormCardapio";
            this.btnFormCardapio.Size = new System.Drawing.Size(200, 33);
            this.btnFormCardapio.TabIndex = 0;
            this.btnFormCardapio.Text = "Produto";
            this.btnFormCardapio.UseVisualStyleBackColor = false;
            this.btnFormCardapio.Click += new System.EventHandler(this.btnFormCardapio_Click);
            // 
            // btnFormDashbord
            // 
            this.btnFormDashbord.BackColor = System.Drawing.Color.Silver;
            this.btnFormDashbord.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFormDashbord.FlatAppearance.BorderSize = 0;
            this.btnFormDashbord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormDashbord.Location = new System.Drawing.Point(0, 134);
            this.btnFormDashbord.Name = "btnFormDashbord";
            this.btnFormDashbord.Size = new System.Drawing.Size(200, 40);
            this.btnFormDashbord.TabIndex = 1;
            this.btnFormDashbord.Text = "Dashboard";
            this.btnFormDashbord.UseVisualStyleBackColor = true;
            this.btnFormDashbord.Click += new System.EventHandler(this.btnFormDashbord_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 134);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ExpressDelivery.Properties.Resources.EXPRESS_DELIVERY__2_;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelHomeBody
            // 
            this.panelHomeBody.BackColor = System.Drawing.SystemColors.Control;
            this.panelHomeBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHomeBody.Location = new System.Drawing.Point(200, 0);
            this.panelHomeBody.Name = "panelHomeBody";
            this.panelHomeBody.Size = new System.Drawing.Size(808, 729);
            this.panelHomeBody.TabIndex = 1;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panelHomeBody);
            this.Controls.Add(this.panelSideMenu);
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExpressDelivery - Sistema de Delivery";
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelSideMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lbl_idOperador;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button btnFormPedido;

        private System.Windows.Forms.Button btnFormUsuarios;

        private System.Windows.Forms.Button btnFormCardapio;
        private System.Windows.Forms.Button btnFormClientes;

        private System.Windows.Forms.Button btnFormDashbord;

        private System.Windows.Forms.Panel panelHomeBody;

        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel1;
    }
}