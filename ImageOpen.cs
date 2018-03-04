using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo07
{
    public partial class ImageOpen : Form
    {
        protected string strProgName;
        protected string strFileName;
        protected Image image;
        
        public ImageOpen()
        {
            Text = strProgName = "Image Open";
            ResizeRedraw = true;

            Menu = new MainMenu();
            Menu.MenuItems.Add("&File");
            Menu.MenuItems[0].MenuItems.Add
                (new MenuItem("&Open...", new EventHandler(MenuFileOpenClick), Shortcut.CtrlO));
        }

        private void MenuFileOpenClick(object sender,EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;" +
                                "*.jfif;*.png;*.tif;*.tiff;*.wmf;*.emf|" +
                         "Windows Bitmap (*.bmp)|*.bmp|" +
                         "All Files (*.*)|*.*";

            if (dlg.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    image = Image.FromFile(dlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, strProgName);
                    return;
                }

                strFileName = dlg.FileName;
                Text = strProgName + "-" + Path.GetFileName(strFileName);
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grfx = e.Graphics;
            if(image!=null)
            {
                grfx.DrawImage(image, 0, 0);
            }
        }
    }
}
