using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CS_IA_Ibasic_Intouch_Re
{
    public partial class IBASICForm : Form
    {
        // To keep track of where the current textBox is as the tab changes
        RichTextBox currentRtb = new RichTextBox();
        public IBASICForm()
        {
            InitializeComponent();
            tabPage1.Controls.Add(new RichTextBox());
            currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            currentRtb.AcceptsTab = true;
            currentRtb.Dock = DockStyle.Fill;
            //To allow both scrollbars
            currentRtb.ScrollBars = RichTextBoxScrollBars.Both;
            // To allow horizontal scroll bar to work by unlimiting the wordwrap
            currentRtb.WordWrap = false;
            currentRtb.TextChanged += currentRtb_TextChanged;
            currentRtb.VScroll += CurrentRtb_VScroll;
        }

        private void ZoomBar_ValueChanged(object sender, EventArgs e)
        {
            /// Zoomfactor cant be <= 0
            if (ZoomBar.Value <= 0)
            {
                ZoomBar.Value = 1;
            }
            currentRtb.ZoomFactor = ZoomBar.Value;
            currentRtb.TextChanged += currentRtb_TextChanged;
            currentRtb.VScroll += CurrentRtb_VScroll;

        }
        private void New_Click(object sender, EventArgs e)
        {
            TabPage newTab = new TabPage();
            tabControl1.Controls.Add(newTab);
            newTab.Controls.Add(new RichTextBox());
            newTab.Text = "Untitled";
            currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            ///Make sure the user see the new tab
            tabControl1.SelectedTab = newTab;
            ///  currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            currentRtb.AcceptsTab = true;
            currentRtb.Dock = DockStyle.Fill;
            //To allow both scrollbars
            currentRtb.ScrollBars = RichTextBoxScrollBars.Both;
            // To allow horizontal scroll bar to work by unlimiting the wordwrap
            currentRtb.WordWrap = false;
            AddLineNumbers();
            currentRtb.TextChanged += currentRtb_TextChanged;
            currentRtb.VScroll += CurrentRtb_VScroll;

        }

        private void Open_Click(object sender, EventArgs e)
        {
            // Open file 

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                createNewTabPage();
                // Open & read file
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    currentRtb.Text = sr.ReadToEnd();
                    sr.Close();
                   tabControl1.SelectedTab.Text = openFileDialog1.SafeFileName;
                }
                AddLineNumbers();
                currentRtb.TextChanged += currentRtb_TextChanged;
                currentRtb.VScroll += CurrentRtb_VScroll;
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            // Save file 

            if (saveFileDialog1.FileName != "")
            {
                StreamWriter CodeToBeSaved = new StreamWriter(saveFileDialog1.FileName);
                CodeToBeSaved.Write(currentRtb.Text);
                CodeToBeSaved.Close();
            }
            else
            {
                SAVEAS.PerformClick();
            }
        }
        private void SaveAs_Click(object sender, EventArgs e)
        {
            // Save file as 

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter CodeToBeSaved = new StreamWriter(saveFileDialog1.FileName);
                CodeToBeSaved.Write(currentRtb.Text);
                CodeToBeSaved.Close();

            }
        }
        private void Undo_Click(object sender, EventArgs e)
        {
            currentRtb.Undo();
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            currentRtb.Redo();
        }
        private void Run_Click(object sender, EventArgs e)
        {
            Compiler Icompiler = new Compiler(currentRtb.Text);
            Icompiler.launchEXE();
           
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            //ZoomFactor cant be <= 0
            if (ZoomBar.Value <= 0)
            {
                ZoomBar.Value = 1;
            }
            currentRtb.ZoomFactor = ZoomBar.Value;
            AddLineNumbers();
            currentRtb.TextChanged += currentRtb_TextChanged;
            currentRtb.VScroll += CurrentRtb_VScroll;
        }
        private void createNewTabPage()
        {
            TabPage newTab = new TabPage();
            tabControl1.Controls.Add(newTab);
            newTab.Controls.Add(new RichTextBox());
            newTab.Text = "Untitled";
            currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            ///Make sure the user see the new tab
            tabControl1.SelectedTab = newTab;
            ///  currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            currentRtb.AcceptsTab = true;
            currentRtb.Dock = DockStyle.Fill;
            //To allow both scrollbars
            currentRtb.ScrollBars = RichTextBoxScrollBars.Both;
            // To allow horizontal scroll bar to work by unlimiting the wordwrap
            currentRtb.WordWrap = false;
            AddLineNumbers();
            currentRtb.TextChanged += currentRtb_TextChanged;
            currentRtb.VScroll += CurrentRtb_VScroll;
        }

        private void CloseTabBut_Click(object sender, EventArgs e)
        {
            if( tabControl1.Controls.Count > 1)
            {
                tabControl1.Controls.Remove(tabControl1.SelectedTab);
                currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                AddLineNumbers();
                currentRtb.TextChanged += currentRtb_TextChanged;
                currentRtb.VScroll += CurrentRtb_VScroll;
            }
        }
        public int getWidth()
        {
            int w = 25;
            // get total lines of currentRtb    
            int line = currentRtb.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)currentRtb.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)currentRtb.Font.Size;
            }
            else
            {
                w = 50 + (int)currentRtb.Font.Size;
            }

            return w;
        }
        public void AddLineNumbers()
        {
            // create & set Point pt to (0,0)    
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTextBox1    
            int First_Index = currentRtb.GetCharIndexFromPosition(pt);
            int First_Line = currentRtb.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1    
            int Last_Index =currentRtb.GetCharIndexFromPosition(pt);
            int Last_Line = currentRtb.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumberTextBox    
           LineNumberBox.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            LineNumberBox.Text = "";
            LineNumberBox.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line    
            for (int i = First_Line; i <= Last_Line + 2; i++)
            {
                LineNumberBox.Text += i + 1 + "\n";
            }
        }

        private void currentRtb_TextChanged(object sender, EventArgs e)
        {            
                AddLineNumbers();
        }
        private void CurrentRtb_VScroll(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

    }
}
