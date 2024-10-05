
namespace Lifora
{
    partial class backoffice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(backoffice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.btnBlockTheUser = new System.Windows.Forms.Button();
            this.btnUnlockTheUser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewInfoUser = new System.Windows.Forms.DataGridView();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCambiarNombre = new System.Windows.Forms.TextBox();
            this.textBoxCambiarApellido = new System.Windows.Forms.TextBox();
            this.textBoxCambiarTelefono = new System.Windows.Forms.TextBox();
            this.textBoxCambiarEmail = new System.Windows.Forms.TextBox();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxFechaDeNacimiento = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfoUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Location = new System.Drawing.Point(12, 101);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(176, 38);
            this.btnSearchUser.TabIndex = 0;
            this.btnSearchUser.Text = "Buscar Usuario";
            this.btnSearchUser.UseVisualStyleBackColor = true;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // btnBlockTheUser
            // 
            this.btnBlockTheUser.Location = new System.Drawing.Point(1047, 647);
            this.btnBlockTheUser.Name = "btnBlockTheUser";
            this.btnBlockTheUser.Size = new System.Drawing.Size(114, 35);
            this.btnBlockTheUser.TabIndex = 3;
            this.btnBlockTheUser.Text = "Bloquear Usuario";
            this.btnBlockTheUser.UseVisualStyleBackColor = true;
            this.btnBlockTheUser.Click += new System.EventHandler(this.btnBlockTheUser_Click);
            // 
            // btnUnlockTheUser
            // 
            this.btnUnlockTheUser.Location = new System.Drawing.Point(1167, 647);
            this.btnUnlockTheUser.Name = "btnUnlockTheUser";
            this.btnUnlockTheUser.Size = new System.Drawing.Size(114, 34);
            this.btnUnlockTheUser.TabIndex = 4;
            this.btnUnlockTheUser.Text = "Habilitar Usuario";
            this.btnUnlockTheUser.UseVisualStyleBackColor = true;
            this.btnUnlockTheUser.Click += new System.EventHandler(this.btnUnlockTheUser_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 55);
            this.label1.TabIndex = 13;
            this.label1.Text = "LIFORA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Live for Art";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "BACKOFFICE";
            // 
            // dataGridViewInfoUser
            // 
            this.dataGridViewInfoUser.AllowUserToOrderColumns = true;
            this.dataGridViewInfoUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInfoUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInfoUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewInfoUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewInfoUser.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewInfoUser.Location = new System.Drawing.Point(12, 145);
            this.dataGridViewInfoUser.MultiSelect = false;
            this.dataGridViewInfoUser.Name = "dataGridViewInfoUser";
            this.dataGridViewInfoUser.ReadOnly = true;
            this.dataGridViewInfoUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridViewInfoUser.RowHeadersWidth = 62;
            this.dataGridViewInfoUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInfoUser.Size = new System.Drawing.Size(1009, 532);
            this.dataGridViewInfoUser.TabIndex = 16;
            this.dataGridViewInfoUser.SelectionChanged += new System.EventHandler(this.dataGridViewInfoUser_SelectionChanged);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.Location = new System.Drawing.Point(194, 113);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxSearch.Size = new System.Drawing.Size(284, 26);
            this.txtBoxSearch.TabIndex = 17;
            this.txtBoxSearch.TextChanged += new System.EventHandler(this.txtBoxSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Ingresar email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1028, 429);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1028, 451);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Apellido";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1028, 472);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Telefono";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1028, 493);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Email";
            // 
            // textBoxCambiarNombre
            // 
            this.textBoxCambiarNombre.Location = new System.Drawing.Point(1092, 426);
            this.textBoxCambiarNombre.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCambiarNombre.Name = "textBoxCambiarNombre";
            this.textBoxCambiarNombre.Size = new System.Drawing.Size(175, 20);
            this.textBoxCambiarNombre.TabIndex = 23;
            this.textBoxCambiarNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCambiarApellido
            // 
            this.textBoxCambiarApellido.Location = new System.Drawing.Point(1092, 448);
            this.textBoxCambiarApellido.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCambiarApellido.Name = "textBoxCambiarApellido";
            this.textBoxCambiarApellido.Size = new System.Drawing.Size(175, 20);
            this.textBoxCambiarApellido.TabIndex = 24;
            this.textBoxCambiarApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCambiarTelefono
            // 
            this.textBoxCambiarTelefono.Location = new System.Drawing.Point(1092, 469);
            this.textBoxCambiarTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCambiarTelefono.Name = "textBoxCambiarTelefono";
            this.textBoxCambiarTelefono.Size = new System.Drawing.Size(175, 20);
            this.textBoxCambiarTelefono.TabIndex = 25;
            this.textBoxCambiarTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCambiarEmail
            // 
            this.textBoxCambiarEmail.Location = new System.Drawing.Point(1092, 490);
            this.textBoxCambiarEmail.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCambiarEmail.Name = "textBoxCambiarEmail";
            this.textBoxCambiarEmail.Size = new System.Drawing.Size(175, 20);
            this.textBoxCambiarEmail.TabIndex = 26;
            this.textBoxCambiarEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(1153, 537);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(114, 33);
            this.BtnModificar.TabIndex = 27;
            this.BtnModificar.Text = "ModificarUsuario";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1027, 512);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Fecha Nac";
            // 
            // textBoxFechaDeNacimiento
            // 
            this.textBoxFechaDeNacimiento.Location = new System.Drawing.Point(1092, 512);
            this.textBoxFechaDeNacimiento.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFechaDeNacimiento.Name = "textBoxFechaDeNacimiento";
            this.textBoxFechaDeNacimiento.Size = new System.Drawing.Size(175, 20);
            this.textBoxFechaDeNacimiento.TabIndex = 30;
            this.textBoxFechaDeNacimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 664);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 13);
            this.label15.TabIndex = 59;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(744, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 52);
            this.button1.TabIndex = 61;
            this.button1.Text = "ABMC POST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(926, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 52);
            this.button2.TabIndex = 62;
            this.button2.Text = "ABMC EVENTOS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1102, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 52);
            this.button3.TabIndex = 63;
            this.button3.Text = "ABMC GRUPOS";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1097, 145);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(170, 52);
            this.button4.TabIndex = 64;
            this.button4.Text = "CREAR USUARIO";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // backoffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1284, 711);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBoxFechaDeNacimiento);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.textBoxCambiarEmail);
            this.Controls.Add(this.textBoxCambiarTelefono);
            this.Controls.Add(this.textBoxCambiarApellido);
            this.Controls.Add(this.textBoxCambiarNombre);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.dataGridViewInfoUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnUnlockTheUser);
            this.Controls.Add(this.btnBlockTheUser);
            this.Controls.Add(this.btnSearchUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "backoffice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interface";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfoUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.Button btnBlockTheUser;
        private System.Windows.Forms.Button btnUnlockTheUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewInfoUser;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxCambiarNombre;
        private System.Windows.Forms.TextBox textBoxCambiarApellido;
        private System.Windows.Forms.TextBox textBoxCambiarTelefono;
        private System.Windows.Forms.TextBox textBoxCambiarEmail;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxFechaDeNacimiento;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}