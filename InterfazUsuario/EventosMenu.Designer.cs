
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventosMenu));
            this.btnEvento = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridViewEventos = new System.Windows.Forms.DataGridView();
            this.btnCrearEvento = new System.Windows.Forms.Button();
            this.labelEventos = new System.Windows.Forms.Label();
            this.Nickname = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventos)).BeginInit();
            this.SuspendLayout();
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
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(27, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridViewEventos
            // 
            this.dataGridViewEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEventos.Location = new System.Drawing.Point(233, 22);
            this.dataGridViewEventos.Name = "dataGridViewEventos";
            this.dataGridViewEventos.RowHeadersWidth = 51;
            this.dataGridViewEventos.Size = new System.Drawing.Size(424, 362);
            this.dataGridViewEventos.TabIndex = 53;
            // 
            // btnCrearEvento
            // 
            this.btnCrearEvento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnCrearEvento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearEvento.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearEvento.ForeColor = System.Drawing.Color.White;
            this.btnCrearEvento.Location = new System.Drawing.Point(27, 285);
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
            this.labelEventos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEventos.Location = new System.Drawing.Point(56, 22);
            this.labelEventos.Name = "labelEventos";
            this.labelEventos.Size = new System.Drawing.Size(91, 24);
            this.labelEventos.TabIndex = 57;
            this.labelEventos.Text = "Eventos";
            this.labelEventos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Nickname
            // 
            this.Nickname.AutoSize = true;
            this.Nickname.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Nickname.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nickname.Location = new System.Drawing.Point(56, 222);
            this.Nickname.Name = "Nickname";
            this.Nickname.Size = new System.Drawing.Size(77, 24);
            this.Nickname.TabIndex = 58;
            this.Nickname.TabStop = true;
            this.Nickname.Text = "Apodo";
            this.Nickname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventosMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.Nickname);
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
        private System.Windows.Forms.LinkLabel Nickname;
    }
}