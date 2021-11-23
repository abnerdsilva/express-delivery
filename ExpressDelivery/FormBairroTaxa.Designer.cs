using System.ComponentModel;

namespace ExpressDelivery
{
    partial class FormBairroTaxa
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdBairro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBairros = new System.Windows.Forms.ListView();
            this.txtVrTaxa = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnListarBairros = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(31, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bairros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(153, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bairro";
            // 
            // txtBairro
            // 
            this.txtBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtBairro.Location = new System.Drawing.Point(153, 120);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(393, 22);
            this.txtBairro.TabIndex = 2;
            this.txtBairro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBairro_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(564, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vr Taxa";
            // 
            // txtIdBairro
            // 
            this.txtIdBairro.Enabled = false;
            this.txtIdBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtIdBairro.Location = new System.Drawing.Point(30, 120);
            this.txtIdBairro.Name = "txtIdBairro";
            this.txtIdBairro.Size = new System.Drawing.Size(105, 22);
            this.txtIdBairro.TabIndex = 6;
            this.txtIdBairro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.Location = new System.Drawing.Point(30, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "ID Bairro";
            // 
            // listBairros
            // 
            this.listBairros.HideSelection = false;
            this.listBairros.Location = new System.Drawing.Point(30, 168);
            this.listBairros.Name = "listBairros";
            this.listBairros.Size = new System.Drawing.Size(740, 270);
            this.listBairros.TabIndex = 9;
            this.listBairros.UseCompatibleStateImageBehavior = false;
            this.listBairros.DoubleClick += new System.EventHandler(this.listBairros_DoubleClick);
            // 
            // txtVrTaxa
            // 
            this.txtVrTaxa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtVrTaxa.Location = new System.Drawing.Point(567, 120);
            this.txtVrTaxa.Name = "txtVrTaxa";
            this.txtVrTaxa.Size = new System.Drawing.Size(105, 22);
            this.txtVrTaxa.TabIndex = 10;
            this.txtVrTaxa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVrTaxa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVrTaxa_KeyPress);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnCadastrar.Location = new System.Drawing.Point(682, 117);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(88, 28);
            this.btnCadastrar.TabIndex = 11;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnNovo.Location = new System.Drawing.Point(682, 43);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(88, 28);
            this.btnNovo.TabIndex = 12;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnListarBairros
            // 
            this.btnListarBairros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnListarBairros.Location = new System.Drawing.Point(584, 43);
            this.btnListarBairros.Name = "btnListarBairros";
            this.btnListarBairros.Size = new System.Drawing.Size(88, 28);
            this.btnListarBairros.TabIndex = 13;
            this.btnListarBairros.Text = "Listar";
            this.btnListarBairros.UseVisualStyleBackColor = true;
            this.btnListarBairros.Click += new System.EventHandler(this.btnListarBairros_Click);
            // 
            // FormBairroTaxa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnListarBairros);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtVrTaxa);
            this.Controls.Add(this.listBairros);
            this.Controls.Add(this.txtIdBairro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormBairroTaxa";
            this.Text = "Cadastro de Bairros";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtIdBairro;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listBairros;

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.TextBox txtBairro;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        #endregion

        private System.Windows.Forms.TextBox txtVrTaxa;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnListarBairros;
    }
}