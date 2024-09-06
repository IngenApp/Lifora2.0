
namespace Lifora
{
    partial class ComentarPost
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
            this.btnComentarPost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxComentarPost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.id_cuenta = new System.Windows.Forms.Label();
            this.textBoxIdCuenta = new System.Windows.Forms.TextBox();
            this.textBoxIdPost = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnComentarPost
            // 
            this.btnComentarPost.Location = new System.Drawing.Point(161, 154);
            this.btnComentarPost.Name = "btnComentarPost";
            this.btnComentarPost.Size = new System.Drawing.Size(132, 49);
            this.btnComentarPost.TabIndex = 25;
            this.btnComentarPost.Text = "Comentar ";
            this.btnComentarPost.UseVisualStyleBackColor = true;
            this.btnComentarPost.Click += new System.EventHandler(this.btnComentarPost_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Comentar";
            // 
            // textBoxComentarPost
            // 
            this.textBoxComentarPost.Location = new System.Drawing.Point(87, 97);
            this.textBoxComentarPost.Name = "textBoxComentarPost";
            this.textBoxComentarPost.Size = new System.Drawing.Size(335, 20);
            this.textBoxComentarPost.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "id Cuenta";
            // 
            // id_cuenta
            // 
            this.id_cuenta.AutoSize = true;
            this.id_cuenta.Location = new System.Drawing.Point(12, 55);
            this.id_cuenta.Name = "id_cuenta";
            this.id_cuenta.Size = new System.Drawing.Size(40, 13);
            this.id_cuenta.TabIndex = 29;
            this.id_cuenta.Text = "Id Post";
            // 
            // textBoxIdCuenta
            // 
            this.textBoxIdCuenta.Location = new System.Drawing.Point(87, 74);
            this.textBoxIdCuenta.Name = "textBoxIdCuenta";
            this.textBoxIdCuenta.Size = new System.Drawing.Size(335, 20);
            this.textBoxIdCuenta.TabIndex = 28;
            // 
            // textBoxIdPost
            // 
            this.textBoxIdPost.Location = new System.Drawing.Point(87, 48);
            this.textBoxIdPost.Name = "textBoxIdPost";
            this.textBoxIdPost.Size = new System.Drawing.Size(335, 20);
            this.textBoxIdPost.TabIndex = 26;
            // 
            // ComentarPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 253);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.id_cuenta);
            this.Controls.Add(this.textBoxIdCuenta);
            this.Controls.Add(this.textBoxIdPost);
            this.Controls.Add(this.btnComentarPost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxComentarPost);
            this.MaximizeBox = false;
            this.Name = "ComentarPost";
            this.Text = "ComentarPost";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnComentarPost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxComentarPost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label id_cuenta;
        private System.Windows.Forms.TextBox textBoxIdCuenta;
        private System.Windows.Forms.TextBox textBoxIdPost;
    }
}