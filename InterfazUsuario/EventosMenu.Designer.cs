
namespace InterfazUsuario
{
    partial class EventosMenu
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
            System.Windows.Forms.PictureBox pictureBox2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventosMenu));
            this.btnEvento = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridViewEventos = new System.Windows.Forms.DataGridView();
            this.btnCrearEvento = new System.Windows.Forms.Button();
            this.labelEventos = new System.Windows.Forms.Label();
            this.textBoxBuscarEvento = new System.Windows.Forms.TextBox();
            this.btnTodosEventos = new System.Windows.Forms.Button();
            this.btnMisEventos = new System.Windows.Forms.Button();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventos)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.Image = global::InterfazUsuario.Properties.Resources.Buscar;
            pictureBox2.Location = new System.Drawing.Point(622, 73);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(30, 30);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 65;
            pictureBox2.TabStop = false;
            // 
            // btnEvento
            // 
            this.btnEvento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnEvento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEvento.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvento.ForeColor = System.Drawing.Color.White;
            this.btnEvento.Location = new System.Drawing.Point(506, 390);
            this.btnEvento.Name = "btnEvento";
            this.btnEvento.Size = new System.Drawing.Size(151, 48);
            this.btnEvento.TabIndex = 56;
            this.btnEvento.Text = "Abrir";
            this.btnEvento.UseVisualStyleBackColor = false;
            this.btnEvento.Click += new System.EventHandler(this.btnEvento_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(30, 112);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridViewEventos
            // 
            this.dataGridViewEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEventos.Location = new System.Drawing.Point(233, 112);
            this.dataGridViewEventos.Name = "dataGridViewEventos";
            this.dataGridViewEventos.RowHeadersWidth = 51;
            this.dataGridViewEventos.Size = new System.Drawing.Size(424, 272);
            this.dataGridViewEventos.TabIndex = 53;
            // 
            // btnCrearEvento
            // 
            this.btnCrearEvento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnCrearEvento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearEvento.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearEvento.ForeColor = System.Drawing.Color.White;
            this.btnCrearEvento.Location = new System.Drawing.Point(233, 390);
            this.btnCrearEvento.Name = "btnCrearEvento";
            this.btnCrearEvento.Size = new System.Drawing.Size(151, 48);
            this.btnCrearEvento.TabIndex = 52;
            this.btnCrearEvento.Text = "Crear Evento";
            this.btnCrearEvento.UseVisualStyleBackColor = false;
            this.btnCrearEvento.Click += new System.EventHandler(this.btnCrearEvento_Click);
            // 
            // labelEventos
            // 
            this.labelEventos.AutoSize = true;
            this.labelEventos.BackColor = System.Drawing.Color.Transparent;
            this.labelEventos.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEventos.Location = new System.Drawing.Point(30, 30);
            this.labelEventos.Name = "labelEventos";
            this.labelEventos.Size = new System.Drawing.Size(90, 28);
            this.labelEventos.TabIndex = 57;
            this.labelEventos.Text = "Eventos";
            this.labelEventos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxBuscarEvento
            // 
            this.textBoxBuscarEvento.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBuscarEvento.Location = new System.Drawing.Point(233, 70);
            this.textBoxBuscarEvento.Name = "textBoxBuscarEvento";
            this.textBoxBuscarEvento.Size = new System.Drawing.Size(424, 36);
            this.textBoxBuscarEvento.TabIndex = 64;
            // 
            // btnTodosEventos
            // 
            this.btnTodosEventos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnTodosEventos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTodosEventos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodosEventos.ForeColor = System.Drawing.Color.White;
            this.btnTodosEventos.Location = new System.Drawing.Point(30, 336);
            this.btnTodosEventos.Name = "btnTodosEventos";
            this.btnTodosEventos.Size = new System.Drawing.Size(151, 48);
            this.btnTodosEventos.TabIndex = 67;
            this.btnTodosEventos.Text = "Todos Even";
            this.btnTodosEventos.UseVisualStyleBackColor = false;
            // 
            // btnMisEventos
            // 
            this.btnMisEventos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnMisEventos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMisEventos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMisEventos.ForeColor = System.Drawing.Color.White;
            this.btnMisEventos.Location = new System.Drawing.Point(30, 282);
            this.btnMisEventos.Name = "btnMisEventos";
            this.btnMisEventos.Size = new System.Drawing.Size(151, 48);
            this.btnMisEventos.TabIndex = 66;
            this.btnMisEventos.Text = "Mis Eventos";
            this.btnMisEventos.UseVisualStyleBackColor = false;
            // 
            // EventosMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazUsuario.Properties.Resources.wallpaperEmergente;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.btnTodosEventos);
            this.Controls.Add(this.btnMisEventos);
            this.Controls.Add(pictureBox2);
            this.Controls.Add(this.textBoxBuscarEvento);
            this.Controls.Add(this.labelEventos);
            this.Controls.Add(this.btnEvento);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridViewEventos);
            this.Controls.Add(this.btnCrearEvento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EventosMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lifora";
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEvento;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridViewEventos;
        private System.Windows.Forms.Button btnCrearEvento;
        private System.Windows.Forms.Label labelEventos;
        private System.Windows.Forms.TextBox textBoxBuscarEvento;
        private System.Windows.Forms.Button btnTodosEventos;
        private System.Windows.Forms.Button btnMisEventos;
    }
}