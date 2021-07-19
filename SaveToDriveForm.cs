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
    public partial class SaveToDriveForm : Form
    {
        RichTextBox currentRtb;
        TabPage tabPage;
        public SaveToDriveForm()
        {
            InitializeComponent();
            this.currentRtb = IBASICForm.Instance.getCurrentRtb();
            this.tabPage = IBASICForm.Instance.getCurrentTabpage();
            FileNameBox.Text = tabPage.Text;
        }

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
        private void saveFileToIBASICfolder()
        {
            if (GGDrive.Instance.checkForIBasicFolder() == false)
            {
                GGDrive.Instance.CreateIBASICFolder("IBASIC-FOLDER");
            }

            saveFileDialog1.FileName = FileNameBox.Text;
            StreamWriter CodeToBeSaved = new StreamWriter(saveFileDialog1.FileName);
            CodeToBeSaved.Write(currentRtb.Text);
            CodeToBeSaved.Close();
            Close();
            tabPage.Text = saveFileDialog1.FileName;
            GGDrive.Instance.Upload(saveFileDialog1.FileName, GGDrive.Instance.getIBASICfolderId());
        }
    }
}
