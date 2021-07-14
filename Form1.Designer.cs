
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.customTab1 = new customTab();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.LineNumberBox = new System.Windows.Forms.RichTextBox();
            this.ZoomBar = new System.Windows.Forms.TrackBar();
            this.ErrorMsgBox = new System.Windows.Forms.RichTextBox();
            this.ErrorMsgLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(935, 24);
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
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(200, 100);
            this.tabPage1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(200, 100);
            this.tabPage2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(200, 100);
            this.tabPage3.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(200, 100);
            this.tabPage4.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(customTab1);
            this.tabControl1.Location = new System.Drawing.Point(32, 27);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(427, 412);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // customTab1
            // 
            this.customTab1.Location = new System.Drawing.Point(4, 24);
            this.customTab1.Name = "customTab1";
            this.customTab1.Size = new System.Drawing.Size(419, 384);
            this.customTab1.TabIndex = 0;
            this.customTab1.Text = "Untitled";
            this.customTab1.Visible = false;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(0, 0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(200, 100);
            this.tabPage5.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(0, 0);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(200, 100);
            this.tabPage6.TabIndex = 0;
            // 
            // LineNumberBox
            // 
            this.LineNumberBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LineNumberBox.Location = new System.Drawing.Point(8, 51);
            this.LineNumberBox.Name = "LineNumberBox";
            this.LineNumberBox.ReadOnly = true;
            this.LineNumberBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.LineNumberBox.Size = new System.Drawing.Size(22, 388);
            this.LineNumberBox.TabIndex = 2;
            this.LineNumberBox.Text = "";
            // 
            // ZoomBar
            // 
            this.ZoomBar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ZoomBar.Location = new System.Drawing.Point(255, 445);
            this.ZoomBar.Name = "ZoomBar";
            this.ZoomBar.Size = new System.Drawing.Size(200, 45);
            this.ZoomBar.TabIndex = 3;
            this.ZoomBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ZoomBar.Value = 1;
            this.ZoomBar.ValueChanged += new System.EventHandler(this.ZoomBar_ValueChanged);
            // 
            // ErrorMsgBox
            // 
            this.ErrorMsgBox.Location = new System.Drawing.Point(8, 496);
            this.ErrorMsgBox.Name = "ErrorMsgBox";
            this.ErrorMsgBox.ReadOnly = true;
            this.ErrorMsgBox.Size = new System.Drawing.Size(451, 68);
            this.ErrorMsgBox.TabIndex = 4;
            this.ErrorMsgBox.Text = "";
            // 
            // ErrorMsgLabel
            // 
            this.ErrorMsgLabel.AutoSize = true;
            this.ErrorMsgLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ErrorMsgLabel.Location = new System.Drawing.Point(12, 478);
            this.ErrorMsgLabel.Name = "ErrorMsgLabel";
            this.ErrorMsgLabel.Size = new System.Drawing.Size(103, 15);
            this.ErrorMsgLabel.TabIndex = 5;
            this.ErrorMsgLabel.Text = "ERROR MESSAGES";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // IBASICForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(935, 584);
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private customTab customTab1;
        private System.Windows.Forms.RichTextBox LineNumberBox;
        private System.Windows.Forms.TrackBar ZoomBar;
        private System.Windows.Forms.RichTextBox ErrorMsgBox;
        private System.Windows.Forms.Label ErrorMsgLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
