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
    public partial class SaveAsForm : Form
    {
        RichTextBox currentRtb = new RichTextBox();
        TabPage tabpage = new TabPage();
        public SaveAsForm(RichTextBox currentRtb,TabPage tabpage)
        {
            InitializeComponent();
            this.currentRtb = currentRtb;
            this.tabpage = tabpage;
        }

        private void LocalDBut_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = tabpage.Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                StreamWriter CodeToBeSaved = new StreamWriter(saveFileDialog1.FileName);
                CodeToBeSaved.Write(currentRtb.Text);
                CodeToBeSaved.Close();
                Close();
            }
        }

        private void GDrivebut_Click(object sender, EventArgs e)
        {
            SaveToDriveForm SaveDriveForm = new SaveToDriveForm(currentRtb,tabpage);
            SaveDriveForm.Show();
            Close();

        }
    }
}
