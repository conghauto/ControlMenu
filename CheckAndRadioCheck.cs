using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo05
{
    public partial class CheckAndRadioCheck : Form
    {
        MenuItem miColor, miFill;

        public CheckAndRadioCheck()
        {
            Text = "Check and Radio Check";
            ResizeRedraw = true;
            string[] astrColor = { "Black", "Blue", "Green", "Cyan","Red","Magenta","Yellow","White" };

            MenuItem[]ami = new MenuItem[astrColor.Length + 2];
            EventHandler ehColor = new EventHandler(MenuFormatColorOnClick);

            for(int i=0;i<astrColor.Length;i++)
            {
                ami[i] = new MenuItem(astrColor[i], ehColor);
                ami[i].RadioCheck = true;
            }
            miColor = ami[0];
            miColor.Checked = true;
           ami[astrColor.Length] = new MenuItem();
            miFill = new MenuItem("&Fill", new EventHandler(MenuFormatFillOnClick));
            ami[astrColor.Length + 1] = miFill;

            MenuItem mi = new MenuItem("&Format",ami);
            Menu = new MainMenu(new MenuItem[] { mi });

        }

        private void MenuFormatColorOnClick(object sender,EventArgs e)
        {
            miColor.Checked = false;
            miColor = (MenuItem)sender;
            miColor.Checked = true;
            Invalidate();
        }

        private void MenuFormatFillOnClick(object sender,EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            mi.Checked = !mi.Checked;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            Graphics grfx = pea.Graphics;
            if(miFill.Checked)
            {
                Brush brush = new SolidBrush(Color.FromName(miColor.Text));
                grfx.FillEllipse(brush,0,0, ClientSize.Width - 1, ClientSize.Height - 1);
            }
            else
            {
                Pen pen = new Pen(Color.FromName(miColor.Text));
                grfx.DrawEllipse(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }
        }
    }
}
