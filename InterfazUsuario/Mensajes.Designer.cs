
namespace InterfazUsuario
{
    partial class Mensajes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mensajes));
            this.dataGridViewChats = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBoxMensajes = new System.Windows.Forms.RichTextBox();
            this.btnEnviarMensaje = new System.Windows.Forms.Button();
            this.dataGridViewMensajes = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelMensajes = new System.Windows.Forms.Label();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMensajes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.Image = global::InterfazUsuario.Properties.Resources.Buscar;
            pictureBox2.Location = new System.Drawing.Point(407, 73);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(30, 30);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 66;
            pictureBox2.TabStop = false;
            // 
            // dataGridViewChats
            // 
            this.dataGridViewChats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChats.Location = new System.Drawing.Point(20, 112);
            this.dataGridViewChats.Name = "dataGridViewChats";
            this.dataGridViewChats.Size = new System.Drawing.Size(422, 571);
            this.dataGridViewChats.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(20, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(422, 36);
            this.textBox1.TabIndex = 2;
            // 
            // richTextBoxMensajes
            // 
            this.richTextBoxMensajes.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxMensajes.Location = new System.Drawing.Point(474, 616);
            this.richTextBoxMensajes.Name = "richTextBoxMensajes";
            this.richTextBoxMensajes.Size = new System.Drawing.Size(409, 67);
            this.richTextBoxMensajes.TabIndex = 4;
            this.richTextBoxMensajes.Text = "";
            // 
            // btnEnviarMensaje
            // 
            this.btnEnviarMensaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnEnviarMensaje.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarMensaje.ForeColor = System.Drawing.Color.White;
            this.btnEnviarMensaje.Location = new System.Drawing.Point(889, 616);
            this.btnEnviarMensaje.Name = "btnEnviarMensaje";
            this.btnEnviarMensaje.Size = new System.Drawing.Size(75, 67);
            this.btnEnviarMensaje.TabIndex = 5;
            this.btnEnviarMensaje.UseVisualStyleBackColor = false;
            this.btnEnviarMensaje.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewMensajes
            // 
            this.dataGridViewMensajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMensajes.Location = new System.Drawing.Point(474, 70);
            this.dataGridViewMensajes.Name = "dataGridViewMensajes";
            this.dataGridViewMensajes.Size = new System.Drawing.Size(490, 531);
            this.dataGridViewMensajes.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.pictureBox1.Image = global::InterfazUsuario.Properties.Resources.mensaje;
            this.pictureBox1.Location = new System.Drawing.Point(901, 623);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelMensajes
            // 
            this.labelMensajes.AutoSize = true;
            this.labelMensajes.BackColor = System.Drawing.Color.Transparent;
            this.labelMensajes.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMensajes.Location = new System.Drawing.Point(20, 30);
            this.labelMensajes.Name = "labelMensajes";
            this.labelMensajes.Size = new System.Drawing.Size(104, 28);
            this.labelMensajes.TabIndex = 8;
            this.labelMensajes.Text = "Mensajes";
            // 
            // Mensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazUsuario.Properties.Resources.wallppaerLifora;
            this.ClientSize = new System.Drawing.Size(984, 711);
            this.Controls.Add(pictureBox2);
            this.Controls.Add(this.labelMensajes);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridViewMensajes);
            this.Controls.Add(this.btnEnviarMensaje);
            this.Controls.Add(this.richTextBoxMensajes);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridViewChats);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Mensajes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lifora";
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMensajes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewChats;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBoxMensajes;
        private System.Windows.Forms.Button btnEnviarMensaje;
        private System.Windows.Forms.DataGridView dataGridViewMensajes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelMensajes;
    }
}