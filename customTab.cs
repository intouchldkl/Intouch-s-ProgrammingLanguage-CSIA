using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_IA_Ibasic_Intouch_Re
{
    class customTab : TabPage
    {
        public RichTextBox textbox;
        public customTab()
        {
            Text = "untitled";
            textbox = new RichTextBox();
            textbox.AcceptsTab = true;
            this.Controls.Add(textbox);
            textbox.Dock = DockStyle.Fill;
            //To allow both scrollbars
            textbox.ScrollBars = RichTextBoxScrollBars.Both;
            // To allow horizontal scroll bar to work by unlimiting the wordwrap
            textbox.WordWrap = false;


        }
    }
}
