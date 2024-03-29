﻿using System;
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
using CefSharp.WinForms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using CefSharp;
using CefSharp.Handler;
using System.Windows.Media;
using Color = System.Drawing.Color;
using System.Threading;
using System.Xml.Serialization;
using System.Xml;

namespace CS_IA_Ibasic_Intouch_Re
{
    public partial class IBASICForm : Form
    {
        /// <summary>
        /// Freeze the screen
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="wMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;
        // To keep track of where the current textBox is as the tab changes
        public RichTextBox currentRtb = new RichTextBox();
        static IBASICForm instance;
        private float zoomfactor;
        ChromiumWebBrowser browser;
        private int tablevel = 0;
        private List<string> Keywords;
        private string[] keywords;
        private string[] keywords1 = new string[] { "ElseIf ", "Else" };
        private string[] keywords2;
        private List<string> varnames = new List<string>();
        private int[] tabsize = new int[32];
        private string Bkeywords =  "\\" + "b(?i)(";
        private string Gkeywords = "\\" + "b(?i)(";
        private string Pkeywords = "\\" + "b(?i)(";
        private string types = "\\" + "b(?i)(";
        public IBASICForm()
        {
            //Get the syntax from XML file
            if (File.Exists(@"C:\Users\ADMINS\Source\Repos\CS-IA-Ibasic-Intouch-Re\XMLsyntax.xml"))
            {
                XmlSerializer ser = new XmlSerializer(typeof(XMLdata.Syntax));
                XMLdata.Syntax syntax = new XMLdata.Syntax();
                using (XmlReader reader = XmlReader.Create(@"C:\Users\ADMINS\Source\Repos\CS-IA-Ibasic-Intouch-Re\XMLsyntax.xml"))
                {
                    syntax = (XMLdata.Syntax)ser.Deserialize(reader);
                }
                Keywords = syntax.CommandWords.Item;


            }
            //Assign values to keywords for auto indentation algorithm
            keywords = new string[] { "If ", "For ", "While ", "Case Of ",
                                                    Keywords[29], Keywords[33], "Repeat " };
            keywords2 = new string[] { "EndIf", "EndWhile", "EndCase",
                                                    Keywords[32], Keywords[34], "Until ", "Next " };
            InitializeComponent();
            //Create a ChromiumWebBrowser object and pass in my web page's URL
            browser = new ChromiumWebBrowser("https://sites.google.com/view/ibasic-tutorials/home?authuser=1 ")
            {
                Dock = DockStyle.Fill//Set Dock to fill so it covers the entire area
            };
            splitContainer2.Panel2.Controls.Add(browser);//Add the webpage to the area allocated
            initialliseAutoCompleteMenuItem();
            //Initialise the richtextbox and its properties
            RichTextBox RTB = new RichTextBox();
            tabPage1.Controls.Add(RTB); //Add the rtb to the tab control
            currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            currentRtb.AcceptsTab = true;
            currentRtb.Dock = DockStyle.Fill; //Make sure the rtb filled the given area
            //To allow both scrollbars
            currentRtb.ScrollBars = RichTextBoxScrollBars.Both;
            // To allow horizontal scroll bar to work by unlimiting the wordwrap
            currentRtb.WordWrap = false;
            currentRtb.AcceptsTab = true;
            //Assign all the event handlers
            currentRtb.TextChanged += currentRtb_TextChanged;
            currentRtb.VScroll += CurrentRtb_VScroll;
            currentRtb.KeyUp += CurrentRtb_KeyUp;
            currentRtb.MouseWheel += CurrentRtb_mouse;
            currentRtb.Font = new Font("Microsoft Sans Serif",
                9.5F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            currentRtb.SelectAll();
            int increment = 0;
            for (int i = 0; i < 32; i++)//Loop to 32 because tabsize can only have 32 elements
            {
                tabsize[i] = increment += 20; //set value to the tabsize to 20 increments
            }
            currentRtb.SelectionTabs = tabsize; // Assign new value to the tab size
            autocompleteMenu1.SetAutocompleteMenu(currentRtb, autocompleteMenu1);
            if (Directory.Exists("token.json") == true)
            {
                LOGIN.Text = "LOGOUT";
            }
            if (isLogin() == true)
            {
                PUBLISH.Enabled = true;
            }
            // getting keywords from the text
            for (int i = 9; i < 28; i++)
            {
                Bkeywords += Keywords[i].Trim() + "|";
            }
            Bkeywords +=  Keywords[3].Trim() + "|" + Keywords[38].Trim() + "|" + Keywords[39].Trim() + "|" + Keywords[37].Trim() + "|" + ":)" +"\\b" ;
            for (int i = 0; i < 3; i++)
            {
                Gkeywords += Keywords[i].Trim() + "|";
            }
            Gkeywords += Keywords[36].Trim() + ")" + "\\b";
            for (int i = 29; i < 36; i++)
            {
                if (i == 35)
                {
                    Pkeywords += Keywords[i].Trim();
                }
                else
                {
                    Pkeywords += Keywords[i].Trim() + "|";
                }
            }
            Pkeywords += ")"+"\\b";
            for (int i = 4; i < 9; i++)
            {
                if( i == 8)
                {
                    types += Keywords[i].Trim();
                }
                else
                {
                    types += Keywords[i].Trim() + "|";
                }
                
            }
            types += ")" + "\\b";
        }
        /// <summary>
        /// Initialise a singleton pattern
        /// </summary>
        public static IBASICForm Instance
        {
            get { return instance ?? (instance = new IBASICForm()); }
        }
        /// <summary>
        /// return current tabpage
        /// </summary>
        /// <returns></returns>current tabpage
        public TabPage getCurrentTabpage()
        {
            return tabControl1.SelectedTab;
        }
        /// <summary>
        /// return current rtb
        /// </summary>
        /// <returns></returns>current rtb
        public RichTextBox getCurrentRtb()
        {
            return currentRtb;
        }
        /// <summary>
        /// Create new tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void New_Click(object sender, EventArgs e)
        {
            createNewTabPage("Untitled");
        }
        /// <summary>
        /// open open form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Click(object sender, EventArgs e)
        {
            OpenForm openForm = new OpenForm();
            openForm.Show();
            AddLineNumbers();
            currentRtb.TextChanged += currentRtb_TextChanged;
            currentRtb.VScroll += CurrentRtb_VScroll;
        }
        /// <summary>
        /// either automatically save file if its already been saved to locald or open saveAsForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Invoked when the SaveAs button is clicked and display SaveAsForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAs_Click(object sender, EventArgs e)
        {
            //Create a new SaveAsForm object
            SaveAsForm saveasform = new SaveAsForm();
            saveasform.Show(); //Display the form
        }
        /// <summary>
        /// Undo last change on coding box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Undo_Click(object sender, EventArgs e)
        {
            currentRtb.Undo();
        }
        /// <summary>
        /// redo last change on coding box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Redo_Click(object sender, EventArgs e)
        {
            currentRtb.Redo();
        }
        /// <summary>
        /// Invoked the run button is clicked and will translate and 
        /// compile the code from current richtextbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Run_Click(object sender, EventArgs e)
        {
            //Clear the ErrorMsgBox to avoid confusion from the old error messages
            ErrorMsgBox.Clear();
            IBASICtranslator translator = new IBASICtranslator(currentRtb.Lines);
            //Translate IBASIC code and put in the correct VB format
            translator.putinFormat();
            if (translator.getIBASICerrormessages() == null)//no error message then..
            {
                Compiler Icompiler = new Compiler(translator.getTranslatedcode());
                //Launch the compiled result
                Icompiler.launchEXE();
                if (Icompiler.getErrorMessages() != null)//If there is internal error
                {
                    //Send the error messages to ErrorMsgBox
                    ErrorMsgBox.Text = Icompiler.getErrorMessages();
                }
            }
            else
            {
                //If there's error message from the translator then
                //Send the error message to the ErrorMsgBox
                ErrorMsgBox.Text = translator.getIBASICerrormessages();
            }
        }
        /// <summary>
        /// Change content of coding box when new tab is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            zoomfactor = LineNumberBox.ZoomFactor;
            currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            AddLineNumbers();
            currentRtb.ZoomFactor = zoomfactor;
            LineNumberBox.ZoomFactor = zoomfactor;
            currentRtb.TextChanged += currentRtb_TextChanged;
            currentRtb.VScroll += CurrentRtb_VScroll;
            syntaxhighlightall(currentRtb);


        }
        /// <summary>
        /// create a new tab page
        /// </summary>
        /// <param name="tabName"></param>
        public void createNewTabPage(string tabName)
        {
            zoomfactor = LineNumberBox.ZoomFactor;
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
            rtb.KeyUp += CurrentRtb_KeyUp;
            rtb.MouseWheel += CurrentRtb_mouse;
            TabPage newTab = new TabPage();
            tabControl1.Controls.Add(newTab);
            newTab.Controls.Add(rtb);
            newTab.Text = tabName;
            tabControl1.SelectedTab = newTab;
            currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            currentRtb.SelectionTabs = tabsize;
            AddLineNumbers();
            currentRtb.ZoomFactor = zoomfactor;
            LineNumberBox.ZoomFactor = zoomfactor;
            autocompleteMenu1.SetAutocompleteMenu(currentRtb, autocompleteMenu1);


        }
        /// <summary>
        /// delete a tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseTabBut_Click(object sender, EventArgs e)
        {
            //Make sure there's always at least 1 tab remaining
            if (tabControl1.Controls.Count > 1)
            {
                tabControl1.Controls.Remove(tabControl1.SelectedTab);
                currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                // reset the linnumber and text on the rtb
                AddLineNumbers();
                currentRtb.TextChanged += currentRtb_TextChanged;
                currentRtb.VScroll += CurrentRtb_VScroll;
            }
        }
       /// <summary>
       /// Add line number algorithm
       /// </summary>
        public void AddLineNumbers()
        {
            currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            zoomfactor = LineNumberBox.ZoomFactor;
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
            int Last_Index = currentRtb.GetCharIndexFromPosition(pt);
            int Last_Line = currentRtb.GetLineFromCharIndex(Last_Index);
            //  add each line number to LineNumberTextBox upto last line    
            for (int i = First_Line; i <= Last_Line + 1; i++)
            {
                buffer.Text += i + 1 + "\n";
            }
            LineNumberBox.SelectionAlignment = HorizontalAlignment.Right;
            //   LineNumberBox.Width = getWidth();
            LineNumberBox.Text = buffer.Text;
            LineNumberBox.ZoomFactor = zoomfactor;
        }
        /// <summary>
        /// if text change add line number, perform syntax highlight *cause flickering here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void currentRtb_TextChanged(object sender, EventArgs e)
        {
            AddLineNumbers();
            syntaxhighlight();
            zoomfactor = LineNumberBox.ZoomFactor;
            if (tabControl1.SelectedTab.Text.Last() != '*')
            {
                tabControl1.SelectedTab.Text += '*';
            }

            LineNumberBox.ZoomFactor = zoomfactor;
            currentRtb.ZoomFactor = zoomfactor;

        }
        /// <summary>
        /// Change line number as the scrollbar is scrolled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentRtb_VScroll(object sender, EventArgs e)
        {
            AddLineNumbers();
        }
        /// <summary>
        /// Log the user in or out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LOGIN_Click(object sender, EventArgs e)
        {
            if (LOGIN.Text == "LOGIN")
            {
                GGDrive.Instance.Authentication();
                PUBLISH.Enabled = true;
                LOGIN.Text = "LOGOUT";
                MessageBox.Show("YOU ARE LOGGED IN TO YOUR CURRENT GMAIL", "IBASIC");
            }
            else
            {
                GGDrive.Instance.logout();
                PUBLISH.Enabled = false;
                LOGIN.Text = "LOGIN";
                MessageBox.Show("YOU ARE LOGGED OUT!", "IBASIC");
            }


        }
        /// <summary>
        /// Open pubish form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PUBLISH_Click(object sender, EventArgs e)
        {
            PublishForm publishForm = new PublishForm();
            publishForm.Show();
        }
        /// <summary>
        /// Use regex to perform syntax highlighting on the current line
        /// </summary>
        public void syntaxhighlight()
        {
            int cursorPosition = currentRtb.GetFirstCharIndexOfCurrentLine() ;
            int lineNumber = currentRtb.GetLineFromCharIndex(cursorPosition) ;
            // if (lineNumber < 0) lineNumber = 0;
            if (currentRtb.Text == "" || currentRtb.Lines[lineNumber] == null)
            {
                return;
            }
            SendMessage(Handle, WM_SETREDRAW, false, 0);
            MatchCollection BkeywordMatches = Regex.Matches(currentRtb.Lines[lineNumber], Bkeywords);
            MatchCollection GkeywordMatches = Regex.Matches(currentRtb.Lines[lineNumber], Gkeywords);
            MatchCollection PkeywordMatches = Regex.Matches(currentRtb.Lines[lineNumber], Pkeywords);
            string Ykeywords = @"\b(MOD|DIV|LENGTH|SUBSTRING|UCASE|LCASE|ROUND|CONVERTTOSTRING|GETRANDOMNUMBER)\b";
            MatchCollection YkeywordMatches = Regex.Matches(currentRtb.Lines[lineNumber], Ykeywords);
            MatchCollection typeMatches = Regex.Matches(currentRtb.Lines[lineNumber], types);
            // getting comments (inline or multiline)
            string comments = @"\//.+?$";
            MatchCollection commentMatches = Regex.Matches(currentRtb.Lines[lineNumber], comments, RegexOptions.Multiline);
            // getting strings
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(currentRtb.Lines[lineNumber], strings);
            // saving the original caret position + forecolor
            int originalIndex = currentRtb.SelectionStart;
            int originalLength = currentRtb.SelectionLength;
            System.Drawing.Color originalColor = System.Drawing.Color.Black;
            // removes any previous highlighting (so modified words won't remain highlighted)
            currentRtb.SelectionStart = cursorPosition;
            currentRtb.SelectionLength = currentRtb.Lines[lineNumber].Length;
            currentRtb.SelectionColor = originalColor;
            // scanning...
            foreach (Match m in BkeywordMatches)
            {
                currentRtb.SelectionStart = m.Index + cursorPosition;
                currentRtb.SelectionLength = m.Length;
                currentRtb.SelectionColor = Color.Blue;
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

            SendMessage(Handle, WM_SETREDRAW, true, 0);
            Refresh();
        }
        /// <summary>
        /// Use regex to perform syntax highlighting on all lines
        /// </summary>
        /// <param name="textbox"></param>
        public void syntaxhighlightall(RichTextBox textbox)
        {
            RichTextBox Rtb = new RichTextBox();
            Rtb.Rtf = textbox.Rtf;
            if (Rtb.Text == "")
            {
                return;
            }
            MatchCollection BkeywordMatches = Regex.Matches(Rtb.Text, Bkeywords);
            MatchCollection GkeywordMatches = Regex.Matches(Rtb.Text, Gkeywords);
            MatchCollection PkeywordMatches = Regex.Matches(Rtb.Text, Pkeywords);
            string Ykeywords = @"\b(MOD|DIV|LENGTH|SUBSTRING|UCASE|LCASE|ROUND|CONVERTTOSTRING|GETRANDOMNUMBER)\b";
            MatchCollection YkeywordMatches = Regex.Matches(Rtb.Text, Ykeywords);
            // getting types/classes from the text 
            MatchCollection typeMatches = Regex.Matches(Rtb.Text, types);

            // getting comments (inline or multiline)
            string comments = @"\//.+?$";
            MatchCollection commentMatches = Regex.Matches(Rtb.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(Rtb.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = Rtb.SelectionStart;
            int originalLength = Rtb.SelectionLength;
            Color originalColor = Color.Black;
            // removes any previous highlighting (so modified words won't remain highlighted)
            Rtb.SelectionStart = 0;
            Rtb.SelectionLength = Rtb.Text.Length;
            Rtb.SelectionColor = originalColor;
            // scanning...
            foreach (Match m in BkeywordMatches)
            {
                Rtb.SelectionStart = m.Index;
                Rtb.SelectionLength = m.Length;
                Rtb.SelectionColor = Color.Blue;
            }
            foreach (Match m in GkeywordMatches)
            {
                Rtb.SelectionStart = m.Index;
                Rtb.SelectionLength = m.Length;
                Rtb.SelectionColor = Color.DarkCyan;
            }
            foreach (Match m in PkeywordMatches)
            {
                Rtb.SelectionStart = m.Index;
                Rtb.SelectionLength = m.Length;
                Rtb.SelectionColor = Color.Purple;
            }
            foreach (Match m in YkeywordMatches)
            {
                Rtb.SelectionStart = m.Index;
                Rtb.SelectionLength = m.Length;
                Rtb.SelectionColor = Color.DarkGoldenrod;
            }

            foreach (Match m in typeMatches)
            {
                Rtb.SelectionStart = m.Index;
                Rtb.SelectionLength = m.Length;
                Rtb.SelectionColor = Color.Orange;
            }
            foreach (Match m in commentMatches)
            {
                Rtb.SelectionStart = m.Index;
                Rtb.SelectionLength = m.Length;
                Rtb.SelectionColor = Color.Green;
            }

            foreach (Match m in stringMatches)
            {
                Rtb.SelectionStart = m.Index;
                Rtb.SelectionLength = m.Length;
                Rtb.SelectionColor = Color.Brown;
            }
            textbox.Rtf = Rtb.Rtf;
        }
        /// <summary>
        /// Add keywords to auto comlete menu
        /// </summary>
        private void initialliseAutoCompleteMenuItem()
        {
            for (int i = 0; i < Keywords.Count; i++)
            {
                autocompleteMenu1.AddItem(Keywords[i]);
            }
            autocompleteMenu1.AddItem("MOD()");
            autocompleteMenu1.AddItem("DIV()");
            autocompleteMenu1.AddItem("UCASE()");
            autocompleteMenu1.AddItem("LCASE()");
            autocompleteMenu1.AddItem("LENGTH()");
            autocompleteMenu1.AddItem("SUBSTRING()");
            autocompleteMenu1.AddItem("ROUND()");
            autocompleteMenu1.AddItem("GETRANDOMNUMBER()");
            autocompleteMenu1.AddItem("ARRAY[]");
            autocompleteMenu1.AddItem("CONVERTTOSTRING()");

        }
        /// <summary>
        /// Checj whether the user is logged in or not
        /// </summary>
        /// <returns></returns>
        public bool isLogin()
        {
            if (LOGIN.Text == "LOGOUT")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Update the position of keywords (affect tab level)
        /// </summary>
        public void UpdateIndentLevel(int index)
        {
            //Set the value of current zoomfactor
            zoomfactor = LineNumberBox.ZoomFactor;
            //Retrieve the current linenumber of the rtb
            int lineIndex = currentRtb.GetLineFromCharIndex(index) - 1;
            string[] lines = currentRtb.Lines;
            int lineNumber = currentRtb.GetLineFromCharIndex(currentRtb.GetFirstCharIndexOfCurrentLine());
            //If there is no line then return
            if (lineIndex < 0) lineIndex = 0;
            if (currentRtb.Lines.Length <= 0) return;
            string line = currentRtb.Lines[lineIndex];
            //Loop to check first type of keywords eg Elseif
            for (int i = 0; i < keywords1.Length; i++)
            {
                if (checkKeyword(keywords1[i], line))
                {
                    //Send the message to win32 to freeze the screen
                    SendMessage(Handle, WM_SETREDRAW, false, 0);
                    //Proceed to reset the position
                    lines[lineIndex] = getIndentSpace(tablevel - 1) + currentRtb.Lines[lineIndex].Replace("\t", "");
                    currentRtb.Lines = lines;
                    //Give the rtb all its properties back
                    int charindex = currentRtb.GetFirstCharIndexFromLine(lineNumber)
                        + currentRtb.Lines[lineNumber].Length;
                    syntaxhighlightall(currentRtb);
                    currentRtb.Select(charindex, 0);
                    currentRtb.ZoomFactor = zoomfactor;
                    //Unfreeze the screen
                    SendMessage(Handle, WM_SETREDRAW, true, 0);
                    Refresh();
                    return;
                }
            }
            //Loop to check another type of keywords2 eg EndIf
            for (int i = 0; i < keywords2.Length; i++)
            {
                if (checkKeyword(keywords2[i], line))
                {
                    //Send the message to win32 to freeze the screen
                    SendMessage(Handle, WM_SETREDRAW, false, 0);
                    //Proceed to reset the position
                    lines[lineIndex] = getIndentSpace(tablevel) + currentRtb.Lines[lineIndex].Replace("\t", "");
                    currentRtb.Lines = lines;
                    //Give the rtb all its properties back
                    int charindex = currentRtb.GetFirstCharIndexFromLine(lineNumber) + currentRtb.Lines[lineNumber].Length;
                    syntaxhighlightall(currentRtb);
                    currentRtb.Select(charindex, 0);
                    currentRtb.ZoomFactor = zoomfactor;
                    //Unfreeze the screen
                    SendMessage(Handle, WM_SETREDRAW, true, 0);
                    Refresh();
                    return;
                }
            }
        }
        /// <summary>
        /// Update the keyword position such as elseif and endif ( doesnt affect tab level)
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public string UpdateIndentLevel(string line)
        {

            //Loop to check first type of keywords eg Elseif
            for (int i = 0; i < keywords1.Length; i++)
            {
                if (checkKeyword(keywords1[i], line))
                {
                    line = getIndentSpace(tablevel - 1) + line.Replace("\t", "");
                    return line;
                }
            }
            //Loop to check another type of keywords2 eg EndIf
            for (int i = 0; i < keywords2.Length; i++)
            {
                if (checkKeyword(keywords2[i], line))
                {
                    line = getIndentSpace(tablevel) + line.Replace("\t", "");
                    return line;
                }
            }
            return line;
        }

        /// <summary>
        /// Retrives the space given by tablevel
        /// </summary>
        /// <param name="tablevel"></param> Current tab level
        /// <returns></returns> spaces
        public string getIndentSpace(int tablevel)
        {
            string spaces = "";
            for (int i = 0; i < tablevel; i++)// Loops til the tab level
            {
                spaces = spaces + "\t";//Add spaces until it reaches the tablevel
            }
            return spaces;
        }
        /// <summary>
        /// Check if keyword matches
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="line"></param>
        /// <returns></returns>True or False
        public bool checkKeyword(string keyword, string line)
        {
            if (keyword.Length > line.TrimStart().Length) return false;
            return StringExtension.Contains(line.TrimStart().Substring(0, keyword.Length), keyword);

        }
        /// <summary>
        /// Implement auto indentation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentRtb_KeyUp(object sender, KeyEventArgs e)
        {
            //Set the value of zoomfactor
            zoomfactor = LineNumberBox.ZoomFactor;
            if (e.KeyCode == Keys.Enter) //When enter key is pressed
            {
                //Get the linenumber
                int lineNumber = currentRtb.GetLineFromCharIndex(currentRtb.GetFirstCharIndexOfCurrentLine());
                //Add variable names to intelisense
                addVariableNames();
                //Check the indentlevel
                checkindent(currentRtb.GetLineFromCharIndex(currentRtb.GetFirstCharIndexOfCurrentLine()));
                if (currentRtb.Lines[lineNumber] == "")//If it's a new line
                {
                    try
                    {
                        string[] linesOfCurrentrtb;
                        // Lock Window...
                        LockWindowUpdate(Handle);
                        UpdateIndentLevel(currentRtb.GetFirstCharIndexOfCurrentLine());//Reset position of Keywords1&2
                        checkindent(currentRtb.GetLineFromCharIndex(currentRtb.GetFirstCharIndexOfCurrentLine()));//Check Indentlevel again
                        linesOfCurrentrtb = currentRtb.Lines;//Store to a temp array to prevent runtime interface issue
                        //Implement identation
                        linesOfCurrentrtb[lineNumber] = getIndentSpace(tablevel);
                        //Give all its properties back
                        currentRtb.Lines = linesOfCurrentrtb;
                        syntaxhighlightall(currentRtb);
                        currentRtb.ZoomFactor = (float)(zoomfactor + 0.0000001);
                        //Put the cursor back on the appropriate position
                        currentRtb.Select(currentRtb.GetFirstCharIndexFromLine(lineNumber)
                            + currentRtb.Lines[lineNumber].Length, 0);
                    }
                    finally
                    {
                        // Release the lock...
                        LockWindowUpdate(IntPtr.Zero);
                    }
                }
            }
        }
        /// <summary>
        /// Check the indent level from the first line 
        /// to the line where the cursor is
        /// </summary>
        private void checkindent(int lineNumber)
        {
            int temptablevel = 0;
            //Get the current line number
            //Loop from the first line to current line
            for (int z = 0; z < lineNumber; z++)
            {
                string line = currentRtb.Lines[z];
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (checkKeyword(keywords[i], line))
                    {
                        temptablevel++;//Increment tablevel if keywords are found
                        break;
                    }
                }
                for (int i = 0; i < keywords2.Length; i++)
                {
                    if (checkKeyword(keywords2[i], line))
                    {
                        if (temptablevel <= 0) break;//Tablevel cant be less than 0
                        temptablevel--;//Decrement tablevel if keywords are found
                        break;
                    }
                }
            }
            //Assign value to tablevel
            tablevel = temptablevel;
        }
        /// <summary>
        /// To zoom in and out using ctrl and mousewheel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentRtb_mouse(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                LineNumberBox.ZoomFactor = currentRtb.ZoomFactor;
            }
            else
            {
                LineNumberBox.ZoomFactor = currentRtb.ZoomFactor;
            }
        }
        /// <summary>
        /// When a variable is declared add it to an autocomplete menu
        /// </summary>
        private void addVariableNames()
        {
            string[] text;
            string varname;
            int index = currentRtb.GetFirstCharIndexOfCurrentLine();
            int lineIndex = currentRtb.GetLineFromCharIndex(index) - 1;
            string[] lines = currentRtb.Lines;
            if (lineIndex < 0) lineIndex = 0;
            string line = lines[lineIndex];
            if (lines[lineIndex] == "") return;
            if (lines[lineIndex].Length < 8) return;
            if (StringExtension.Contains(line.Substring(0, 8), "Declare "))
            {
                text = line.Split(':');
                varname = Regex.Replace(text[0], @"\b(?i)(Declare)\b", "");
                if (!varnames.Contains(varname.Trim()))
                {
                    autocompleteMenu1.AddItem(varname.Trim());
                    varnames.Add(varname.Trim());
                }

            }
        }
        /// <summary>
        /// If variable declaration is deleted then remove from the autocomplete menu (Incomplete)
        /// </summary>
        private void checkDeletedVarName()
        {
            string Text = currentRtb.Text;
            foreach (string varname in varnames)
            {
                if (!StringExtension.Contains(currentRtb.Text, "Declare " + varname))
                {
                    for (int i = 47; i < autocompleteMenu1.Items.Length; i++)
                    {
                        if (autocompleteMenu1.Items[i] == varname)
                        {
                            autocompleteMenu1.Items[i] = "";
                            autocompleteMenu1.Update();
                        }
                    }
                }
            }


        }
        /// <summary>
        /// Screen suspension
        /// </summary>
        /// <param name="Handle"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern long LockWindowUpdate(IntPtr Handle);

        /// <summary>
        /// Fix format indentation of the entire coding box
        /// </summary>
        private void FixFormat()
        {
            LockWindowUpdate(Handle);
            int i = 0;
            string[] linesOfCurrentrtb;
            linesOfCurrentrtb = currentRtb.Lines;//Store to a temp array to prevent runtime interface issue
            foreach (string line in currentRtb.Lines)
            {
                if (i < currentRtb.Lines.Length - 1)
                {
                    checkindent(i + 1);
                    linesOfCurrentrtb[i] = UpdateIndentLevel(linesOfCurrentrtb[i]);//Reset position of Keywords1&2
                    checkindent(i + 1);//Check Indentlevel again                
                    //Implement identation
                    linesOfCurrentrtb[i + 1] = linesOfCurrentrtb[i + 1].TrimStart();
                    linesOfCurrentrtb[i + 1] = getIndentSpace(tablevel) + linesOfCurrentrtb[i + 1];
                    i++;
                }
            }
            currentRtb.Lines = linesOfCurrentrtb;
            syntaxhighlightall(currentRtb);
            currentRtb.ZoomFactor = (float)(zoomfactor + 0.0000001);
            LockWindowUpdate(IntPtr.Zero);
        }
        /// <summary>
        /// Perform fixing format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatButton_Click(object sender, EventArgs e)
        {
            FixFormat();
        }
    }

}
