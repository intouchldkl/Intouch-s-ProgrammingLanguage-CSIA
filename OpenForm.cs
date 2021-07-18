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
    public partial class OpenForm : Form
    {
        RichTextBox currentRtb = new RichTextBox();
        TabPage tabPage = new TabPage();
        public OpenForm(RichTextBox currentRtb,TabPage tabPage)
        {
            InitializeComponent();
            this.currentRtb = currentRtb;
            this.tabPage = tabPage;
         
        }

        private void LocalDButton_Click(object sender, EventArgs e)
        {
            openFileFromLocalD();
        }

        private void DriveButton_Click(object sender, EventArgs e)
        {
            RepositoryForm repos = new RepositoryForm(currentRtb,tabPage);
            Close();
            repos.Show();
            
        }
        private void openFileFromLocalD()
        {
            // Open file 

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {


                //  read file
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    currentRtb.Text = sr.ReadToEnd();
                    sr.Close();
                    tabPage.Text = openFileDialog1.SafeFileName;
                }
                Close();

            }
        }
    }
}
