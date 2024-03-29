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
    public partial class SaveToDriveForm : Form
    {
        RichTextBox currentRtb;
        TabPage tabPage;
        
        public SaveToDriveForm()
        {
            InitializeComponent();
            this.currentRtb = IBASICForm.Instance.getCurrentRtb();
            this.tabPage = IBASICForm.Instance.getCurrentTabpage();
            // Remove * from an unsaved project
            if(tabPage.Text.Last() == '*')
            {
                FileNameBox.Text = tabPage.Text.Remove(tabPage.Text.Length - 1);
            }
            else
            {
                FileNameBox.Text = tabPage.Text;
            }

        }
        /// <summary>
        /// Save the file to IBASIC folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(FileNameBox.Text != "")
            {
               saveFileToIBASICfolder();
            }
            else
            {
                MessageBox.Show("Please enter a file name");
            }
          
        }
        /// <summary>
        /// Upload the text from coding box to IBASIC folder
        /// </summary>
        private void saveFileToIBASICfolder()
        {
            if (GGDrive.Instance.checkForIBasicFolder() == false)
            {
                GGDrive.Instance.CreateIBASICFolder("IBASIC-FOLDER");
            }

            saveFileDialog1.FileName = FileNameBox.Text;
            StreamWriter CodeToBeSaved = new StreamWriter(saveFileDialog1.FileName +".txt");
            CodeToBeSaved.Write(currentRtb.Text);
            CodeToBeSaved.Close();
            Close();
            tabPage.Text = saveFileDialog1.FileName;          
            GGDrive.Instance.Upload(saveFileDialog1.FileName+".txt", GGDrive.Instance.getIBASICfolderId());
        }
    }
}
