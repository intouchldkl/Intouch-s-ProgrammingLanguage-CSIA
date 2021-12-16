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
        RichTextBox currentRtb;
        TabPage tabPage;
        string outputFileName;
        bool needAutoOutput = true;
        public PublishForm()
        {
            InitializeComponent();
            this.currentRtb = IBASICForm.Instance.getCurrentRtb();
            this.tabPage = IBASICForm.Instance.getCurrentTabpage();
            if (tabPage.Text.Last() == '*')
            {
                FileNameBox.Text = tabPage.Text.Remove(tabPage.Text.Length - 1);
            }
            else
            {
                FileNameBox.Text = tabPage.Text;
            }
            
        }
        /// <summary>
        /// Take the screenshot of the output 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputBut_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {          
                outputFileName = openFileDialog1.FileName;
                needAutoOutput = false;
            }
        }
        /// <summary>
        /// Perform publish
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Publish the screenshot of output to publish folder in drive and code to both publish and IBASIC folder
        /// </summary>
        private void publishToGDrive()
        {
            ///IF IBASIC folder doesnt exist then create one
            if (GGDrive.Instance.checkForIBasicFolder() == false)
            {
                GGDrive.Instance.CreateIBASICFolder("IBASIC-FOLDER");
            }
            ///IF PUBLISH folder doesnt exist then create one
            if (GGDrive.Instance.checkForPublishFolder() == false)
            {
                GGDrive.Instance.CreatePublishFolder("IBASIC-FOLDER-PUBLISH");
            }

            saveFileDialog1.FileName = FileNameBox.Text;
            StreamWriter CodeToBeSaved = new StreamWriter(saveFileDialog1.FileName+".txt");
            CodeToBeSaved.Write(currentRtb.Text);
            CodeToBeSaved.Close();
            tabPage.Text = saveFileDialog1.FileName;
            //Add .txt to specify file type
            GGDrive.Instance.Upload(saveFileDialog1.FileName+".txt", GGDrive.Instance.getIBASICfolderId());
            GGDrive.Instance.Upload(saveFileDialog1.FileName+".txt", GGDrive.Instance.getPublishfolderId());
            if(needAutoOutput == false)
            {
                GGDrive.Instance.Upload(outputFileName, GGDrive.Instance.getPublishfolderId());
            }
            else
            {
                GGDrive.Instance.Upload("out.txt", GGDrive.Instance.getPublishfolderId());
            }
            
        }
    }
}
