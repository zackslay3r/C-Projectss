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
            //if (rec.Width > 500)
            //{
            //    //finalRecPos.X = 500;
            //    rec.Width = 500;

            //}
            //if (finalRecPos.Y < 0)
            //{
            //    finalRecPos.Y = 1;

            //}
            //if (pic2.X > widith)
            //{
            //    pic2.X = widith;

            //    rPic2.X = pic2.X;
            //}
            //if (pic2.Y > height)
            //{
            //    pic2.Y = height;

            //    rPic2.Y = pic2.Y;
            //}

            //if (pic2.X < pic1.X)
            //{
            //    rPic2.X = pic1.X;
            //    rPic1.X = pic2.X;

            //}
            //if (pic2.Y < pic1.Y)
            //{
            //    rPic2.Y = pic1.Y;
            //    rPic1.Y = pic2.Y;

            //}
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


            //if ((rec.Left + rec.Width) > pictureBox1.Width)
            //{
            //    //rec.Location = new Point(pictureBox1.Width - rec.Width - 1, rec.Top);
            //    scaleWidith = false;
            //}
            //else
            //{
            //    scaleWidith = true;
            //}

            //if ((rec.Top + rec.Height) > pictureBox1.Height)
            //{
            //    //rec.Location = new Point(pictureBox1.Height - rec.Height, rec.Height);
            //    scaleHeight = false;
            //}
            //else
            //{
            //    scaleHeight = true;
            //}

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
                        pictureBox1.Refresh();
                    }
                }
            }
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
}
