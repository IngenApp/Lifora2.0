
namespace InterfazUsuario
{
    partial class CrearPostAudio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearPostAudio));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnCrearPost = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelCrearPost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(20, 70);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(500, 49);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(20, 125);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(500, 118);
            this.axWindowsMediaPlayer1.TabIndex = 1;
            // 
            // btnCrearPost
            // 
            this.btnCrearPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnCrearPost.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearPost.ForeColor = System.Drawing.Color.White;
            this.btnCrearPost.Location = new System.Drawing.Point(372, 249);
            this.btnCrearPost.Name = "btnCrearPost";
            this.btnCrearPost.Size = new System.Drawing.Size(150, 50);
            this.btnCrearPost.TabIndex = 3;
            this.btnCrearPost.Text = "button1";
            this.btnCrearPost.UseVisualStyleBackColor = false;
            this.btnCrearPost.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(182)))), ((int)(((byte)(182)))));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::InterfazUsuario.Properties.Resources.adjunto;
            this.pictureBox2.Location = new System.Drawing.Point(316, 249);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // labelCrearPost
            // 
            this.labelCrearPost.AutoSize = true;
            this.labelCrearPost.BackColor = System.Drawing.Color.Transparent;
            this.labelCrearPost.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCrearPost.Location = new System.Drawing.Point(20, 30);
            this.labelCrearPost.Name = "labelCrearPost";
            this.labelCrearPost.Size = new System.Drawing.Size(235, 28);
            this.labelCrearPost.TabIndex = 60;
            this.labelCrearPost.Text = "Que quieres compartir?";
            this.labelCrearPost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CrearPostAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazUsuario.Properties.Resources.wallpaperEmergente;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.labelCrearPost);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnCrearPost);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrearPostAudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lifora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CrearPostAudio_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button btnCrearPost;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelCrearPost;
    }
}