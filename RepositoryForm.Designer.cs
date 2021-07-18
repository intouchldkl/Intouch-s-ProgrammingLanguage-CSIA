
namespace CS_IA_Ibasic_Intouch_Re
{
    partial class RepositoryForm
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
            this.DriveReposLabel = new System.Windows.Forms.Label();
            this.FilelistView = new System.Windows.Forms.ListView();
            this.FileNamecolumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VersionListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DriveReposLabel);
            this.panel1.ForeColor = System.Drawing.Color.SlateGray;
            this.panel1.Location = new System.Drawing.Point(-4, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 109);
            this.panel1.TabIndex = 0;
            // 
            // DriveReposLabel
            // 
            this.DriveReposLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DriveReposLabel.AutoSize = true;
            this.DriveReposLabel.Font = new System.Drawing.Font("Constantia", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriveReposLabel.ForeColor = System.Drawing.Color.Navy;
            this.DriveReposLabel.Location = new System.Drawing.Point(232, 27);
            this.DriveReposLabel.Name = "DriveReposLabel";
            this.DriveReposLabel.Size = new System.Drawing.Size(362, 42);
            this.DriveReposLabel.TabIndex = 0;
            this.DriveReposLabel.Text = "DRIVE REPOSITORY";
            this.DriveReposLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FilelistView
            // 
            this.FilelistView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FilelistView.BackColor = System.Drawing.Color.LightSlateGray;
            this.FilelistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileNamecolumnHeader});
            this.FilelistView.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilelistView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FilelistView.FullRowSelect = true;
            this.FilelistView.HideSelection = false;
            this.FilelistView.Location = new System.Drawing.Point(-4, 114);
            this.FilelistView.Name = "FilelistView";
            this.FilelistView.Size = new System.Drawing.Size(301, 339);
            this.FilelistView.TabIndex = 1;
            this.FilelistView.UseCompatibleStateImageBehavior = false;
            this.FilelistView.View = System.Windows.Forms.View.Tile;
            this.FilelistView.Click += new System.EventHandler(this.FilelistView_Click);
            // 
            // FileNamecolumnHeader
            // 
            this.FileNamecolumnHeader.Text = "File Name:";
            this.FileNamecolumnHeader.Width = 100;
            // 
            // VersionListView
            // 
            this.VersionListView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.VersionListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionListView.BackColor = System.Drawing.Color.LightSlateGray;
            this.VersionListView.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionListView.FullRowSelect = true;
            this.VersionListView.HideSelection = false;
            this.VersionListView.Location = new System.Drawing.Point(303, 114);
            this.VersionListView.Name = "VersionListView";
            this.VersionListView.Size = new System.Drawing.Size(497, 339);
            this.VersionListView.TabIndex = 2;
            this.VersionListView.UseCompatibleStateImageBehavior = false;
            this.VersionListView.View = System.Windows.Forms.View.Tile;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSlateGray;
            this.label1.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(16, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "File Name:";
            // 
            // RepositoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VersionListView);
            this.Controls.Add(this.FilelistView);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.SlateGray;
            this.Name = "RepositoryForm";
            this.Text = "Drive Repository";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label DriveReposLabel;
        private System.Windows.Forms.ListView FilelistView;
        private System.Windows.Forms.ColumnHeader FileNamecolumnHeader;
        private System.Windows.Forms.ListView VersionListView;
        private System.Windows.Forms.Label label1;
    }
}