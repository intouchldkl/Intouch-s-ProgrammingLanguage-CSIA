
using System.Windows.Forms;

namespace CS_IA_Ibasic_Intouch_Re
{
    partial class IBASICForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IBASICForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.NEW = new System.Windows.Forms.ToolStripMenuItem();
            this.OPEN = new System.Windows.Forms.ToolStripMenuItem();
            this.SAVE = new System.Windows.Forms.ToolStripMenuItem();
            this.SAVEAS = new System.Windows.Forms.ToolStripMenuItem();
            this.PUBLISH = new System.Windows.Forms.ToolStripMenuItem();
            this.UNDO = new System.Windows.Forms.ToolStripMenuItem();
            this.REDO = new System.Windows.Forms.ToolStripMenuItem();
            this.RUN = new System.Windows.Forms.ToolStripMenuItem();
            this.LOGIN = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LineNumberBox = new System.Windows.Forms.RichTextBox();
            this.ZoomBar = new System.Windows.Forms.TrackBar();
            this.ErrorMsgBox = new System.Windows.Forms.RichTextBox();
            this.ErrorMsgLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.CloseTabBut = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomBar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NEW,
            this.OPEN,
            this.SAVE,
            this.SAVEAS,
            this.PUBLISH,
            this.UNDO,
            this.REDO,
            this.RUN,
            this.LOGIN});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(801, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // NEW
            // 
            this.NEW.Name = "NEW";
            this.NEW.Size = new System.Drawing.Size(45, 20);
            this.NEW.Text = "NEW";
            this.NEW.Click += new System.EventHandler(this.New_Click);
            // 
            // OPEN
            // 
            this.OPEN.Name = "OPEN";
            this.OPEN.Size = new System.Drawing.Size(50, 20);
            this.OPEN.Text = "OPEN";
            this.OPEN.Click += new System.EventHandler(this.Open_Click);
            // 
            // SAVE
            // 
            this.SAVE.Name = "SAVE";
            this.SAVE.Size = new System.Drawing.Size(45, 20);
            this.SAVE.Text = "SAVE";
            this.SAVE.Click += new System.EventHandler(this.Save_Click);
            // 
            // SAVEAS
            // 
            this.SAVEAS.Name = "SAVEAS";
            this.SAVEAS.Size = new System.Drawing.Size(62, 20);
            this.SAVEAS.Text = "SAVE AS";
            this.SAVEAS.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // PUBLISH
            // 
            this.PUBLISH.Name = "PUBLISH";
            this.PUBLISH.Size = new System.Drawing.Size(65, 20);
            this.PUBLISH.Text = "PUBLISH";
            // 
            // UNDO
            // 
            this.UNDO.Name = "UNDO";
            this.UNDO.Size = new System.Drawing.Size(53, 20);
            this.UNDO.Text = "UNDO";
            this.UNDO.Click += new System.EventHandler(this.Undo_Click);
            // 
            // REDO
            // 
            this.REDO.Name = "REDO";
            this.REDO.Size = new System.Drawing.Size(49, 20);
            this.REDO.Text = "REDO";
            this.REDO.Click += new System.EventHandler(this.Redo_Click);
            // 
            // RUN
            // 
            this.RUN.Name = "RUN";
            this.RUN.Size = new System.Drawing.Size(43, 20);
            this.RUN.Text = "RUN";
            this.RUN.Click += new System.EventHandler(this.Run_Click);
            // 
            // LOGIN
            // 
            this.LOGIN.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LOGIN.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.LOGIN.Name = "LOGIN";
            this.LOGIN.Size = new System.Drawing.Size(54, 20);
            this.LOGIN.Text = "LOGIN";
            this.LOGIN.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(358, 331);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Untitled";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(27, 23);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(366, 357);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // LineNumberBox
            // 
            this.LineNumberBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LineNumberBox.Location = new System.Drawing.Point(7, 44);
            this.LineNumberBox.Name = "LineNumberBox";
            this.LineNumberBox.ReadOnly = true;
            this.LineNumberBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.LineNumberBox.Size = new System.Drawing.Size(19, 337);
            this.LineNumberBox.TabIndex = 2;
            this.LineNumberBox.Text = "";
            // 
            // ZoomBar
            // 
            this.ZoomBar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ZoomBar.Location = new System.Drawing.Point(219, 386);
            this.ZoomBar.Name = "ZoomBar";
            this.ZoomBar.Size = new System.Drawing.Size(171, 45);
            this.ZoomBar.TabIndex = 3;
            this.ZoomBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ZoomBar.Value = 1;
            this.ZoomBar.ValueChanged += new System.EventHandler(this.ZoomBar_ValueChanged);
            // 
            // ErrorMsgBox
            // 
            this.ErrorMsgBox.Location = new System.Drawing.Point(7, 430);
            this.ErrorMsgBox.Name = "ErrorMsgBox";
            this.ErrorMsgBox.ReadOnly = true;
            this.ErrorMsgBox.Size = new System.Drawing.Size(387, 59);
            this.ErrorMsgBox.TabIndex = 4;
            this.ErrorMsgBox.Text = "";
            // 
            // ErrorMsgLabel
            // 
            this.ErrorMsgLabel.AutoSize = true;
            this.ErrorMsgLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ErrorMsgLabel.Location = new System.Drawing.Point(10, 414);
            this.ErrorMsgLabel.Name = "ErrorMsgLabel";
            this.ErrorMsgLabel.Size = new System.Drawing.Size(108, 13);
            this.ErrorMsgLabel.TabIndex = 5;
            this.ErrorMsgLabel.Text = "ERROR MESSAGES";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Xicon.png");
            this.imageList1.Images.SetKeyName(1, "closeIcon.png");
            // 
            // CloseTabBut
            // 
            this.CloseTabBut.ImageKey = "closeIcon.png";
            this.CloseTabBut.ImageList = this.imageList1;
            this.CloseTabBut.Location = new System.Drawing.Point(7, 23);
            this.CloseTabBut.Name = "CloseTabBut";
            this.CloseTabBut.Size = new System.Drawing.Size(19, 24);
            this.CloseTabBut.TabIndex = 6;
            this.CloseTabBut.UseVisualStyleBackColor = true;
            this.CloseTabBut.Click += new System.EventHandler(this.CloseTabBut_Click);
            // 
            // IBASICForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(801, 506);
            this.Controls.Add(this.CloseTabBut);
            this.Controls.Add(this.ErrorMsgLabel);
            this.Controls.Add(this.ErrorMsgBox);
            this.Controls.Add(this.ZoomBar);
            this.Controls.Add(this.LineNumberBox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "IBASICForm";
            this.Text = "IBASIC";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZoomBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem NEW;
        private System.Windows.Forms.ToolStripMenuItem OPEN;
        private System.Windows.Forms.ToolStripMenuItem SAVE;
        private System.Windows.Forms.ToolStripMenuItem SAVEAS;
        private System.Windows.Forms.ToolStripMenuItem PUBLISH;
        private System.Windows.Forms.ToolStripMenuItem UNDO;
        private System.Windows.Forms.ToolStripMenuItem REDO;
        private System.Windows.Forms.ToolStripMenuItem RUN;
        private System.Windows.Forms.ToolStripMenuItem LOGIN;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;     
        private System.Windows.Forms.RichTextBox LineNumberBox;
        private System.Windows.Forms.TrackBar ZoomBar;
        private System.Windows.Forms.RichTextBox ErrorMsgBox;
        private System.Windows.Forms.Label ErrorMsgLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private ImageList imageList1;
        private Button CloseTabBut;
    }
}
