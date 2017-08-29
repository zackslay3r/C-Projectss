using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Tool
{
    public partial class Form1 : Form
    {

        // THis will be the previous mouse location.
        private Point MouseDownLocation;

        public Form1()
        {
            InitializeComponent();
        }

        // Creation of the rectangle that will be drawn into the picture box.
        Rectangle rec;
        private Point rPic1 = new Point(-1, 1);
        Point finalRecPos = new Point();
        MainFormManager mfrmmanager = new MainFormManager();
        public Item tempItem = new Item();
        public List<Item> items = new List<Item>();
        public AddName AddNameForm = new AddName();
        public string[] file;



        bool scaleHeight, scaleWidith = true;

        public bool checkCollide(int x, int y, int oWidth, int oHeight, int xTwo, int yTwo, int oTwoWidth, int oTwoHeight)
        {
            // AABB 1
            int x1Min = x;
            int x1Max = x + oWidth;
            int y1Max = y + oHeight;
            int y1Min = y;

            // AABB 2
            int x2Min = xTwo;
            int x2Max = xTwo + oTwoWidth;
            int y2Max = yTwo + oTwoHeight;
            int y2Min = yTwo;

            // Collision tests
            if (x1Max < x2Min || x1Min > x2Max) return false;
            if (y1Max < y2Min || y1Min > y2Max) return false;

            return true;
        }

        public void CheckBounds(Point mousePos)
        {
       
            if (rec.Left < 0)
            {
                rec.Location = new Point(0, rec.Top);
                scaleWidith = false;
            }
            else if(mousePos.X > pictureBox1.Width)
            {
                rec.Location = new Point(pictureBox1.Width - rec.Width - 1, rec.Top);
                scaleWidith = false;
            }
            else
            {
                scaleWidith = true;
            }

            

            if (rec.Top < 0)
            {
                rec.Location = new Point(rec.Left, 0);
                scaleHeight = false;
            }
            else if(mousePos.Y > pictureBox1.Height)
            {
                rec.Location = new Point(rec.Left, pictureBox1.Height - rec.Height - 1);
                scaleHeight = false;
            }
            else
            {
                scaleHeight = true;
            }


      

        }


        public void CheckDraggingRec()
        {
            if (rec.Left < 0)
            {
                rec.Location = new Point(0, rec.Top);
                scaleWidith = false;
            }
            else if (rec.Left + rec.Width > pictureBox1.Width)
            {
                rec.Location = new Point(pictureBox1.Width - rec.Width - 1, rec.Top);
                scaleWidith = false;
            }
            else
            {
                scaleWidith = true;
            }

            if (rec.Top < 0)
            {
                rec.Location = new Point(rec.Left, 0);
                scaleHeight = false;
            }
            else if (rec.Top + rec.Height > pictureBox1.Height)
            {
                rec.Location = new Point(rec.Left, pictureBox1.Height - rec.Height - 1);
                scaleHeight = false;
            }
            else
            {
                scaleHeight = true;
            }

        }

        public void LoadNewPict()
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
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    pictureBox1.Image = Image.FromFile(dlg.FileName);

                    //picBox.Image = PictureBox1.Image;

                }
            }
        }


        public void LoadUVCoords()
        {
            bool loadComplete = false;




            //using (OpenFileDialog dlg = new OpenFileDialog())
            //{
                
            //        dlg.Title = "Open UV";
            //        dlg.Filter = "Text files (.txt)| *.txt";


            //        if (dlg.ShowDialog() == DialogResult.OK)
            //        {

            //            AddNameForm.Show();
            //            AddNameForm.theFileName = dlg.FileName;
            //            AddNameForm.parent = this;

            //            AddNameForm.file = File.ReadAllLines(dlg.FileName);
            //            foreach (var item in AddNameForm.file)
            //            {

            //                // This splits the values up and stores them in the temporary item.
            //                string[] values = item.Split();
            //                tempItem.startPoint = (new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1])));
            //                tempItem.endPoints = (new Point(Convert.ToInt32(values[2]), Convert.ToInt32(values[3])));
            //                tempItem.startUVpoint = (new PointD(Convert.ToDouble(values[4]), Convert.ToDouble(values[5])));
            //                tempItem.endUVpoint = (new PointD(Convert.ToDouble(values[6]), Convert.ToDouble(values[7])));

            //                AddNameForm.ofItemsToChange.Add(tempItem);
            //                tempItem = new Item();
            //            }

            //        }
            //    }


            




        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            {
                e.Graphics.DrawRectangle(Pens.LightGreen, rec);
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
        //can also use this one:
        //if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
               rPic1 = e.Location;
                rec = new Rectangle(e.X, e.Y, 1, 1);
                
                //rec = new Rectangle(rPic1.X, rPic1.Y, 0, 0);
                Invalidate();
                
            }
            if (e.Button == MouseButtons.Right)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                //Point finalRecPos = new Point();

                if (e.Location.X < rPic1.X)
                {
                    finalRecPos.X = e.Location.X;
                }
                else
                {
                    finalRecPos.X = rPic1.X;
                }

                if (e.Location.Y < rPic1.Y)
                {
                    finalRecPos.Y = e.Location.Y;
                }
                else
                {
                    finalRecPos.Y = rPic1.Y;
                }

                rec.Location = finalRecPos;

                if (scaleWidith == true)
                {
                    rec.Width = Math.Abs(e.X - rPic1.X);
                }
                if (scaleHeight == true)
                {
                    rec.Height = Math.Abs(e.Y - rPic1.Y);
                }

                CheckBounds(e.Location);

                lblStartPText.Text = rPic1.X.ToString() + " " + rPic1.Y.ToString();
                lblEndPText.Text = e.Location.X.ToString() + " " + e.Location.Y.ToString();

                this.Invalidate();
            }

            if (e.Button == MouseButtons.Right)
            {
                if (rec != null)
                {
                    if (checkCollide(e.Location.X, e.Location.Y, 1, 1, rec.X, rec.Y, rec.Width, rec.Height))
                    {

                        rec.Location = Point.Add(rec.Location, (Size)Point.Subtract(e.Location, (Size)MouseDownLocation));
                        
                        MouseDownLocation = e.Location;
                        CheckDraggingRec();
                        pictureBox1.Refresh();
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadNewPict();
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
}
