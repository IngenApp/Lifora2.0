
namespace InterfazUsuario
{
    partial class VerComentarPost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerComentarPost));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnComentarPost = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Report = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Report)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(400, 404);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnComentarPost
            // 
            this.btnComentarPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnComentarPost.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComentarPost.ForeColor = System.Drawing.Color.White;
            this.btnComentarPost.Location = new System.Drawing.Point(314, 485);
            this.btnComentarPost.Margin = new System.Windows.Forms.Padding(2);
            this.btnComentarPost.Name = "btnComentarPost";
            this.btnComentarPost.Size = new System.Drawing.Size(126, 50);
            this.btnComentarPost.TabIndex = 32;
            this.btnComentarPost.Text = "Comentar";
            this.btnComentarPost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnComentarPost.UseVisualStyleBackColor = false;
            this.btnComentarPost.Click += new System.EventHandler(this.btnComentarPost_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(40, 485);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(269, 50);
            this.richTextBox1.TabIndex = 33;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 28);
            this.label1.TabIndex = 34;
            this.label1.Text = "Comentarios";
            // 
            // Report
            // 
            this.Report.BackColor = System.Drawing.Color.Transparent;
            this.Report.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Report.Image = global::InterfazUsuario.Properties.Resources.Reportar;
            this.Report.Location = new System.Drawing.Point(442, 70);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(30, 30);
            this.Report.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Report.TabIndex = 38;
            this.Report.TabStop = false;
            this.Report.Click += new System.EventHandler(this.Report_Click);
            // 
            // VerComentarPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::InterfazUsuario.Properties.Resources.wallppaerLifora;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.Report);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnComentarPost);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VerComentarPost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lifora";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Report)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnComentarPost;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Report;
    }
}