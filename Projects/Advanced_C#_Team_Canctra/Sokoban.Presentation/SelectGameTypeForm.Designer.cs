namespace Sokoban.Presentation
{
    partial class SelectGameTypeForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStandart = new System.Windows.Forms.Button();
            this.btnPractice = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPractice);
            this.panel1.Controls.Add(this.btnStandart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 189);
            this.panel1.TabIndex = 0;
            // 
            // btnStandart
            // 
            this.btnStandart.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStandart.Location = new System.Drawing.Point(59, 29);
            this.btnStandart.Name = "btnStandart";
            this.btnStandart.Size = new System.Drawing.Size(336, 51);
            this.btnStandart.TabIndex = 0;
            this.btnStandart.Text = "S T A N D A R T";
            this.btnStandart.UseVisualStyleBackColor = true;
            // 
            // btnPractice
            // 
            this.btnPractice.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPractice.Location = new System.Drawing.Point(59, 100);
            this.btnPractice.Name = "btnPractice";
            this.btnPractice.Size = new System.Drawing.Size(336, 51);
            this.btnPractice.TabIndex = 1;
            this.btnPractice.Text = "P R A C T I C E";
            this.btnPractice.UseVisualStyleBackColor = true;
            // 
            // SelectGameType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 189);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectGameType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Game";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPractice;
        private System.Windows.Forms.Button btnStandart;
    }
}