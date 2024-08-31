
namespace Lifora
{
    partial class CrearEventoBackoffice
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
            this.textBoxId_cuenta = new System.Windows.Forms.TextBox();
            this.textBoxNombreEvento = new System.Windows.Forms.TextBox();
            this.textBoxInformacion = new System.Windows.Forms.TextBox();
            this.textBoxLugar = new System.Windows.Forms.TextBox();
            this.textBoxFecha = new System.Windows.Forms.TextBox();
            this.id_cuenta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxId_cuenta
            // 
            this.textBoxId_cuenta.Location = new System.Drawing.Point(91, 65);
            this.textBoxId_cuenta.Name = "textBoxId_cuenta";
            this.textBoxId_cuenta.Size = new System.Drawing.Size(306, 20);
            this.textBoxId_cuenta.TabIndex = 0;
            // 
            // textBoxNombreEvento
            // 
            this.textBoxNombreEvento.Location = new System.Drawing.Point(91, 91);
            this.textBoxNombreEvento.Name = "textBoxNombreEvento";
            this.textBoxNombreEvento.Size = new System.Drawing.Size(306, 20);
            this.textBoxNombreEvento.TabIndex = 1;
            // 
            // textBoxInformacion
            // 
            this.textBoxInformacion.Location = new System.Drawing.Point(91, 117);
            this.textBoxInformacion.Name = "textBoxInformacion";
            this.textBoxInformacion.Size = new System.Drawing.Size(306, 20);
            this.textBoxInformacion.TabIndex = 2;
            // 
            // textBoxLugar
            // 
            this.textBoxLugar.Location = new System.Drawing.Point(91, 143);
            this.textBoxLugar.Name = "textBoxLugar";
            this.textBoxLugar.Size = new System.Drawing.Size(306, 20);
            this.textBoxLugar.TabIndex = 3;
            // 
            // textBoxFecha
            // 
            this.textBoxFecha.Location = new System.Drawing.Point(91, 169);
            this.textBoxFecha.Name = "textBoxFecha";
            this.textBoxFecha.Size = new System.Drawing.Size(306, 20);
            this.textBoxFecha.TabIndex = 4;
            // 
            // id_cuenta
            // 
            this.id_cuenta.AutoSize = true;
            this.id_cuenta.Location = new System.Drawing.Point(12, 72);
            this.id_cuenta.Name = "id_cuenta";
            this.id_cuenta.Size = new System.Drawing.Size(54, 13);
            this.id_cuenta.TabIndex = 5;
            this.id_cuenta.Text = "id_cuenta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "nombre evento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "informacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "lugar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "fecha";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Crear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CrearEventoBackoffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 408);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.id_cuenta);
            this.Controls.Add(this.textBoxFecha);
            this.Controls.Add(this.textBoxLugar);
            this.Controls.Add(this.textBoxInformacion);
            this.Controls.Add(this.textBoxNombreEvento);
            this.Controls.Add(this.textBoxId_cuenta);
            this.Name = "CrearEventoBackoffice";
            this.Text = "CrearEventoBackoffice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxId_cuenta;
        private System.Windows.Forms.TextBox textBoxNombreEvento;
        private System.Windows.Forms.TextBox textBoxInformacion;
        private System.Windows.Forms.TextBox textBoxLugar;
        private System.Windows.Forms.TextBox textBoxFecha;
        private System.Windows.Forms.Label id_cuenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}