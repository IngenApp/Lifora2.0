
namespace InterfazUsuario
{
    partial class GruposMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GruposMenu));
            this.btnCrearGrupo = new System.Windows.Forms.Button();
            this.dataGridViewGrupos = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGrupo = new System.Windows.Forms.Button();
            this.labelGrupos = new System.Windows.Forms.Label();
            this.Nickname = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrupos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrearGrupo
            // 
            this.btnCrearGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnCrearGrupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearGrupo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearGrupo.ForeColor = System.Drawing.Color.White;
            this.btnCrearGrupo.Location = new System.Drawing.Point(27, 285);
            this.btnCrearGrupo.Name = "btnCrearGrupo";
            this.btnCrearGrupo.Size = new System.Drawing.Size(151, 48);
            this.btnCrearGrupo.TabIndex = 0;
            this.btnCrearGrupo.Text = "Crear Grupo";
            this.btnCrearGrupo.UseVisualStyleBackColor = false;
            this.btnCrearGrupo.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewGrupos
            // 
            this.dataGridViewGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGrupos.Location = new System.Drawing.Point(233, 22);
            this.dataGridViewGrupos.Name = "dataGridViewGrupos";
            this.dataGridViewGrupos.RowHeadersWidth = 51;
            this.dataGridViewGrupos.Size = new System.Drawing.Size(424, 362);
            this.dataGridViewGrupos.TabIndex = 1;
            this.dataGridViewGrupos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(27, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnGrupo
            // 
            this.btnGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnGrupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrupo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrupo.ForeColor = System.Drawing.Color.White;
            this.btnGrupo.Location = new System.Drawing.Point(506, 390);
            this.btnGrupo.Name = "btnGrupo";
            this.btnGrupo.Size = new System.Drawing.Size(151, 48);
            this.btnGrupo.TabIndex = 51;
            this.btnGrupo.Text = "Abrir";
            this.btnGrupo.UseVisualStyleBackColor = false;
            this.btnGrupo.Click += new System.EventHandler(this.btnGrupo_Click);
            // 
            // labelGrupos
            // 
            this.labelGrupos.AutoSize = true;
            this.labelGrupos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrupos.Location = new System.Drawing.Point(56, 22);
            this.labelGrupos.Name = "labelGrupos";
            this.labelGrupos.Size = new System.Drawing.Size(86, 24);
            this.labelGrupos.TabIndex = 58;
            this.labelGrupos.Text = "Grupos";
            this.labelGrupos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Nickname
            // 
            this.Nickname.AutoSize = true;
            this.Nickname.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Nickname.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nickname.Location = new System.Drawing.Point(56, 222);
            this.Nickname.Name = "Nickname";
            this.Nickname.Size = new System.Drawing.Size(77, 24);
            this.Nickname.TabIndex = 59;
            this.Nickname.TabStop = true;
            this.Nickname.Text = "Apodo";
            this.Nickname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GruposMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.Nickname);
            this.Controls.Add(this.labelGrupos);
            this.Controls.Add(this.btnGrupo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridViewGrupos);
            this.Controls.Add(this.btnCrearGrupo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GruposMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lifora";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrupos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearGrupo;
        private System.Windows.Forms.DataGridView dataGridViewGrupos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGrupo;
        private System.Windows.Forms.Label labelGrupos;
        private System.Windows.Forms.LinkLabel Nickname;
    }
}