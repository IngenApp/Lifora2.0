
namespace InterfazUsuario
{
    partial class CrearPost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearPost));
            this.btnWriting = new System.Windows.Forms.Button();
            this.btnPhotos = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.btnMusic = new System.Windows.Forms.Button();
            this.labelPostInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnWriting
            // 
            this.btnWriting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnWriting.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWriting.ForeColor = System.Drawing.Color.White;
            this.btnWriting.Location = new System.Drawing.Point(12, 90);
            this.btnWriting.Name = "btnWriting";
            this.btnWriting.Size = new System.Drawing.Size(150, 50);
            this.btnWriting.TabIndex = 5;
            this.btnWriting.Text = "button1";
            this.btnWriting.UseVisualStyleBackColor = false;
            this.btnWriting.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPhotos
            // 
            this.btnPhotos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnPhotos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhotos.ForeColor = System.Drawing.Color.White;
            this.btnPhotos.Location = new System.Drawing.Point(168, 90);
            this.btnPhotos.Name = "btnPhotos";
            this.btnPhotos.Size = new System.Drawing.Size(150, 50);
            this.btnPhotos.TabIndex = 6;
            this.btnPhotos.Text = "button2";
            this.btnPhotos.UseVisualStyleBackColor = false;
            this.btnPhotos.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnVideo
            // 
            this.btnVideo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnVideo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVideo.ForeColor = System.Drawing.Color.White;
            this.btnVideo.Location = new System.Drawing.Point(324, 90);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(150, 50);
            this.btnVideo.TabIndex = 7;
            this.btnVideo.Text = "button3";
            this.btnVideo.UseVisualStyleBackColor = false;
            this.btnVideo.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnMusic
            // 
            this.btnMusic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnMusic.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMusic.ForeColor = System.Drawing.Color.White;
            this.btnMusic.Location = new System.Drawing.Point(480, 90);
            this.btnMusic.Name = "btnMusic";
            this.btnMusic.Size = new System.Drawing.Size(150, 50);
            this.btnMusic.TabIndex = 8;
            this.btnMusic.Text = "button4";
            this.btnMusic.UseVisualStyleBackColor = false;
            this.btnMusic.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // labelPostInfo
            // 
            this.labelPostInfo.AutoSize = true;
            this.labelPostInfo.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPostInfo.Location = new System.Drawing.Point(124, 25);
            this.labelPostInfo.Name = "labelPostInfo";
            this.labelPostInfo.Size = new System.Drawing.Size(395, 28);
            this.labelPostInfo.TabIndex = 9;
            this.labelPostInfo.Text = "Seleccione el Post que desee compartir!";
            // 
            // CrearPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 161);
            this.Controls.Add(this.labelPostInfo);
            this.Controls.Add(this.btnMusic);
            this.Controls.Add(this.btnVideo);
            this.Controls.Add(this.btnPhotos);
            this.Controls.Add(this.btnWriting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrearPost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lifora";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWriting;
        private System.Windows.Forms.Button btnPhotos;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.Button btnMusic;
        private System.Windows.Forms.Label labelPostInfo;
    }
}