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
        customTab currentTab = new customTab();
        public IBASICForm()
        {
            InitializeComponent();
            currentTab = customTab1;
        }

        private void ZoomBar_ValueChanged(object sender, EventArgs e)
        {
            /// Zoomfactor cant be <= 0
            if (ZoomBar.Value > 0)
            {
                currentTab.textbox.ZoomFactor = ZoomBar.Value;
            }

        }
        private void New_Click(object sender, EventArgs e)
        {
            currentTab = new customTab();
            tabControl1.Controls.Add(currentTab);
            ///Make sure the user see the new tab
            tabControl1.SelectedTab = currentTab;
        }

        private void Open_Click(object sender, EventArgs e)
        {
            // Open file 

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentTab = new customTab();
                tabControl1.Controls.Add(currentTab);
                ///Make sure the user see the new tab
                tabControl1.SelectedTab = currentTab;

                // Open & read file
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    currentTab.textbox.Text = sr.ReadToEnd();
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
                CodeToBeSaved.Write(currentTab.textbox.Text);
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
                CodeToBeSaved.Write(currentTab.textbox.Text);
                CodeToBeSaved.Close();

            }
        }
        private void Undo_Click(object sender, EventArgs e)
        {
            currentTab.textbox.Undo();
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            currentTab.textbox.Redo();
        }
        private void Run_Click(object sender, EventArgs e)
        {
            Compiler Icompiler = new Compiler(currentTab.textbox.Text);
            Icompiler.launchEXE();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            currentTab = (customTab)tabControl1.SelectedTab;
            ///ZoomFactor cant be <= 0
            if (ZoomBar.Value > 0)
            {
                currentTab.textbox.ZoomFactor = ZoomBar.Value;
            }
        }


    }
}
