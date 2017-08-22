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

        // UV points
        // This is the creation of temporary floats for the storage of UV calculations.
        float startPointUVX, startPointUVY, endPointUVX, endPointUVY;

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

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open UV";
                dlg.Filter = "Text files (.txt)| *.txt";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //var data = File
                    //.ReadAllLines(dlg.FileName)
                    //.Select(x => x.Split('='))
                    //.Where(x => x.Length > 1)
                    //.ToDictionary(x => x[0].Trim(), x => x[1]);

                    ////textOutput.Text += ("startpos: {0}" + data["startpos"]);
                    ////textOutput.Text += ("endpos: {0}" +  data["endpos"]);
                    ////textOutput.Text += ("startUV: {0}" + data["startUV"]);
                    //pic1 = data["startpos"];
                    //using (TextReader reader = File.OpenText(dlg.FileName))
                    //{

                    //    int x = int.Parse(reader.ReadLine());
                    //    double y = double.Parse(reader.ReadLine());
                    //    string z = reader.ReadLine();
                    //}

                    //var positions = File.ReadLines(dlg.FileName).Select(int.Parse);
                    //var uvs = File.ReadLines(dlg.FileName).Select(float.Parse);
                    //int index = 0;

                    //foreach (var number in positions)
                    //{
                    //    numbers[index++] = number;
                    //}
                    //if ((myStream = dlg.OpenFile()) != null)
                    //{
                    //    using (var reader = new StreamReader(myStream))
                    //    {


                    //    }

                    //}
                    string[] file = File.ReadAllLines(dlg.FileName);
                    int[] positions = new int[file.Length];
                    double[] uvs = new double[file.Length];
                    int counter = 0;

                    foreach (var item in file)
                    {
                        string[] values = item.Split(',');
                        if (counter < 4)
                        {
                            positions[counter] = Convert.ToInt32(values[0]);
                            counter++;
                            positions[counter] = Convert.ToInt32(values[1]);
                            counter++;
                        }
                        else
                        {
                            if (counter > 0)
                            {
                                counter = 0;
                            }
                            while (counter < 4)
                            {
                                uvs[counter] = Convert.ToDouble(values[0]);
                                counter++;
                                uvs[counter] = Convert.ToDouble(values[1]);
                                counter++;
                            }
                           
                        }
                    }

                }

            }


        }



        public List<MouseEventArgs> positions = new List<MouseEventArgs>();
        public Form1()
        {
            InitializeComponent();
            //this.DoubleBuffered = true;

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(pictureBox1_Paint);
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
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
            {
                p1 = e.Location;
                r1 = p1;
            }
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
                textOutput.Text = r1.ToString() + r2.ToString();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (p1.X > 0 && p1.Y > 0 && p2.X > 0 && p2.Y > 0)
                e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(r1.X, r1.Y, r2.X - r1.X, r2.Y - r1.Y));
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
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
                //if ((saveFileDialog1.OpenFile()) != null)
                //{
                    StreamWriter myStream = new StreamWriter(saveFileDialog1.FileName);
                    //byte[] bytes = Encoding.ASCII.GetBytes(textOutput.Text);
                    //byte[] bytes = Encoding.ASCII.GetBytes(pic1.X.ToString() + " ");
                    
                    //bytes = Encoding.ASCII.GetBytes(pic1.Y.ToString() +  " ");
                    //myStream.Write(bytes, 0, bytes.Length);
                    //bytes = Encoding.ASCII.GetBytes(pic2.X.ToString() + " ");
                    //myStream.Write(bytes, 0, bytes.Length);
                    //bytes = Encoding.ASCII.GetBytes(pic1.Y.ToString() + " ");
                    //myStream.Write(bytes, 0, bytes.Length);
                    //bytes = Encoding.ASCII.GetBytes(startPointUVX.ToString("n2") + " ");
                    //myStream.Write(bytes, 0, bytes.Length);
                    //bytes = Encoding.ASCII.GetBytes(startPointUVY.ToString("n2") + " ");
                    //myStream.Write(bytes, 0, bytes.Length);
                    //bytes = Encoding.ASCII.GetBytes(endPointUVX.ToString("n2") + " ");
                    //myStream.Write(bytes, 0, bytes.Length);
                    //bytes = Encoding.ASCII.GetBytes(endPointUVY.ToString("n2") + " ");
                    //myStream.WriteLine(bytes, 0, bytes.Length);
                    myStream.Write(pic1.X.ToString() + " ");
                    myStream.Write(pic1.Y.ToString() + " ");
                    myStream.Write(pic2.X.ToString() + " ");
                    myStream.Write(pic2.Y.ToString() + " ");
                    myStream.Write(startPointUVX.ToString("n2") + " ");
                    myStream.Write(startPointUVY.ToString("n2") + " ");
                    myStream.Write(endPointUVX.ToString("n2") + " ");
                    myStream.Write(endPointUVY.ToString("n2") + " ");
                    myStream.Write("\r\n");
                    myStream.Write(pic1.X.ToString() + " ");
                    myStream.Write(pic1.Y.ToString() + " ");
                    myStream.Write(pic2.X.ToString() + " ");
                    myStream.Write(pic2.Y.ToString() + " ");
                    myStream.Write(startPointUVX.ToString("n2") + " ");
                    myStream.Write(startPointUVY.ToString("n2") + " ");
                    myStream.Write(endPointUVX.ToString("n2") + " ");
                    myStream.Write(endPointUVY.ToString("n2") + " ");

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

            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pic1.X > 0 && pic1.Y > 0 && pic2.X > 0 && pic2.Y > 0)
            {
               e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(rPic1.X, rPic1.Y, rPic2.X - rPic1.X, rPic2.Y - rPic1.Y));                
            }
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
            LoadUVCoords();
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
