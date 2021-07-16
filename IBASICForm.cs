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
        static GGDrive myDrive = new GGDrive();
        public IBASICForm()
        {
            InitializeComponent();
            RichTextBox RTB = new RichTextBox();
            tabPage1.Controls.Add(RTB);
            currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            currentRtb.AcceptsTab = true;
            currentRtb.Dock = DockStyle.Fill;
            //To allow both scrollbars
            currentRtb.ScrollBars = RichTextBoxScrollBars.Both;
            // To allow horizontal scroll bar to work by unlimiting the wordwrap
            currentRtb.WordWrap = false;
            currentRtb.TextChanged += currentRtb_TextChanged;
            currentRtb.VScroll += CurrentRtb_VScroll;
            currentRtb.Font = new Font("Microsoft Sans Serif", 9.5F,FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }

        private void ZoomBar_ValueChanged(object sender, EventArgs e)
        {
 
            currentRtb.ZoomFactor = ZoomBar.Value;
            LineNumberBox.ZoomFactor = ZoomBar.Value;

        }
        private void New_Click(object sender, EventArgs e)
        {
            createNewTabPage();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            createNewTabPage();
            OpenForm openForm = new OpenForm(currentRtb, tabControl1.SelectedTab);
            openForm.Show();
            AddLineNumbers();
                currentRtb.TextChanged += currentRtb_TextChanged;
                currentRtb.VScroll += CurrentRtb_VScroll;
            
            
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
            SaveAsForm saveasform = new SaveAsForm(currentRtb);
            saveasform.Show();

          
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
            LineNumberBox.ZoomFactor = ZoomBar.Value;
            currentRtb.ZoomFactor = ZoomBar.Value;
            AddLineNumbers();
            currentRtb.TextChanged += currentRtb_TextChanged;
            currentRtb.VScroll += CurrentRtb_VScroll;
        }
        public void createNewTabPage()
        {
            RichTextBox rtb = new RichTextBox();
            rtb.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            rtb.AcceptsTab = true;
            rtb.Dock = DockStyle.Fill;
            //To allow both scrollbars
            rtb.ScrollBars = RichTextBoxScrollBars.Both;
            // To allow horizontal scroll bar to work by unlimiting the wordwrap
            rtb.WordWrap = false;
            rtb.TextChanged += currentRtb_TextChanged;
            rtb.VScroll += CurrentRtb_VScroll;
            TabPage newTab = new TabPage();
            tabControl1.Controls.Add(newTab);
            newTab.Controls.Add(rtb);
            newTab.Text = "Untitled";
            tabControl1.SelectedTab = newTab;
            currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            ///Make sure the user see the new tab
            AddLineNumbers();
            currentRtb.ZoomFactor = ZoomBar.Value;
            LineNumberBox.ZoomFactor = ZoomBar.Value;
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
                currentRtb.ZoomFactor = ZoomBar.Value;
                LineNumberBox.ZoomFactor = ZoomBar.Value;
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
            currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
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
            LineNumberBox.ZoomFactor = ZoomBar.Value;
        }

        private void currentRtb_TextChanged(object sender, EventArgs e)
        {            
                AddLineNumbers();
        }
        private void CurrentRtb_VScroll(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

        private void LOGIN_Click(object sender, EventArgs e)
        {
              if(LOGIN.Text == "LOGIN")
                {
                myDrive.Authentication();
                LOGIN.Text = "LOGOUT";
                }
            else
            {
                myDrive.logout();
                LOGIN.Text = "LOGIN";
            }
          

        }
    }
}
