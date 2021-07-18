
namespace CS_IA_Ibasic_Intouch_Re
{
    partial class OpenForm
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
            this.LocalDButton = new System.Windows.Forms.Button();
            this.DriveButton = new System.Windows.Forms.Button();
            this.OpenLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.SuspendLayout();
            // 
            // LocalDButton
            // 
            this.LocalDButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LocalDButton.AutoSize = true;
            this.LocalDButton.Font = new System.Drawing.Font("Constantia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocalDButton.Location = new System.Drawing.Point(116, 247);
            this.LocalDButton.Name = "LocalDButton";
            this.LocalDButton.Size = new System.Drawing.Size(191, 75);
            this.LocalDButton.TabIndex = 0;
            this.LocalDButton.Text = "Local Drive";
            this.LocalDButton.UseVisualStyleBackColor = true;
            this.LocalDButton.Click += new System.EventHandler(this.LocalDButton_Click);
            // 
            // DriveButton
            // 
            this.DriveButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DriveButton.AutoSize = true;
            this.DriveButton.Font = new System.Drawing.Font("Constantia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriveButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DriveButton.Location = new System.Drawing.Point(451, 247);
            this.DriveButton.Name = "DriveButton";
            this.DriveButton.Size = new System.Drawing.Size(208, 75);
            this.DriveButton.TabIndex = 1;
            this.DriveButton.Text = "Google Drive";
            this.DriveButton.UseVisualStyleBackColor = true;
            this.DriveButton.Click += new System.EventHandler(this.DriveButton_Click);
            // 
            // OpenLabel
            // 
            this.OpenLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.OpenLabel.AutoSize = true;
            this.OpenLabel.Font = new System.Drawing.Font("Constantia", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenLabel.Location = new System.Drawing.Point(219, 117);
            this.OpenLabel.Name = "OpenLabel";
            this.OpenLabel.Size = new System.Drawing.Size(330, 59);
            this.OpenLabel.TabIndex = 2;
            this.OpenLabel.Text = "OPEN FROM:";
            this.OpenLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 450);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // OpenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.OpenLabel);
            this.Controls.Add(this.DriveButton);
            this.Controls.Add(this.LocalDButton);
            this.MaximumSize = new System.Drawing.Size(1000, 550);
            this.Name = "OpenForm";
            this.Text = "OpenForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LocalDButton;
        private System.Windows.Forms.Button DriveButton;
        private System.Windows.Forms.Label OpenLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Splitter splitter1;
    }
}