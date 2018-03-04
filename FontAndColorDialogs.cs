using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo06
{
    public partial class FontAndColorDialogs : Form
    {
        public FontAndColorDialogs()
        {
            Text = "Font And Color Dialogs";
            ResizeRedraw = true;

            Menu = new MainMenu();
            Menu.MenuItems.Add("&Format");
            Menu.MenuItems[0].MenuItems.Add("&Font...",new EventHandler(MenuFontOnClick));
            Menu.MenuItems[0].MenuItems.Add("&Backgroup Color...", new EventHandler(MenuColorOnClick));
            Menu.MenuItems[0].MenuItems.Add("&Exit", new EventHandler(MenuExitOnClick));

        }
        private void MenuExitOnClick(object sender,EventArgs e)
        {
            Application.Exit();
        }
        private void MenuFontOnClick(object sender,EventArgs e)
        {
            FontDialog fontdlg = new FontDialog();
            fontdlg.Color = ForeColor;
            fontdlg.ShowColor = true;

            if(fontdlg.ShowDialog()==DialogResult.OK)
            {
                Font = fontdlg.Font;
                ForeColor = fontdlg.Color;
                Invalidate();
            }
        }

        private void MenuColorOnClick(object sender,EventArgs e)
        {
            ColorDialog colordlg = new ColorDialog();
            colordlg.Color = BackColor;
            if(colordlg.ShowDialog()==DialogResult.OK)
            {
                BackColor = colordlg.Color;
            }
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            Graphics grfx = pea.Graphics;
            StringFormat strfmt = new StringFormat();
            strfmt.Alignment = strfmt.LineAlignment = StringAlignment.Center;

            grfx.DrawString("Hello common dialog boxes!", Font, new SolidBrush(ForeColor), this.ClientRectangle, strfmt);
        }
    }
}
