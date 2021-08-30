
namespace CS_IA_Ibasic_Intouch_Re
{
    partial class PublishForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublishForm));
            this.Publishlabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.OutputBut = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.PublishBut = new System.Windows.Forms.Button();
            this.FileNameBox = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // Publishlabel
            // 
            this.Publishlabel.AutoSize = true;
            this.Publishlabel.Font = new System.Drawing.Font("Constantia", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Publishlabel.Location = new System.Drawing.Point(277, 93);
            this.Publishlabel.Name = "Publishlabel";
            this.Publishlabel.Size = new System.Drawing.Size(236, 59);
            this.Publishlabel.TabIndex = 0;
            this.Publishlabel.Text = "PUBLISH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(152, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "File name:";
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Font = new System.Drawing.Font("Constantia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputLabel.Location = new System.Drawing.Point(59, 209);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(271, 26);
            this.OutputLabel.TabIndex = 2;
            this.OutputLabel.Text = "Screenshot of your output:";
            // 
            // OutputBut
            // 
            this.OutputBut.ImageIndex = 0;
            this.OutputBut.ImageList = this.imageList1;
            this.OutputBut.Location = new System.Drawing.Point(377, 212);
            this.OutputBut.Name = "OutputBut";
            this.OutputBut.Size = new System.Drawing.Size(75, 23);
            this.OutputBut.TabIndex = 3;
            this.OutputBut.UseVisualStyleBackColor = true;
            this.OutputBut.Click += new System.EventHandler(this.OutputBut_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "AddIcon.jpg");
            // 
            // PublishBut
            // 
            this.PublishBut.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PublishBut.Location = new System.Drawing.Point(564, 311);
            this.PublishBut.Name = "PublishBut";
            this.PublishBut.Size = new System.Drawing.Size(75, 23);
            this.PublishBut.TabIndex = 4;
            this.PublishBut.Text = "Publish";
            this.PublishBut.UseVisualStyleBackColor = true;
            this.PublishBut.Click += new System.EventHandler(this.PublishBut_Click);
            // 
            // FileNameBox
            // 
            this.FileNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameBox.Location = new System.Drawing.Point(272, 311);
            this.FileNameBox.Name = "FileNameBox";
            this.FileNameBox.Size = new System.Drawing.Size(276, 29);
            this.FileNameBox.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PublishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FileNameBox);
            this.Controls.Add(this.PublishBut);
            this.Controls.Add(this.OutputBut);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Publishlabel);
            this.MaximumSize = new System.Drawing.Size(1000, 800);
            this.Name = "PublishForm";
            this.Text = "Publish";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Publishlabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.Button OutputBut;
        private System.Windows.Forms.Button PublishBut;
        private System.Windows.Forms.TextBox FileNameBox;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}