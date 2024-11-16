
namespace InterfazUsuario
{
    partial class PostTextoMostrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostTextoMostrar));
            this.labelApodo = new System.Windows.Forms.LinkLabel();
            this.labelFecha = new System.Windows.Forms.Label();
            this.lblComentarios = new System.Windows.Forms.LinkLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblLikes = new System.Windows.Forms.LinkLabel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Report = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // labelApodo
            // 
            this.labelApodo.AutoSize = true;
            this.labelApodo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApodo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.labelApodo.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.labelApodo.Location = new System.Drawing.Point(20, 10);
            this.labelApodo.Name = "labelApodo";
            this.labelApodo.Size = new System.Drawing.Size(77, 24);
            this.labelApodo.TabIndex = 8;
            this.labelApodo.TabStop = true;
            this.labelApodo.Text = "Apodo";
            this.labelApodo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(686, 12);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(52, 21);
            this.labelFecha.TabIndex = 20;
            this.labelFecha.Text = "label2";
            this.labelFecha.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblComentarios
            // 
            this.lblComentarios.AutoSize = true;
            this.lblComentarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblComentarios.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComentarios.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblComentarios.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(109)))), ((int)(((byte)(206)))));
            this.lblComentarios.Location = new System.Drawing.Point(141, 126);
            this.lblComentarios.Name = "lblComentarios";
            this.lblComentarios.Size = new System.Drawing.Size(43, 18);
            this.lblComentarios.TabIndex = 35;
            this.lblComentarios.TabStop = true;
            this.lblComentarios.Text = "10000";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::InterfazUsuario.Properties.Resources.comentar;
            this.pictureBox3.Location = new System.Drawing.Point(105, 114);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 34;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::InterfazUsuario.Properties.Resources.Like;
            this.pictureBox2.Location = new System.Drawing.Point(24, 114);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lblLikes
            // 
            this.lblLikes.AutoSize = true;
            this.lblLikes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLikes.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLikes.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblLikes.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.lblLikes.Location = new System.Drawing.Point(60, 126);
            this.lblLikes.Name = "lblLikes";
            this.lblLikes.Size = new System.Drawing.Size(43, 18);
            this.lblLikes.TabIndex = 32;
            this.lblLikes.TabStop = true;
            this.lblLikes.Text = "10000";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(24, 37);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(740, 69);
            this.richTextBox1.TabIndex = 36;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // Report
            // 
            this.Report.BackColor = System.Drawing.Color.Transparent;
            this.Report.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Report.Image = global::InterfazUsuario.Properties.Resources.Reportar;
            this.Report.Location = new System.Drawing.Point(734, 114);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(30, 30);
            this.Report.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Report.TabIndex = 37;
            this.Report.TabStop = false;
            this.Report.Click += new System.EventHandler(this.Report_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = global::InterfazUsuario.Properties.Resources.Edit;
            this.pictureBox6.Location = new System.Drawing.Point(744, 12);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(20, 20);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 39;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // PostTextoMostrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 155);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.Report);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblComentarios);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblLikes);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.labelApodo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PostTextoMostrar";
            this.Text = "Post";
            this.Load += new System.EventHandler(this.PostTextoMostrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel labelApodo;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.LinkLabel lblComentarios;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel lblLikes;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox Report;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}