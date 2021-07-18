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
        RichTextBox currentRtb = new RichTextBox();
        TabPage tabPage = new TabPage();
        public SaveToDriveForm(RichTextBox currentRtb,TabPage tabPage)
        {
            InitializeComponent();
            this.currentRtb = currentRtb;
            this.tabPage = tabPage;
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

            GGDrive.Instance.Upload(saveFileDialog1.FileName, GGDrive.Instance.getIBASICfolderId());
        }
    }
}
