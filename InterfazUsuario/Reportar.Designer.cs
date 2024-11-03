
namespace InterfazUsuario
{
    partial class Reportar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reportar));
            this.btnReportarSi = new System.Windows.Forms.Button();
            this.btnReportarNo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReportarSi
            // 
            this.btnReportarSi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.btnReportarSi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportarSi.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportarSi.ForeColor = System.Drawing.Color.White;
            this.btnReportarSi.Location = new System.Drawing.Point(11, 50);
            this.btnReportarSi.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportarSi.Name = "btnReportarSi";
            this.btnReportarSi.Size = new System.Drawing.Size(126, 50);
            this.btnReportarSi.TabIndex = 33;
            this.btnReportarSi.Text = "SI";
            this.btnReportarSi.UseVisualStyleBackColor = false;
            this.btnReportarSi.Click += new System.EventHandler(this.btnReportarSi_Click);
            // 
            // btnReportarNo
            // 
            this.btnReportarNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(131)))), ((int)(((byte)(83)))));
            this.btnReportarNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportarNo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportarNo.ForeColor = System.Drawing.Color.White;
            this.btnReportarNo.Location = new System.Drawing.Point(141, 50);
            this.btnReportarNo.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportarNo.Name = "btnReportarNo";
            this.btnReportarNo.Size = new System.Drawing.Size(126, 50);
            this.btnReportarNo.TabIndex = 34;
            this.btnReportarNo.Text = "NO";
            this.btnReportarNo.UseVisualStyleBackColor = false;
            this.btnReportarNo.Click += new System.EventHandler(this.btnReportarNo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 28);
            this.label1.TabIndex = 35;
            this.label1.Text = "Reportar?";
            // 
            // Reportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 113);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReportarNo);
            this.Controls.Add(this.btnReportarSi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reportar";
            this.Text = "Lifora";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReportarSi;
        private System.Windows.Forms.Button btnReportarNo;
        private System.Windows.Forms.Label label1;
    }
}