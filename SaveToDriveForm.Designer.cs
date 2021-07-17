
namespace CS_IA_Ibasic_Intouch_Re
{
    partial class SaveToDriveForm
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
            this.SaveToDrivelabel = new System.Windows.Forms.Label();
            this.FileNameBox = new System.Windows.Forms.TextBox();
            this.FileNamelabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // SaveToDrivelabel
            // 
            this.SaveToDrivelabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SaveToDrivelabel.AutoSize = true;
            this.SaveToDrivelabel.Font = new System.Drawing.Font("Constantia", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveToDrivelabel.Location = new System.Drawing.Point(192, 67);
            this.SaveToDrivelabel.Name = "SaveToDrivelabel";
            this.SaveToDrivelabel.Size = new System.Drawing.Size(431, 59);
            this.SaveToDrivelabel.TabIndex = 0;
            this.SaveToDrivelabel.Text = "SAVE TO GDRIVE:";
            this.SaveToDrivelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FileNameBox
            // 
            this.FileNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.FileNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameBox.Location = new System.Drawing.Point(277, 245);
            this.FileNameBox.Name = "FileNameBox";
            this.FileNameBox.Size = new System.Drawing.Size(224, 29);
            this.FileNameBox.TabIndex = 1;
            // 
            // FileNamelabel
            // 
            this.FileNamelabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FileNamelabel.AutoSize = true;
            this.FileNamelabel.Font = new System.Drawing.Font("Constantia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNamelabel.Location = new System.Drawing.Point(125, 244);
            this.FileNamelabel.Name = "FileNamelabel";
            this.FileNamelabel.Size = new System.Drawing.Size(134, 29);
            this.FileNamelabel.TabIndex = 2;
            this.FileNamelabel.Text = "File Name:";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(548, 244);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 29);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SaveToDriveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.FileNamelabel);
            this.Controls.Add(this.FileNameBox);
            this.Controls.Add(this.SaveToDrivelabel);
            this.MaximumSize = new System.Drawing.Size(1000, 800);
            this.Name = "SaveToDriveForm";
            this.Text = "SAVE TO GDRIVE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SaveToDrivelabel;
        private System.Windows.Forms.TextBox FileNameBox;
        private System.Windows.Forms.Label FileNamelabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}