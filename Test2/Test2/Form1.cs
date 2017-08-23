﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace Test2
{
    public partial class Form1 : Form
    {
        Rectangle mRect;
        // form points
        private Point p1 = new Point(-1, -1);
        private Point p2 = new Point(-1, -1);
        private Point r1 = new Point(-1, -1);
        private Point r2 = new Point(-1, -1);

        //picture box points
        private Point pic1 = new Point(-1, 1);
        private Point pic2 = new Point(-1, 1);

        private Point rPic1 = new Point(-1, 1);
        private Point rPic2 = new Point(-1, 1);
        Graphics Pic1G;
        Stream myStream;

        public string tempName = " ";


        public Item tempItem = new Item();
        public List<Item> items = new List<Item>();

        //private List<Point> startPoints = new List<Point>();
        //private List<Point> endPoints = new List<Point>();

        //private List<PointD> startUVpoints = new List<PointD>();
        //private List<PointD> endUVpoints = new List<PointD>();

        //List<Rectangle> rectangles = new List<Rectangle>();

        public int counter = 0;


        // UV points
        // This is the creation of temporary floats for the storage of UV calculations.
        double startPointUVX, startPointUVY, endPointUVX, endPointUVY;

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
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    pictureBox1.Image = Image.FromFile(dlg.FileName);

                    //picBox.Image = PictureBox1.Image;

                }
            }
        }
        private void LoadUVCoords()
        {
            bool loadComplete = false;
            


            
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Open UV";
                    dlg.Filter = "Text files (.txt)| *.txt";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Form2 newMDIChild = new Form2();
                    newMDIChild.Show();
                    newMDIChild.theFileName = dlg.FileName;
                    newMDIChild.parent = this;

                    //Form2 newMDIChild = new Form2();
                    //newMDIChild.Show();



                    //newMDIChild.MdiParent = this;


                    //while(!newMDIChild.Enabled)
                    //{

                    /*
                    //tempItem.name = newMDIChild.name;
                    string[] file = File.ReadAllLines(dlg.FileName);
                        //int[] positions = new int[file.Length];
                        //double[] uvs = new double[file.Length];

                        for (int i = 0; i <= file.Length; i++)
                        {

                            foreach (var item in file)
                            {

                                // This splits the values up
                                string[] values = item.Split();


                                // This adds each point to their respective lists.
                                //startPoints.Add(new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1])));
                                //endPoints.Add(new Point(Convert.ToInt32(values[2]), Convert.ToInt32(values[3])));
                                //startUVpoints.Add(new PointD(Convert.ToDouble(values[4]), Convert.ToDouble(values[5])));
                                //endUVpoints.Add(new PointD(Convert.ToDouble(values[6]), Convert.ToDouble(values[7])));
                                // increments the counter when everything is added.

                                counter++;

                            }



                        }*/
                    //}

                }
            }

        }



        public List<MouseEventArgs> positions = new List<MouseEventArgs>();
        public Form1()
        {
            InitializeComponent();
            //this.DoubleBuffered = true;

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(pictureBox1_Paint);
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
           
        }

  
 


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Left)
            //{
            //   // p2 = e.Location;
            //    this.Invalidate();
            //    textOutput.Text = r1.ToString() + r2.ToString();
            //}
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //if (p1.X > 0 && p1.Y > 0 && p2.X > 0 && p2.Y > 0)
            //    e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(r1.X, r1.Y, r2.X - r1.X, r2.Y - r1.Y));
        }



        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {


        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            bool startOfFile = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
     
                    StreamWriter myStream = new StreamWriter(saveFileDialog1.FileName);


                if (startOfFile == false)
                {
                    //this writes the new line for the file.
                    myStream.Write("\r\n");
                }

                myStream.Write(pic1.X.ToString() + " ");
                myStream.Write(pic1.Y.ToString() + " ");
                myStream.Write(pic2.X.ToString() + " ");
                myStream.Write(pic2.Y.ToString() + " ");
                myStream.Write(startPointUVX.ToString("n2") + " ");
                myStream.Write(startPointUVY.ToString("n2") + " ");
                myStream.Write(endPointUVX.ToString("n2") + " ");
                myStream.Write(endPointUVY.ToString("n2") + " ");
                startOfFile = false;

                // incorporate in a for loop for outputing to a file.
                //for (int i = 0; i <= items.Count; i++)
                //{

                //}


                // Code to write the stream goes here. 
                myStream.Close();
                
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textOutput.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pic2 = e.Location;
                rPic2 = pic2;
            }
            if (pic2.X < pic1.X)
            {
                rPic2.X = pic1.X;
                rPic1.X = pic2.X;

            }
            if (pic2.Y < pic1.Y)
            {
                rPic2.Y = pic1.Y;
                rPic1.Y = pic2.Y;

            }
            this.Invalidate();


        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                tempItem.startPoint = new Point(-1, 1);
                tempItem.endPoints = new Point(-1, 1);
                tempItem.startUVpoint.x = 0.0;
                tempItem.startUVpoint.y = 0.0;
                tempItem.endUVpoint.x = 0.0;
                tempItem.endUVpoint.y = 0.0;

                pic1 = e.Location;
                rPic1 = pic1;
            }
            

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {


            


            if (e.Button == MouseButtons.Left)
            {

               
                
                // this will do the calculations of the UV for us dynamically.
                startPointUVX = ((float)pic1.X / (float)pictureBox1.Width);
                startPointUVY = ((float)pic1.Y / (float)pictureBox1.Height);

                endPointUVX = ((float)pic2.X / (float)pictureBox1.Width);
                endPointUVY = ((float)pic2.Y / (float)pictureBox1.Height);

                


                pic2 = e.Location;
                //textOutput.Text = "startpos =" + pic1.X.ToString() + " " + pic1.Y.ToString() + Environment.NewLine;
                //textOutput.Text += "endpos =" + pic2.X.ToString() + " " + pic2.Y.ToString() + Environment.NewLine;
                //textOutput.Text += "startUV =" + startPointUVX.ToString("n2") + ", " + startPointUVY.ToString("n2") + Environment.NewLine;
                //textOutput.Text += "endUV =" + endPointUVX.ToString("n2") + ", " + endPointUVY.ToString("n2") + Environment.NewLine;
                textOutput.Text = pic1.X.ToString() + "," + pic1.Y.ToString() + Environment.NewLine;
                textOutput.Text += pic2.X.ToString() + "," + pic2.Y.ToString() + Environment.NewLine;
                textOutput.Text += startPointUVX.ToString("n2") + "," + startPointUVY.ToString("n2") + Environment.NewLine;
                textOutput.Text += endPointUVX.ToString("n2") + "," + endPointUVY.ToString("n2") + Environment.NewLine;



                // Changes the text in the labels.
                lblStartUVText.Text = startPointUVX.ToString("n2") + ", " + startPointUVY.ToString("n2");
                lblEndUVText.Text = endPointUVX.ToString("n2") + ", " + endPointUVY.ToString("n2");


                tempItem.startPoint = pic1;
                tempItem.endPoints = pic2;
                tempItem.startUVpoint.x = startPointUVX;
                tempItem.startUVpoint.y = startPointUVY;
                tempItem.endUVpoint.x = endPointUVX;
                tempItem.endUVpoint.y = endPointUVY;

            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pic1.X > 0 && pic1.Y > 0 && pic2.X > 0 && pic2.Y > 0)
            {
               e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(rPic1.X, rPic1.Y, rPic2.X - rPic1.X, rPic2.Y - rPic1.Y));                
            }
            for (int i = 0; i < counter; i++)
            {
                //e.Graphics.DrawRectangle(Pens.Red, rectangles.ElementAt(i));
            }
        }

        private void btnSaveRec_Click(object sender, EventArgs e)
        {
            if (txtRecName != null)
            {
                lstItems.Items.Add(txtRecName.Text);
                items.Add(tempItem);
                tempItem = new Item();
            }
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedIndex == -1)
            {
                textOutput.Text = "";
            }
           

            textOutput.Text = items.ElementAt(lstItems.SelectedIndex).startPoint.ToString() + Environment.NewLine;
            textOutput.Text += items.ElementAt(lstItems.SelectedIndex).endPoints.ToString() + Environment.NewLine;
            

        }




        private void lstItems_DoubleClick(object sender, EventArgs e)
        {
            int index = lstItems.SelectedIndex;

            textOutput.Text = items.ElementAt(index).startPoint.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           pictureBox1.Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadNewPict();
        }

        private void btnUVLoad_Click(object sender, EventArgs e)
        {

           
            //newMDIChild.parent = this;
            
            //if (newMDIChild)
            //{

            //}

            LoadUVCoords();
           

          
            
            
            
        }

    }
}
