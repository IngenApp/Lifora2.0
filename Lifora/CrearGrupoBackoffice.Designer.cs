
namespace Lifora
{
    partial class CrearGrupoBackoffice
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
            this.btnCrearGrupo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIDescripcionGrupo = new System.Windows.Forms.TextBox();
            this.textBoxNombreGrupo = new System.Windows.Forms.TextBox();
            this.id_cuenta = new System.Windows.Forms.Label();
            this.textBoxIdUsuario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCrearGrupo
            // 
            this.btnCrearGrupo.Location = new System.Drawing.Point(162, 168);
            this.btnCrearGrupo.Name = "btnCrearGrupo";
            this.btnCrearGrupo.Size = new System.Drawing.Size(120, 38);
            this.btnCrearGrupo.TabIndex = 21;
            this.btnCrearGrupo.Text = "Crear";
            this.btnCrearGrupo.UseVisualStyleBackColor = true;
            this.btnCrearGrupo.Click += new System.EventHandler(this.btnCrearGrupo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "descripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "nombre ";
            // 
            // textBoxIDescripcionGrupo
            // 
            this.textBoxIDescripcionGrupo.Location = new System.Drawing.Point(88, 118);
            this.textBoxIDescripcionGrupo.Name = "textBoxIDescripcionGrupo";
            this.textBoxIDescripcionGrupo.Size = new System.Drawing.Size(306, 20);
            this.textBoxIDescripcionGrupo.TabIndex = 13;
            // 
            // textBoxNombreGrupo
            // 
            this.textBoxNombreGrupo.Location = new System.Drawing.Point(88, 92);
            this.textBoxNombreGrupo.Name = "textBoxNombreGrupo";
            this.textBoxNombreGrupo.Size = new System.Drawing.Size(306, 20);
            this.textBoxNombreGrupo.TabIndex = 12;
            // 
            // id_cuenta
            // 
            this.id_cuenta.AutoSize = true;
            this.id_cuenta.Location = new System.Drawing.Point(9, 73);
            this.id_cuenta.Name = "id_cuenta";
            this.id_cuenta.Size = new System.Drawing.Size(55, 13);
            this.id_cuenta.TabIndex = 23;
            this.id_cuenta.Text = "Id Usuario";
            // 
            // textBoxIdUsuario
            // 
            this.textBoxIdUsuario.Location = new System.Drawing.Point(88, 66);
            this.textBoxIdUsuario.Name = "textBoxIdUsuario";
            this.textBoxIdUsuario.Size = new System.Drawing.Size(306, 20);
            this.textBoxIdUsuario.TabIndex = 22;
            // 
            // CrearGrupoBackoffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 290);
            this.Controls.Add(this.id_cuenta);
            this.Controls.Add(this.textBoxIdUsuario);
            this.Controls.Add(this.btnCrearGrupo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIDescripcionGrupo);
            this.Controls.Add(this.textBoxNombreGrupo);
            this.Name = "CrearGrupoBackoffice";
            this.Text = "CrearGrupoBackoffice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearGrupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIDescripcionGrupo;
        private System.Windows.Forms.TextBox textBoxNombreGrupo;
        private System.Windows.Forms.Label id_cuenta;
        private System.Windows.Forms.TextBox textBoxIdUsuario;
    }
}