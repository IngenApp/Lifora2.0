
namespace InterfazUsuario
{
    partial class Eventos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Eventos));
            this.labelNombreEvento = new System.Windows.Forms.Label();
            this.fotoEvento = new System.Windows.Forms.PictureBox();
            this.txtInfoEvento = new System.Windows.Forms.RichTextBox();
            this.txtLugarEvento = new System.Windows.Forms.RichTextBox();
            this.txtFechaEvento = new System.Windows.Forms.RichTextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelLugarEvento = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fotoEvento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNombreEvento
            // 
            this.labelNombreEvento.AutoSize = true;
            this.labelNombreEvento.BackColor = System.Drawing.Color.Transparent;
            this.labelNombreEvento.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreEvento.Location = new System.Drawing.Point(30, 30);
            this.labelNombreEvento.Name = "labelNombreEvento";
            this.labelNombreEvento.Size = new System.Drawing.Size(203, 24);
            this.labelNombreEvento.TabIndex = 0;
            this.labelNombreEvento.Text = "Nombre del Evento";
            // 
            // fotoEvento
            // 
            this.fotoEvento.Location = new System.Drawing.Point(441, 97);
            this.fotoEvento.Name = "fotoEvento";
            this.fotoEvento.Size = new System.Drawing.Size(200, 200);
            this.fotoEvento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotoEvento.TabIndex = 2;
            this.fotoEvento.TabStop = false;
            this.fotoEvento.Click += new System.EventHandler(this.fotoEvento_Click);
            // 
            // txtInfoEvento
            // 
            this.txtInfoEvento.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtInfoEvento.Enabled = false;
            this.txtInfoEvento.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfoEvento.Location = new System.Drawing.Point(34, 181);
            this.txtInfoEvento.Name = "txtInfoEvento";
            this.txtInfoEvento.ReadOnly = true;
            this.txtInfoEvento.Size = new System.Drawing.Size(372, 101);
            this.txtInfoEvento.TabIndex = 37;
            this.txtInfoEvento.Text = resources.GetString("txtInfoEvento.Text");
            // 
            // txtLugarEvento
            // 
            this.txtLugarEvento.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtLugarEvento.Enabled = false;
            this.txtLugarEvento.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLugarEvento.Location = new System.Drawing.Point(34, 97);
            this.txtLugarEvento.Name = "txtLugarEvento";
            this.txtLugarEvento.ReadOnly = true;
            this.txtLugarEvento.Size = new System.Drawing.Size(316, 50);
            this.txtLugarEvento.TabIndex = 38;
            this.txtLugarEvento.Text = resources.GetString("txtLugarEvento.Text");
            // 
            // txtFechaEvento
            // 
            this.txtFechaEvento.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtFechaEvento.Enabled = false;
            this.txtFechaEvento.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaEvento.Location = new System.Drawing.Point(34, 316);
            this.txtFechaEvento.Name = "txtFechaEvento";
            this.txtFechaEvento.ReadOnly = true;
            this.txtFechaEvento.Size = new System.Drawing.Size(299, 31);
            this.txtFechaEvento.TabIndex = 39;
            this.txtFechaEvento.Text = resources.GetString("txtFechaEvento.Text");
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::InterfazUsuario.Properties.Resources.Lugar;
            this.pictureBox3.Location = new System.Drawing.Point(356, 97);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 41;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::InterfazUsuario.Properties.Resources.GustaEvento;
            this.pictureBox1.Location = new System.Drawing.Point(482, 303);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::InterfazUsuario.Properties.Resources.No_me_gusta_evento;
            this.pictureBox2.Location = new System.Drawing.Point(538, 303);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 43;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(29, 150);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(68, 28);
            this.labelInfo.TabIndex = 46;
            this.labelInfo.Text = "label2";
            // 
            // labelLugarEvento
            // 
            this.labelLugarEvento.AutoSize = true;
            this.labelLugarEvento.BackColor = System.Drawing.Color.Transparent;
            this.labelLugarEvento.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLugarEvento.Location = new System.Drawing.Point(29, 66);
            this.labelLugarEvento.Name = "labelLugarEvento";
            this.labelLugarEvento.Size = new System.Drawing.Size(68, 28);
            this.labelLugarEvento.TabIndex = 45;
            this.labelLugarEvento.Text = "label1";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.BackColor = System.Drawing.Color.Transparent;
            this.labelFecha.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(29, 285);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(68, 28);
            this.labelFecha.TabIndex = 47;
            this.labelFecha.Text = "label2";
            // 
            // Eventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazUsuario.Properties.Resources.wallpaperEmergente;
            this.ClientSize = new System.Drawing.Size(684, 372);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelLugarEvento);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtFechaEvento);
            this.Controls.Add(this.txtLugarEvento);
            this.Controls.Add(this.txtInfoEvento);
            this.Controls.Add(this.fotoEvento);
            this.Controls.Add(this.labelNombreEvento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Eventos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lifora";
            ((System.ComponentModel.ISupportInitialize)(this.fotoEvento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNombreEvento;
        private System.Windows.Forms.PictureBox fotoEvento;
        private System.Windows.Forms.RichTextBox txtInfoEvento;
        private System.Windows.Forms.RichTextBox txtLugarEvento;
        private System.Windows.Forms.RichTextBox txtFechaEvento;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelLugarEvento;
        private System.Windows.Forms.Label labelFecha;
    }
}