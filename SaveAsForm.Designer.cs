
namespace CS_IA_Ibasic_Intouch_Re
{
    partial class SaveAsForm
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SaveAsLabel = new System.Windows.Forms.Label();
            this.LocalDBut = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveAsLabel
            // 
            this.SaveAsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SaveAsLabel.AutoSize = true;
            this.SaveAsLabel.Font = new System.Drawing.Font("Constantia", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveAsLabel.Location = new System.Drawing.Point(277, 115);
            this.SaveAsLabel.Name = "SaveAsLabel";
            this.SaveAsLabel.Size = new System.Drawing.Size(232, 59);
            this.SaveAsLabel.TabIndex = 0;
            this.SaveAsLabel.Text = "SAVE TO:";
            this.SaveAsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LocalDBut
            // 
            this.LocalDBut.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LocalDBut.AutoSize = true;
            this.LocalDBut.Font = new System.Drawing.Font("Constantia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocalDBut.Location = new System.Drawing.Point(116, 247);
            this.LocalDBut.Name = "LocalDBut";
            this.LocalDBut.Size = new System.Drawing.Size(191, 75);
            this.LocalDBut.TabIndex = 1;
            this.LocalDBut.Text = "Local Drive";
            this.LocalDBut.UseVisualStyleBackColor = true;
            this.LocalDBut.Click += new System.EventHandler(this.LocalDBut_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.AutoSize = true;
            this.button2.Font = new System.Drawing.Font("Constantia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(451, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 75);
            this.button2.TabIndex = 2;
            this.button2.Text = "Google Drive";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SaveAsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.LocalDBut);
            this.Controls.Add(this.SaveAsLabel);
            this.MaximumSize = new System.Drawing.Size(1000, 550);
            this.Name = "SaveAsForm";
            this.Text = "SaveAsForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label SaveAsLabel;
        private System.Windows.Forms.Button LocalDBut;
        private System.Windows.Forms.Button button2;
    }
}