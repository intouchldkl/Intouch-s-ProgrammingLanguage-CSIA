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
    public partial class PublishForm : Form
    {
        RichTextBox currentRtb = new RichTextBox();
        TabPage tabPage = new TabPage();
        string outputFileName;
        public PublishForm(RichTextBox currentRtb,TabPage tabPage)
        {
            InitializeComponent();
            this.currentRtb = currentRtb;
            this.tabPage = tabPage;
            FileNameBox.Text = tabPage.Text;
            
        }

        private void OutputBut_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {          
                outputFileName = openFileDialog1.FileName;
                PublishBut.Enabled = true;
            }
        }

        private void PublishBut_Click(object sender, EventArgs e)
        {
            if(FileNameBox.Text != "")
            {
                publishToGDrive();
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a file name");
            }
           
        }

        private void publishToGDrive()
        {

            if (GGDrive.Instance.checkForIBasicFolder() == false)
            {
                GGDrive.Instance.CreateIBASICFolder("IBASIC-FOLDER");
            }
            if (GGDrive.Instance.checkForPublishFolder() == false)
            {
                GGDrive.Instance.CreatePublishFolder("IBASIC-FOLDER-PUBLISH");
            }

            saveFileDialog1.FileName = FileNameBox.Text;
            StreamWriter CodeToBeSaved = new StreamWriter(saveFileDialog1.FileName);
            CodeToBeSaved.Write(currentRtb.Text);
            CodeToBeSaved.Close();
            GGDrive.Instance.Upload(saveFileDialog1.FileName, GGDrive.Instance.getIBASICfolderId());
            GGDrive.Instance.Upload(saveFileDialog1.FileName, GGDrive.Instance.getPublishfolderId());
            GGDrive.Instance.Upload(outputFileName, GGDrive.Instance.getPublishfolderId());
            
        }
    }
}
