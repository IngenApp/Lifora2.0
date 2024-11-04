
namespace InterfazUsuario
{
    partial class CrearPostTexto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearPostTexto));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnCrearPost = new System.Windows.Forms.Button();
            this.labelCrearPost = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(20, 70);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(500, 73);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnCrearPost
            // 
            this.btnCrearPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.btnCrearPost.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearPost.ForeColor = System.Drawing.Color.White;
            this.btnCrearPost.Location = new System.Drawing.Point(372, 149);
            this.btnCrearPost.Name = "btnCrearPost";
            this.btnCrearPost.Size = new System.Drawing.Size(150, 50);
            this.btnCrearPost.TabIndex = 1;
            this.btnCrearPost.Text = "button1";
            this.btnCrearPost.UseVisualStyleBackColor = false;
            this.btnCrearPost.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelCrearPost
            // 
            this.labelCrearPost.AutoSize = true;
            this.labelCrearPost.BackColor = System.Drawing.Color.Transparent;
            this.labelCrearPost.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCrearPost.Location = new System.Drawing.Point(20, 30);
            this.labelCrearPost.Name = "labelCrearPost";
            this.labelCrearPost.Size = new System.Drawing.Size(235, 28);
            this.labelCrearPost.TabIndex = 59;
            this.labelCrearPost.Text = "Que quieres compartir?";
            this.labelCrearPost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CrearPostTexto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazUsuario.Properties.Resources.wallppaerLifora;
            this.ClientSize = new System.Drawing.Size(534, 211);
            this.Controls.Add(this.labelCrearPost);
            this.Controls.Add(this.btnCrearPost);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrearPostTexto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lifora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CrearPostTexto_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnCrearPost;
        private System.Windows.Forms.Label labelCrearPost;
    }
}