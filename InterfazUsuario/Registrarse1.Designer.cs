
namespace InterfazUsuario
{
    partial class Registrarse1
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
            this.lblTituloRegister = new System.Windows.Forms.Label();
            this.lblSubTituloRegistro = new System.Windows.Forms.Label();
            this.txtBoxMail = new System.Windows.Forms.TextBox();
            this.txtBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.txtBoxPhone = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTituloRegister
            // 
            this.lblTituloRegister.AutoSize = true;
            this.lblTituloRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTituloRegister.Location = new System.Drawing.Point(172, 28);
            this.lblTituloRegister.Name = "lblTituloRegister";
            this.lblTituloRegister.Size = new System.Drawing.Size(35, 13);
            this.lblTituloRegister.TabIndex = 0;
            this.lblTituloRegister.Text = "label1";
            this.lblTituloRegister.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSubTituloRegistro
            // 
            this.lblSubTituloRegistro.AutoSize = true;
            this.lblSubTituloRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSubTituloRegistro.Location = new System.Drawing.Point(81, 60);
            this.lblSubTituloRegistro.Name = "lblSubTituloRegistro";
            this.lblSubTituloRegistro.Size = new System.Drawing.Size(35, 13);
            this.lblSubTituloRegistro.TabIndex = 1;
            this.lblSubTituloRegistro.Text = "label2";
            this.lblSubTituloRegistro.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtBoxMail
            // 
            this.txtBoxMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtBoxMail.Location = new System.Drawing.Point(85, 136);
            this.txtBoxMail.Name = "txtBoxMail";
            this.txtBoxMail.Size = new System.Drawing.Size(270, 20);
            this.txtBoxMail.TabIndex = 2;
            // 
            // txtBoxConfirmPassword
            // 
            this.txtBoxConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtBoxConfirmPassword.Location = new System.Drawing.Point(85, 295);
            this.txtBoxConfirmPassword.Name = "txtBoxConfirmPassword";
            this.txtBoxConfirmPassword.Size = new System.Drawing.Size(271, 20);
            this.txtBoxConfirmPassword.TabIndex = 3;
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtBoxPassword.Location = new System.Drawing.Point(85, 240);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(270, 20);
            this.txtBoxPassword.TabIndex = 4;
            // 
            // txtBoxPhone
            // 
            this.txtBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtBoxPhone.Location = new System.Drawing.Point(85, 188);
            this.txtBoxPhone.Name = "txtBoxPhone";
            this.txtBoxPhone.Size = new System.Drawing.Size(270, 20);
            this.txtBoxPhone.TabIndex = 5;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnNext.Location = new System.Drawing.Point(84, 347);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(272, 50);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "button1";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button1_Click);
            // 
            // Registrarse1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 511);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtBoxPhone);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.txtBoxConfirmPassword);
            this.Controls.Add(this.txtBoxMail);
            this.Controls.Add(this.lblSubTituloRegistro);
            this.Controls.Add(this.lblTituloRegister);
            this.Name = "Registrarse1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrarse1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloRegister;
        private System.Windows.Forms.Label lblSubTituloRegistro;
        private System.Windows.Forms.TextBox txtBoxMail;
        private System.Windows.Forms.TextBox txtBoxConfirmPassword;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.TextBox txtBoxPhone;
        private System.Windows.Forms.Button btnNext;
    }
}