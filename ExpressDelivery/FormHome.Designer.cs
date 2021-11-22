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
            this.btnSair = new System.Windows.Forms.Button();
            this.btnFormPedido = new System.Windows.Forms.Button();
            this.panelCadastros = new System.Windows.Forms.Panel();
            this.btnFormUsuarios = new System.Windows.Forms.Button();
            this.btnFormClientes = new System.Windows.Forms.Button();
            this.btnFormCardapio = new System.Windows.Forms.Button();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.btnFormDashbord = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelHomeBody = new System.Windows.Forms.Panel();
            this.panelSideMenu.SuspendLayout();
            this.panelCadastros.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.SystemColors.Desktop;
            this.panelSideMenu.Controls.Add(this.btnSair);
            this.panelSideMenu.Controls.Add(this.btnFormPedido);
            this.panelSideMenu.Controls.Add(this.panelCadastros);
            this.panelSideMenu.Controls.Add(this.btnCadastro);
            this.panelSideMenu.Controls.Add(this.btnFormDashbord);
            this.panelSideMenu.Controls.Add(this.panel1);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(200, 729);
            this.panelSideMenu.TabIndex = 0;
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
            // btnFormPedido
            // 
            this.btnFormPedido.BackColor = System.Drawing.Color.Silver;
            this.btnFormPedido.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFormPedido.FlatAppearance.BorderSize = 0;
            this.btnFormPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormPedido.Location = new System.Drawing.Point(0, 326);
            this.btnFormPedido.Name = "btnFormPedido";
            this.btnFormPedido.Size = new System.Drawing.Size(200, 40);
            this.btnFormPedido.TabIndex = 5;
            this.btnFormPedido.Text = "Pedido";
            this.btnFormPedido.UseVisualStyleBackColor = false;
            this.btnFormPedido.Click += new System.EventHandler(this.btnFormPedido_Click);
            // 
            // panelCadastros
            // 
            this.panelCadastros.Controls.Add(this.btnFormUsuarios);
            this.panelCadastros.Controls.Add(this.btnFormClientes);
            this.panelCadastros.Controls.Add(this.btnFormCardapio);
            this.panelCadastros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCadastros.Location = new System.Drawing.Point(0, 214);
            this.panelCadastros.Name = "panelCadastros";
            this.panelCadastros.Size = new System.Drawing.Size(200, 112);
            this.panelCadastros.TabIndex = 4;
            // 
            // btnFormUsuarios
            // 
            this.btnFormUsuarios.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFormUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFormUsuarios.FlatAppearance.BorderSize = 0;
            this.btnFormUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormUsuarios.Location = new System.Drawing.Point(0, 66);
            this.btnFormUsuarios.Name = "btnFormUsuarios";
            this.btnFormUsuarios.Size = new System.Drawing.Size(200, 33);
            this.btnFormUsuarios.TabIndex = 2;
            this.btnFormUsuarios.Text = "Usuário";
            this.btnFormUsuarios.UseVisualStyleBackColor = false;
            this.btnFormUsuarios.Click += new System.EventHandler(this.btnFormUsuarios_Click);
            // 
            // btnFormClientes
            // 
            this.btnFormClientes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFormClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFormClientes.FlatAppearance.BorderSize = 0;
            this.btnFormClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormClientes.Location = new System.Drawing.Point(0, 33);
            this.btnFormClientes.Name = "btnFormClientes";
            this.btnFormClientes.Size = new System.Drawing.Size(200, 33);
            this.btnFormClientes.TabIndex = 1;
            this.btnFormClientes.Text = "Cliente";
            this.btnFormClientes.UseVisualStyleBackColor = false;
            this.btnFormClientes.Click += new System.EventHandler(this.btnFormClientes_Click);
            // 
            // btnFormCardapio
            // 
            this.btnFormCardapio.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFormCardapio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFormCardapio.FlatAppearance.BorderSize = 0;
            this.btnFormCardapio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormCardapio.Location = new System.Drawing.Point(0, 0);
            this.btnFormCardapio.Name = "btnFormCardapio";
            this.btnFormCardapio.Size = new System.Drawing.Size(200, 33);
            this.btnFormCardapio.TabIndex = 0;
            this.btnFormCardapio.Text = "Cardapio";
            this.btnFormCardapio.UseVisualStyleBackColor = false;
            this.btnFormCardapio.Click += new System.EventHandler(this.btnFormCardapio_Click);
            // 
            // btnCadastro
            // 
            this.btnCadastro.BackColor = System.Drawing.Color.Silver;
            this.btnCadastro.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCadastro.FlatAppearance.BorderSize = 0;
            this.btnCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastro.Location = new System.Drawing.Point(0, 174);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(200, 40);
            this.btnCadastro.TabIndex = 3;
            this.btnCadastro.Text = "Cadastro";
            this.btnCadastro.UseVisualStyleBackColor = false;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
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
            this.pictureBox1.Image = global::ExpressDelivery.Properties.Resources.no_imagem;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelHomeBody
            // 
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
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panelHomeBody);
            this.Controls.Add(this.panelSideMenu);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gerenciamento de Pedidos";
            this.panelSideMenu.ResumeLayout(false);
            this.panelCadastros.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

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
        private System.Windows.Forms.Panel panelCadastros;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Panel panel1;
    }
}