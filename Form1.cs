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

namespace CS_IA_Ibasic_Intouch_Re
{
    public partial class IBASICForm : Form
    {
        // To keep track of where the current tab is
        RichTextBox currentRtb = new RichTextBox();
        public IBASICForm()
        {
            InitializeComponent();
            currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            currentRtb.AcceptsTab = true;
            currentRtb.Dock = DockStyle.Fill;
            //To allow both scrollbars
            currentRtb.ScrollBars = RichTextBoxScrollBars.Both;
            // To allow horizontal scroll bar to work by unlimiting the wordwrap
            currentRtb.WordWrap = false;
        }

        private void ZoomBar_ValueChanged(object sender, EventArgs e)
        {
            /// Zoomfactor cant be <= 0
            if (ZoomBar.Value > 0)
            {
                currentRtb.ZoomFactor = ZoomBar.Value;
            }

        }
        private void New_Click(object sender, EventArgs e)
        {
            TabPage newTab = new TabPage();
            tabControl1.Controls.Add(newTab);
            newTab.Controls.Add(new RichTextBox());
            newTab.Text = "Untitled";
            currentRtb = (RichTextBox)newTab.Controls[0];
            ///Make sure the user see the new tab
            tabControl1.SelectedTab = newTab;
            ///  currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            currentRtb.AcceptsTab = true;
            currentRtb.Dock = DockStyle.Fill;
            //To allow both scrollbars
            currentRtb.ScrollBars = RichTextBoxScrollBars.Both;
            // To allow horizontal scroll bar to work by unlimiting the wordwrap
            currentRtb.WordWrap = false;

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
                    this.Text = openFileDialog1.SafeFileName;
                }
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
            if (ZoomBar.Value > 0)
            {
                currentRtb.ZoomFactor = ZoomBar.Value;
            }
        }
        private void createNewTabPage()
        {
            TabPage newTab = new TabPage();
            tabControl1.Controls.Add(newTab);
            newTab.Controls.Add(new RichTextBox());
            newTab.Text = "Untitled";
            currentRtb = (RichTextBox)newTab.Controls[0];
            ///Make sure the user see the new tab
            tabControl1.SelectedTab = newTab;
            ///  currentRtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            currentRtb.AcceptsTab = true;
            currentRtb.Dock = DockStyle.Fill;
            //To allow both scrollbars
            currentRtb.ScrollBars = RichTextBoxScrollBars.Both;
            // To allow horizontal scroll bar to work by unlimiting the wordwrap
            currentRtb.WordWrap = false;
        }

  
    }
}
