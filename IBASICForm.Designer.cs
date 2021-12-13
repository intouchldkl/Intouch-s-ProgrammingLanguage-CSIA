
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.LineNumberBox = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ErrorMsgLabel = new System.Windows.Forms.Label();
            this.ErrorMsgBox = new System.Windows.Forms.RichTextBox();
            this.CloseTabBut = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.autocompleteMenu1 = new AutocompleteMenuNS.AutocompleteMenu();
            this.FormatButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Lavender;
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
            this.menuStrip1.Size = new System.Drawing.Size(835, 24);
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
            this.PUBLISH.Enabled = false;
            this.PUBLISH.Name = "PUBLISH";
            this.PUBLISH.Size = new System.Drawing.Size(65, 20);
            this.PUBLISH.Text = "PUBLISH";
            this.PUBLISH.Click += new System.EventHandler(this.PUBLISH_Click);
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
            this.RUN.ShortcutKeys = System.Windows.Forms.Keys.F5;
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
            this.LOGIN.Click += new System.EventHandler(this.LOGIN_Click);
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
            // LineNumberBox
            // 
            this.LineNumberBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.autocompleteMenu1.SetAutocompleteMenu(this.LineNumberBox, null);
            this.LineNumberBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineNumberBox.Location = new System.Drawing.Point(3, 25);
            this.LineNumberBox.Name = "LineNumberBox";
            this.LineNumberBox.ReadOnly = true;
            this.LineNumberBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.LineNumberBox.Size = new System.Drawing.Size(30, 379);
            this.LineNumberBox.TabIndex = 2;
            this.LineNumberBox.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(48, 4);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(348, 400);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(340, 374);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Untitled";
            // 
            // ErrorMsgLabel
            // 
            this.ErrorMsgLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ErrorMsgLabel.AutoSize = true;
            this.ErrorMsgLabel.BackColor = System.Drawing.Color.LightSlateGray;
            this.ErrorMsgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorMsgLabel.Location = new System.Drawing.Point(23, 19);
            this.ErrorMsgLabel.Name = "ErrorMsgLabel";
            this.ErrorMsgLabel.Size = new System.Drawing.Size(122, 13);
            this.ErrorMsgLabel.TabIndex = 5;
            this.ErrorMsgLabel.Text = "ERROR MESSAGES";
            // 
            // ErrorMsgBox
            // 
            this.ErrorMsgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autocompleteMenu1.SetAutocompleteMenu(this.ErrorMsgBox, null);
            this.ErrorMsgBox.ForeColor = System.Drawing.Color.DarkRed;
            this.ErrorMsgBox.Location = new System.Drawing.Point(26, 46);
            this.ErrorMsgBox.Name = "ErrorMsgBox";
            this.ErrorMsgBox.ReadOnly = true;
            this.ErrorMsgBox.Size = new System.Drawing.Size(377, 95);
            this.ErrorMsgBox.TabIndex = 4;
            this.ErrorMsgBox.Text = "";
            // 
            // CloseTabBut
            // 
            this.CloseTabBut.ImageKey = "closeIcon.png";
            this.CloseTabBut.ImageList = this.imageList1;
            this.CloseTabBut.Location = new System.Drawing.Point(3, 3);
            this.CloseTabBut.Name = "CloseTabBut";
            this.CloseTabBut.Size = new System.Drawing.Size(30, 23);
            this.CloseTabBut.TabIndex = 6;
            this.CloseTabBut.UseVisualStyleBackColor = true;
            this.CloseTabBut.Click += new System.EventHandler(this.CloseTabBut_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.CloseTabBut);
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.LineNumberBox);
            this.splitContainer1.Panel1MinSize = 150;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.FormatButton);
            this.splitContainer1.Panel2.Controls.Add(this.ErrorMsgBox);
            this.splitContainer1.Panel2.Controls.Add(this.ErrorMsgLabel);
            this.splitContainer1.Panel2MinSize = 135;
            this.splitContainer1.Size = new System.Drawing.Size(395, 564);
            this.splitContainer1.SplitterDistance = 407;
            this.splitContainer1.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(0, 26);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel1MinSize = 400;
            this.splitContainer2.Panel2MinSize = 420;
            this.splitContainer2.Size = new System.Drawing.Size(835, 567);
            this.splitContainer2.SplitterDistance = 400;
            this.splitContainer2.TabIndex = 8;
            // 
            // autocompleteMenu1
            // 
            this.autocompleteMenu1.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("autocompleteMenu1.Colors")));
            this.autocompleteMenu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.autocompleteMenu1.ImageList = null;
            this.autocompleteMenu1.Items = new string[0];
            this.autocompleteMenu1.TargetControlWrapper = null;
            // 
            // FormatButton
            // 
            this.FormatButton.BackColor = System.Drawing.Color.Azure;
            this.FormatButton.Location = new System.Drawing.Point(295, 8);
            this.FormatButton.Name = "FormatButton";
            this.FormatButton.Size = new System.Drawing.Size(75, 23);
            this.FormatButton.TabIndex = 6;
            this.FormatButton.Text = "FORMAT";
            this.FormatButton.UseVisualStyleBackColor = false;
            this.FormatButton.Click += new System.EventHandler(this.FormatButton_Click);
            // 
            // IBASICForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(835, 593);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IBASICForm";
            this.Text = "IBASIC";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
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
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private ImageList imageList1;
        private RichTextBox LineNumberBox;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button CloseTabBut;
        private Label ErrorMsgLabel;
        private RichTextBox ErrorMsgBox;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenu1;
        private Button FormatButton;
    }
}
