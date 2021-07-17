
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.panel1 = new System.Windows.Forms.Panel();
            this.DriveReposLabel = new System.Windows.Forms.Label();
            this.FilelistView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DriveReposLabel);
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
            this.DriveReposLabel.Location = new System.Drawing.Point(218, 35);
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
            this.FilelistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.FilelistView.HideSelection = false;
            this.FilelistView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.FilelistView.Location = new System.Drawing.Point(-4, 114);
            this.FilelistView.Name = "FilelistView";
            this.FilelistView.Size = new System.Drawing.Size(243, 339);
            this.FilelistView.TabIndex = 1;
            this.FilelistView.UseCompatibleStateImageBehavior = false;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(245, 114);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(555, 339);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // RepositoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
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
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listView1;
    }
}