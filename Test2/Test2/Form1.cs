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


namespace Test2
{
    public partial class Form1 : Form
    {
        Rectangle mRect;
        private Point p1 = new Point(-1, -1);
        private Point p2 = new Point(-1, -1);
        private Point r1 = new Point(-1, -1);
        private Point r2 = new Point(-1, -1);




        public List<MouseEventArgs> positions = new List<MouseEventArgs>();
        public Form1()
        {
            InitializeComponent();
            //this.DoubleBuffered = true;

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);

        }

        ////Initiate rectangle with mouse down event
        //protected override void OnMouseDown(MouseEventArgs e)
        //{

        //    startPoint.x = e.X;
        //    startPoint.y = e.Y;
        //    mRect = new Rectangle(startPoint.x, startPoint.y, 0, 0);

        //    this.Invalidate();
        //}

        ////check if mouse is down and being draged, then draw rectangle
        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {




        //        Vector2 tempVec;

        //        if (mRect.Left < startPoint.x)
        //        {
        //            tempVec.x = mRect.Left;
        //            endPoint.x = startPoint.x;
        //            startPoint.x = tempVec.x;
        //        }
        //        if (endPoint.y < startPoint.y)
        //        {
        //            tempVec.y = endPoint.y;
        //            endPoint.y = startPoint.y;
        //            startPoint.y = tempVec.y;
        //        }

        //        mRect = new Rectangle(mRect.Left, mRect.Top, e.X - mRect.Left, e.Y - mRect.Top);



        //        textOutput.Text = mRect.ToString();
        //        this.Invalidate();
        //    }
        //}
        //protected override void OnMouseUp(MouseEventArgs e)
        //{


        //    //mRect = new Rectangle(e.X, e.Y, 0, 0);

        //    //this.Invalidate();


        //}

        ////draw the rectangle on paint event
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    //Draw a rectangle with 2pixel wide line
        //    using (Pen pen = new Pen(Color.Red, 2))
        //    {
        //        e.Graphics.DrawRectangle(pen, mRect);
        //    }

        //}
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                p1 = e.Location;
            r1 = p1;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                p2 = e.Location;

                r2 = p2;


                if (p2.X < p1.X)
                {
                    r2.X = p1.X;
                    r1.X = p2.X;
               
            }
            if (p2.Y < p1.Y)
                {
                    r2.Y = p1.Y;
                    r1.Y = p2.Y;

                }
                this.Invalidate();
            }
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
               // p2 = e.Location;
                this.Invalidate();
                textOutput.Text = r2.ToString() + r2.ToString();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (p1.X > 0 && p1.Y > 0 && p2.X > 0 && p2.Y > 0)
                e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(r1.X, r1.Y, r2.X - r1.X, r2.Y - r1.Y));
        }



        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {


            ////When the user clicks on the PictureBox,
            // //the mouse coordinates will be written to the
            // //TextBox.

            //if (e.GetType() == typeof(MouseEventArgs))
            //{
            //    textOutput.Clear();

            //    MouseEventArgs me = e as MouseEventArgs;
            //    positions.Add(me);

            //    foreach (MouseEventArgs element in positions)
            //    {
            //        //textOutput.Text += element.Location.ToString() + Environment.NewLine;
            //    }


            //    textOutput.Text += me.Location.ToString();

            //    startPoint.x = e.X;
            //    startPoint.y = e.Y;


            //}
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {

                    byte[] bytes = Encoding.ASCII.GetBytes(textOutput.Text);

                    myStream.Write(bytes, 0, bytes.Length);
                    // Code to write the stream goes here. 
                    myStream.Close();
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textOutput.Text = "";
        }
        //private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    startPoint.x = e.X;
        //    startPoint.y = e.Y;

        //}

        //private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)

        //    {
        //        endPoint.x = e.X;
        //        endPoint.y = e.Y;

        //        mRect = new Rectangle(startPoint.x, startPoint.y, endPoint.x - startPoint.x, endPoint.y - startPoint.y);
        //        pictureBox1.Refresh();
        //    }
        //}
    }
}
