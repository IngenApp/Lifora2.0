
namespace InterfazUsuario
{
    partial class InformacionUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformacionUsuario));
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelFechaNac = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.labelEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelEmail.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.ForeColor = System.Drawing.Color.White;
            this.labelEmail.Location = new System.Drawing.Point(98, 48);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(73, 26);
            this.labelEmail.TabIndex = 0;
            this.labelEmail.Text = "label1";
            this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.labelTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTelefono.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTelefono.ForeColor = System.Drawing.Color.White;
            this.labelTelefono.Location = new System.Drawing.Point(98, 90);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(73, 26);
            this.labelTelefono.TabIndex = 1;
            this.labelTelefono.Text = "label2";
            this.labelTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.labelNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelNombre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.ForeColor = System.Drawing.Color.White;
            this.labelNombre.Location = new System.Drawing.Point(98, 134);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(73, 26);
            this.labelNombre.TabIndex = 2;
            this.labelNombre.Text = "label3";
            this.labelNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.labelApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelApellido.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApellido.ForeColor = System.Drawing.Color.White;
            this.labelApellido.Location = new System.Drawing.Point(98, 177);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(73, 26);
            this.labelApellido.TabIndex = 3;
            this.labelApellido.Text = "label4";
            this.labelApellido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFechaNac
            // 
            this.labelFechaNac.AutoSize = true;
            this.labelFechaNac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.labelFechaNac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFechaNac.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaNac.ForeColor = System.Drawing.Color.White;
            this.labelFechaNac.Location = new System.Drawing.Point(98, 220);
            this.labelFechaNac.Name = "labelFechaNac";
            this.labelFechaNac.Size = new System.Drawing.Size(73, 26);
            this.labelFechaNac.TabIndex = 4;
            this.labelFechaNac.Text = "label5";
            this.labelFechaNac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InformacionUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.labelFechaNac);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelTelefono);
            this.Controls.Add(this.labelEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InformacionUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lifora";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelFechaNac;
    }
}