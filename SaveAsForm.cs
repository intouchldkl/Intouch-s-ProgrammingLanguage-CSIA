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
        public SaveAsForm(RichTextBox currentRtb)
        {
            InitializeComponent();
            this.currentRtb = currentRtb;
    
        }

        private void LocalDBut_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter CodeToBeSaved = new StreamWriter(saveFileDialog1.FileName);
                CodeToBeSaved.Write(currentRtb.Text);
                CodeToBeSaved.Close();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
