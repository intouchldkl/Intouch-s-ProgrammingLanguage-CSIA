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
    public partial class RepositoryForm : Form
    {
        RichTextBox currentRtb;
        TabPage tabPage;
        public RepositoryForm()
        {
            InitializeComponent();
            GGDrive.Instance.Authentication();
            displayAllFiles();
        
         
        }

        public void displayAllFiles()
        {
            
            if (GGDrive.Instance.checkForIBasicFolder() == true)
            {
                if (GGDrive.Instance.retrieveFile() != null)
                {
                    var displayFileNames = GGDrive.Instance.getDisplayFileNames();
                    foreach (var FileName in displayFileNames)
                    {
                        string fileName = FileName.Name;
                        if (fileName.Contains(".txt") == true)
                        {
                            fileName = fileName.Replace(".txt", "");
                        }                   
                        var LVI = new ListViewItem(fileName);
                        FilelistView.Items.Add(LVI);
                        LVI.Tag = FileName.Name;
                    }

                }

            }
            


        }

     

        private void FilelistView_Click(object sender, EventArgs e)
        {
            VersionListView.Clear();
            displayVersionFiles();
            
        }
        private void displayVersionFiles()
        {
            string FileName = (string)FilelistView.SelectedItems[0].Tag ;
            var AllVersionFiles = GGDrive.Instance.getVersionFiles(FileName); 
            int i = AllVersionFiles.Count;
            foreach (var version in AllVersionFiles)
            {
                if(FileName.Contains(".txt") == true)
                {
                    FileName = FileName.Replace(".txt", "");
                }
                string time = version.createdTime.ToString();
                var row = new string[] { "Version " + i, time };
                i--;
                var LVI = new ListViewItem(row);
                LVI.Text = FileName + "-" + LVI.Text + "     " + time;
                LVI.Tag = version;
                VersionListView.Items.Add(LVI);
            }
        }

        private void VersionListView_Click(object sender, EventArgs e)
        {
            downloadFile();
            Close();
        }

        private void downloadFile()
        {
            GGDriveFile GFlie = (GGDriveFile)FilelistView.SelectedItems[0].Tag;
            string fileId = GFlie.Id;
            openFileDialog1.FileName = GGDrive.Instance.DownloadGoogleFile(fileId);
            IBASICForm.Instance.createNewTabPage(openFileDialog1.FileName);
            currentRtb = IBASICForm.Instance.getCurrentRtb();
            tabPage = IBASICForm.Instance.getCurrentTabpage();
            using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
            {
                currentRtb.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
    }
}
