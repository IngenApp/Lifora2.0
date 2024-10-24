
namespace InterfazUsuario
{
    partial class Registrarse2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registrarse2));
            this.txtBoxSurName = new System.Windows.Forms.TextBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.lblSubTituloRegistro = new System.Windows.Forms.Label();
            this.lblTituloRegister = new System.Windows.Forms.Label();
            this.txtBoxDateOfBirth = new System.Windows.Forms.TextBox();
            this.txtBoxNickName = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxSurName
            // 
            this.txtBoxSurName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBoxSurName.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSurName.Location = new System.Drawing.Point(81, 217);
            this.txtBoxSurName.Name = "txtBoxSurName";
            this.txtBoxSurName.Size = new System.Drawing.Size(270, 36);
            this.txtBoxSurName.TabIndex = 10;
            // 
            // txtBoxName
            // 
            this.txtBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBoxName.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxName.Location = new System.Drawing.Point(81, 175);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(270, 36);
            this.txtBoxName.TabIndex = 9;
            // 
            // lblSubTituloRegistro
            // 
            this.lblSubTituloRegistro.AutoSize = true;
            this.lblSubTituloRegistro.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTituloRegistro.Location = new System.Drawing.Point(49, 94);
            this.lblSubTituloRegistro.Name = "lblSubTituloRegistro";
            this.lblSubTituloRegistro.Size = new System.Drawing.Size(346, 24);
            this.lblSubTituloRegistro.TabIndex = 8;
            this.lblSubTituloRegistro.Text = "Para compartir y ver artes juntos!";
            // 
            // lblTituloRegister
            // 
            this.lblTituloRegister.AutoSize = true;
            this.lblTituloRegister.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloRegister.Location = new System.Drawing.Point(155, 59);
            this.lblTituloRegister.Name = "lblTituloRegister";
            this.lblTituloRegister.Size = new System.Drawing.Size(114, 24);
            this.lblTituloRegister.TabIndex = 7;
            this.lblTituloRegister.Text = "Registrate";
            // 
            // txtBoxDateOfBirth
            // 
            this.txtBoxDateOfBirth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBoxDateOfBirth.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDateOfBirth.Location = new System.Drawing.Point(79, 259);
            this.txtBoxDateOfBirth.Name = "txtBoxDateOfBirth";
            this.txtBoxDateOfBirth.Size = new System.Drawing.Size(271, 36);
            this.txtBoxDateOfBirth.TabIndex = 14;
            // 
            // txtBoxNickName
            // 
            this.txtBoxNickName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBoxNickName.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNickName.Location = new System.Drawing.Point(81, 301);
            this.txtBoxNickName.Name = "txtBoxNickName";
            this.txtBoxNickName.Size = new System.Drawing.Size(269, 36);
            this.txtBoxNickName.TabIndex = 15;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnRegister.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(79, 351);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(272, 50);
            this.btnRegister.TabIndex = 18;
            this.btnRegister.Text = "button2";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.button2_Click);
            // 
            // Registrarse2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 511);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtBoxNickName);
            this.Controls.Add(this.txtBoxDateOfBirth);
            this.Controls.Add(this.txtBoxSurName);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.lblSubTituloRegistro);
            this.Controls.Add(this.lblTituloRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Registrarse2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lifora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Registrarse2_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Registrarse2_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBoxSurName;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label lblSubTituloRegistro;
        private System.Windows.Forms.Label lblTituloRegister;
        private System.Windows.Forms.TextBox txtBoxDateOfBirth;
        private System.Windows.Forms.TextBox txtBoxNickName;
        private System.Windows.Forms.Button btnRegister;
    }
}