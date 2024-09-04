
namespace Lifora
{
    partial class CrearPostBackoffice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.btnCrearPost = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.id_cuenta = new System.Windows.Forms.Label();
            this.textBoxFecha = new System.Windows.Forms.TextBox();
            this.textBoxPostear = new System.Windows.Forms.TextBox();
            this.textBoxIdUsuario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCrearPost
            // 
            this.btnCrearPost.Location = new System.Drawing.Point(186, 136);
            this.btnCrearPost.Name = "btnCrearPost";
            this.btnCrearPost.Size = new System.Drawing.Size(75, 23);
            this.btnCrearPost.TabIndex = 21;
            this.btnCrearPost.Text = "Crear";
            this.btnCrearPost.UseVisualStyleBackColor = true;
            this.btnCrearPost.Click += new System.EventHandler(this.btnCrearPost_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "texto a Postear";
            // 
            // id_cuenta
            // 
            this.id_cuenta.AutoSize = true;
            this.id_cuenta.Location = new System.Drawing.Point(7, 58);
            this.id_cuenta.Name = "id_cuenta";
            this.id_cuenta.Size = new System.Drawing.Size(55, 13);
            this.id_cuenta.TabIndex = 16;
            this.id_cuenta.Text = "Id Usuario";
            // 
            // textBoxFecha
            // 
            this.textBoxFecha.Location = new System.Drawing.Point(86, 103);
            this.textBoxFecha.Name = "textBoxFecha";
            this.textBoxFecha.Size = new System.Drawing.Size(306, 20);
            this.textBoxFecha.TabIndex = 15;
            // 
            // textBoxPostear
            // 
            this.textBoxPostear.Location = new System.Drawing.Point(86, 77);
            this.textBoxPostear.Name = "textBoxPostear";
            this.textBoxPostear.Size = new System.Drawing.Size(306, 20);
            this.textBoxPostear.TabIndex = 12;
            // 
            // textBoxIdUsuario
            // 
            this.textBoxIdUsuario.Location = new System.Drawing.Point(86, 51);
            this.textBoxIdUsuario.Name = "textBoxIdUsuario";
            this.textBoxIdUsuario.Size = new System.Drawing.Size(306, 20);
            this.textBoxIdUsuario.TabIndex = 11;
            // 
            // CrearPostBackoffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 408);
            this.Controls.Add(this.btnCrearPost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.id_cuenta);
            this.Controls.Add(this.textBoxFecha);
            this.Controls.Add(this.textBoxPostear);
            this.Controls.Add(this.textBoxIdUsuario);
            this.Name = "CrearPostBackoffice";
            this.Text = "CrearPostBackoffice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearPost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label id_cuenta;
        private System.Windows.Forms.TextBox textBoxFecha;
        private System.Windows.Forms.TextBox textBoxPostear;
        private System.Windows.Forms.TextBox textBoxIdUsuario;
    }
}