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
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace CS_IA_Ibasic_Intouch_Re
{
    public partial class IBASICForm : Form
    {
        // To keep track of where the current textBox is as the tab changes
        RichTextBox currentRtb = new RichTextBox();
        static IBASICForm instance;
        int lineNumber;
        public IBASICForm()
        {
            InitializeComponent();
            initialliseAutoCompleteMenuItem();
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
            currentRtb.Font = new Font("Microsoft Sans Serif", 9.5F,FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            autocompleteMenu1.SetAutocompleteMenu(currentRtb, autocompleteMenu1);
            if(Directory.Exists("token.json") == true)
            {
                LOGIN.Text = "LOGOUT";
            }


        }
        public static IBASICForm Instance
        {
            get { return instance ?? (instance = new IBASICForm()); }
        }
        public TabPage getCurrentTabpage()
        {
            return tabControl1.SelectedTab;
        }
        public RichTextBox getCurrentRtb()
        {
            return currentRtb;
        }
        private void ZoomBar_ValueChanged(object sender, EventArgs e)
        {
            currentRtb.ZoomFactor = ZoomBar.Value;
            LineNumberBox.ZoomFactor = ZoomBar.Value;
        }
        private void New_Click(object sender, EventArgs e)
        {
            createNewTabPage("Untitled");
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenForm openForm = new OpenForm();
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
            SaveAsForm saveasform = new SaveAsForm();
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
            ErrorMsgBox.Clear();
            IBASICtranslator translator = new IBASICtranslator(currentRtb.Lines);
            ///  currentRtb.Text = translator.Tcasestatement();
            translator.putinFormat();
           /// currentRtb.Text = translator.getTranslatedcode();
           if(translator.getIBASICerrormessages() == null)
            {
                Compiler Icompiler = new Compiler(translator.getTranslatedcode());
                Icompiler.launchEXE();
                if (Icompiler.getErrorMessages() != null)
                {
                    ErrorMsgBox.Text =  Icompiler.getErrorMessages();
                }
            }
            else
            {
                ErrorMsgBox.Text = translator.getIBASICerrormessages();
            }

           
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            currentRtb.ZoomFactor = ZoomBar.Value;
            AddLineNumbers();
            LineNumberBox.ZoomFactor = ZoomBar.Value;
            currentRtb.TextChanged += currentRtb_TextChanged;
            currentRtb.VScroll += CurrentRtb_VScroll;
            syntaxhighlight();
        }
        public void createNewTabPage(string tabName)
        {
            RichTextBox rtb = new RichTextBox();
            rtb.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
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
            newTab.Text = tabName;
            tabControl1.SelectedTab = newTab;
            currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            ///Make sure the user see the new tab
            AddLineNumbers();
            currentRtb.ZoomFactor = ZoomBar.Value;
            LineNumberBox.ZoomFactor = ZoomBar.Value;
            autocompleteMenu1.SetAutocompleteMenu(currentRtb, autocompleteMenu1);
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
            RichTextBox buffer = new RichTextBox();           
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
            buffer.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            buffer.Text = "";
            buffer.Width = getWidth();
            // now add each line number to LineNumberTextBox upto last line    
            for (int i = First_Line; i <= Last_Line + 2; i++)
            {
                buffer.Text += i + 1 + "\n";
            }
            LineNumberBox.SelectionAlignment = HorizontalAlignment.Center;
            LineNumberBox.Width = getWidth();
            LineNumberBox.Text = buffer.Text;
            LineNumberBox.ZoomFactor = ZoomBar.Value;
        }

        private void currentRtb_TextChanged(object sender, EventArgs e)
        {            
                AddLineNumbers();
                syntaxhighlight();            
            LineNumberBox.ZoomFactor = ZoomBar.Value;
        }
        private void CurrentRtb_VScroll(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

        private void LOGIN_Click(object sender, EventArgs e)
        {
              if(LOGIN.Text == "LOGIN")
                {
                GGDrive.Instance.Authentication();
                LOGIN.Text = "LOGOUT";
                }
            else
            {
                GGDrive.Instance.logout();
                LOGIN.Text = "LOGIN";
            }
          

        }

        private void PUBLISH_Click(object sender, EventArgs e)
        {
            PublishForm publishForm = new PublishForm();
            publishForm.Show();
        }
        private void syntaxhighlight()
        {
            int cursorPosition = currentRtb.GetFirstCharIndexOfCurrentLine();
                lineNumber = currentRtb.GetLineFromCharIndex(cursorPosition);

            if (currentRtb.Text == "")
            {
                return;
            }
            // getting keywords from the text
            string Bkeywords = @"\b(?i)(DECLARE|IF|ENDIF|THEN|ELSEIF|ELSE|FOR|TO|NEXT|WHILE|DO|ENDWHILE|REPEAT|UNTIL|CASE|OF|OTHERWISE|ENDCASE|:|AND|OR|STEP|TRUE|FALSE)\b";
            MatchCollection BkeywordMatches = Regex.Matches(currentRtb.Lines[lineNumber], Bkeywords);
            string Gkeywords = @"\b(?i)(OUTPUT|INPUT)\b";
            MatchCollection GkeywordMatches = Regex.Matches(currentRtb.Lines[lineNumber], Gkeywords);
            string Pkeywords = @"\b(?i)(FUNCTION|ENDFUNCTION|CALL|PROCEDURE|ENDPROCEDURE)\b";
            MatchCollection PkeywordMatches = Regex.Matches(currentRtb.Lines[lineNumber], Pkeywords);
            string Ykeywords = @"\b(MOD|DIV|LENGTH|SUBSTRING|UCASE|LCASE|RANDOM|ROUND)\b";
            MatchCollection YkeywordMatches = Regex.Matches(currentRtb.Lines[lineNumber], Ykeywords);
            // getting types/classes from the text 
            string types = @"\b(?i)(INTEGER|CHAR|STRING|REAL|BOOLEAN)\b";
            MatchCollection typeMatches = Regex.Matches(currentRtb.Lines[lineNumber], types);

            // getting comments (inline or multiline)
            string comments = @"(\/.+?$|'.+?$)";
            MatchCollection commentMatches = Regex.Matches(currentRtb.Lines[lineNumber], comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(currentRtb.Lines[lineNumber], strings);

            // saving the original caret position + forecolor
            int originalIndex = currentRtb.SelectionStart;
            int originalLength = currentRtb.SelectionLength;
            Color originalColor = Color.Black;
            // removes any previous highlighting (so modified words won't remain highlighted)
            currentRtb.SelectionStart = cursorPosition;
            currentRtb.SelectionLength = currentRtb.Lines[lineNumber].Length;
            currentRtb.SelectionColor = originalColor;
            // scanning...
            foreach (Match m in BkeywordMatches)
            {
                currentRtb.SelectionStart = m.Index + cursorPosition;
                currentRtb.SelectionLength = m.Length ;
                currentRtb.SelectionColor = Color.Blue ;
            }
            foreach (Match m in GkeywordMatches)
            {
                currentRtb.SelectionStart = m.Index + cursorPosition;
                currentRtb.SelectionLength = m.Length;
                currentRtb.SelectionColor = Color.DarkCyan;
            }
            foreach (Match m in PkeywordMatches)
            {
                currentRtb.SelectionStart = m.Index + cursorPosition;
                currentRtb.SelectionLength = m.Length;
                currentRtb.SelectionColor = Color.Purple;
            }
            foreach (Match m in YkeywordMatches)
            {
                currentRtb.SelectionStart = m.Index + cursorPosition;
                currentRtb.SelectionLength = m.Length;
                currentRtb.SelectionColor = Color.DarkGoldenrod;
            }

            foreach (Match m in typeMatches)
            {
                currentRtb.SelectionStart = m.Index + cursorPosition;
                currentRtb.SelectionLength = m.Length;
                currentRtb.SelectionColor = Color.Orange;
            }
            foreach (Match m in commentMatches)
            {
                currentRtb.SelectionStart = m.Index + cursorPosition;
                currentRtb.SelectionLength = m.Length;
                currentRtb.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                currentRtb.SelectionStart = m.Index + cursorPosition;
                currentRtb.SelectionLength = m.Length;
                currentRtb.SelectionColor = Color.Brown;
            }

            // restoring the original colors, for further writing
            currentRtb.SelectionStart = originalIndex;
            currentRtb.SelectionLength = originalLength;
            currentRtb.SelectionColor = originalColor;
        }
        private void initialliseAutoCompleteMenuItem()
        {
            autocompleteMenu1.AddItem("OUTPUT ");
            autocompleteMenu1.AddItem("INPUT ");
            autocompleteMenu1.AddItem("DECLARE ");
            autocompleteMenu1.AddItem("STRING");
            autocompleteMenu1.AddItem("INTEGER");
            autocompleteMenu1.AddItem("CHAR");
            autocompleteMenu1.AddItem("REAL");
            autocompleteMenu1.AddItem("BOOLEAN");
            autocompleteMenu1.AddItem("TRUE");
            autocompleteMenu1.AddItem("FALSE");
            autocompleteMenu1.AddItem("FOR ");
            autocompleteMenu1.AddItem("TO ");
            autocompleteMenu1.AddItem("NEXT ");
            autocompleteMenu1.AddItem("WHILE ");
            autocompleteMenu1.AddItem("DO");
            autocompleteMenu1.AddItem("ENDWHILE");
            autocompleteMenu1.AddItem("IF ");
            autocompleteMenu1.AddItem("THEN");
            autocompleteMenu1.AddItem("ELSE");
            autocompleteMenu1.AddItem("ELSEIF");
            autocompleteMenu1.AddItem("ENDIF");
            autocompleteMenu1.AddItem("STEP");
            autocompleteMenu1.AddItem("CASE OF ");
            autocompleteMenu1.AddItem("CASE ");
            autocompleteMenu1.AddItem("AND ");
            autocompleteMenu1.AddItem("OR ");
            autocompleteMenu1.AddItem("OTHERWISE ");
            autocompleteMenu1.AddItem("ENDCASE ");
            autocompleteMenu1.AddItem("FUNCTION ");
            autocompleteMenu1.AddItem("RETURNS ");
            autocompleteMenu1.AddItem("RETURN ");
            autocompleteMenu1.AddItem("ENDFUNCTION");
            autocompleteMenu1.AddItem("PROCEDURE ");
            autocompleteMenu1.AddItem("ENDPROCEDURE");
            autocompleteMenu1.AddItem("CALL");
            autocompleteMenu1.AddItem("MOD()");
            autocompleteMenu1.AddItem("DIV()");
            autocompleteMenu1.AddItem("UCASE()");
            autocompleteMenu1.AddItem("LCASE()");
            autocompleteMenu1.AddItem("LENGTH()");
            autocompleteMenu1.AddItem("SUBSTRING()");
            autocompleteMenu1.AddItem("ROUND()");
            autocompleteMenu1.AddItem("RANDOM()");
            autocompleteMenu1.AddItem("ARRAY[]");
        }




    }
}
