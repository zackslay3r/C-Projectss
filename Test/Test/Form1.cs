using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        Rectangle rect = new Rectangle(125, 125, 50, 50);
        bool isMouseDown = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadNewPict()
        {
             // Wrap the creation of the OpenFileDialog instance in a using statement,
    // rather than manually calling the Dispose method to ensure proper disposal
    using (OpenFileDialog dlg = new OpenFileDialog())
    {
        dlg.Title = "Open Image";
        dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            // PictureBox1 = new PictureBox();

                    // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    picBox.Image = Image.FromFile(dlg.FileName);

                    //picBox.Image = PictureBox1.Image;
            
        }
    }
        }
        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNewPict();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void picBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.RoyalBlue), rect);
        }

        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        private void pictBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                rect.Location = e.Location;

                if (rect.Right > picBox.Width)
                {
                    rect.X = picBox.Width - rect.Width;
                }
                if (rect.Top < 0)
                {
                    rect.Y = 0;
                }
                if (rect.Left < 0)
                {
                    rect.X = 0;
                }
                if (rect.Bottom > picBox.Height)
                {
                    rect.Y = picBox.Height - rect.Height;
                }
                Refresh();
            }
        }

        private void picBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }



    }
}
