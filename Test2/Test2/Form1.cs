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
using Microsoft.VisualBasic;
namespace Test2
{
    public partial class Form1 : Form
    {
        Rectangle mRect = new Rectangle (0,0,0,0);
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
        bool isRectDrawn = false;

        int widith, height;

        //Graphics Pic1G;
        //Stream myStream;

        public string tempName = " ";


        public Item tempItem = new Item();
        public List<Item> items = new List<Item>();
        public Form2 newMDIChild = new Form2();
        public string[] file;


        public object listItem = null;

        //private List<Point> startPoints = new List<Point>();
        //private List<Point> endPoints = new List<Point>();

        //private List<PointD> startUVpoints = new List<PointD>();
        //private List<PointD> endUVpoints = new List<PointD>();

        //List<Rectangle> rectangles = new List<Rectangle>();

        public int counter = 0;

        public int selectedIndex = 0;
        // UV points
        // This is the creation of temporary floats for the storage of UV calculations.
        double startPointUVX, startPointUVY, endPointUVX, endPointUVY;

        // temporary values for the rectangle movement.
        int tempX, tempY;


        private Point MouseDownLocation;


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
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    pictureBox1.Image = Image.FromFile(dlg.FileName);

                    //picBox.Image = PictureBox1.Image;

                }
            }
            
            widith = pictureBox1.Width;
            height = pictureBox1.Height;
        }
        public void LoadUVCoords()
        {
            bool loadComplete = false;




            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                if (newMDIChild.counter == 0)
                {
                    dlg.Title = "Open UV";
                    dlg.Filter = "Text files (.txt)| *.txt";


                    if (dlg.ShowDialog() == DialogResult.OK)
                    {

                        newMDIChild.Show();
                        newMDIChild.theFileName = dlg.FileName;
                        newMDIChild.parent = this;

                        newMDIChild.file = File.ReadAllLines(dlg.FileName);
                        foreach (var item in newMDIChild.file)
                            {

                                // This splits the values up and stores them in the temporary item.
                                string[] values = item.Split();
                                tempItem.startPoint = (new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1])));
                                tempItem.endPoints = (new Point(Convert.ToInt32(values[2]), Convert.ToInt32(values[3])));
                                tempItem.startUVpoint = (new PointD(Convert.ToDouble(values[4]), Convert.ToDouble(values[5])));
                                tempItem.endUVpoint = (new PointD(Convert.ToDouble(values[6]), Convert.ToDouble(values[7])));

                                newMDIChild.ofItemsToChange.Add(tempItem);
                                tempItem = new Item();
                            }

                    }
                }
              
               
            }                     



        }

        public void CheckBounds(Rectangle rec)
        {
            //if (pic2.X < 0)
            //{
            //    pic2.X = 0;

            //}
            //if (pic2.Y < 0)
            //{
            //    pic2.Y = 0;

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

            if (rec.Left < 0)
            {
                rec.Location = new Point(0, rec.Top);
            }
            if (rec.Top < 0)
            {
                rec.Location = new Point(rec.Left, 0);
            }





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


        }



        public List<MouseEventArgs> positions = new List<MouseEventArgs>();
        public Form1()
        {
            InitializeComponent();
            

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(pictureBox1_Paint);
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            widith = pictureBox1.Width - 1;
            height = pictureBox1.Height - 1;
            btnDelete.Visible = false;

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


                


                // incorporate in a for loop for outputing to a file.
                for (int i = 0; i < items.Count; i++)
                {
                    if (startOfFile == false)
                    {
                        //this writes the new line for the file.
                        myStream.Write("\r\n");
                    }

                    myStream.Write(items.ElementAt(i).startPoint.X.ToString() + " ");
                    myStream.Write(items.ElementAt(i).startPoint.Y.ToString() + " ");
                    myStream.Write(items.ElementAt(i).endPoints.X.ToString() + " ");
                    myStream.Write(items.ElementAt(i).endPoints.Y.ToString() + " ");
                    myStream.Write(items.ElementAt(i).startUVpoint.x.ToString("n2") + " ");
                    myStream.Write(items.ElementAt(i).startUVpoint.y.ToString("n2") + " ");
                    myStream.Write(items.ElementAt(i).endUVpoint.x.ToString("n2") + " ");
                    myStream.Write(items.ElementAt(i).endUVpoint.y.ToString("n2") + " ");
                    startOfFile = false;
                }


                // Code to write the stream goes here. 
                myStream.Close();
                
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textOutput.Text = " ";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            

            if (e.Button == MouseButtons.Left)
            {
                // old code, uncomment if required.
                //pic2 = e.Location;
                rPic2 = pic2;
                
                //pictureBox1.Invalidate();

                mRect.Width = e.X - mRect.X;
                mRect.Height = e.Y - mRect.Y;
                CheckBounds(mRect);
                this.Invalidate();
            }
            

            if (e.Button == MouseButtons.Right)
            {
                if (mRect != null)
                {
                    if (checkCollide(e.Location.X, e.Location.Y, 1, 1, mRect.X, mRect.Y, mRect.Width, mRect.Height))
                    {
                         //MouseDownLocation = e.Location;


                       
                        //mRect.X += (e.X - tempX);
                        //mRect.Y += (e.Y - tempY);

                        //rPic1.X += (e.X - tempX);
                        //rPic1.Y += (e.Y - tempY);

                        //rPic2.X += (e.X - tempX);
                        //rPic2.Y += (e.Y - tempY);


                        if (e.Button == MouseButtons.Right)
                        {
                            mRect.Location = new Point((e.X - MouseDownLocation.X) + mRect.Left, (e.Y - MouseDownLocation.Y) + mRect.Top);
                            MouseDownLocation = e.Location;
                            //this.Invalidate();
                        }

                        pictureBox1.Invalidate();
                    }
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isRectDrawn = false;
            if (e.Button == MouseButtons.Left )
            {
                //old code. uncomment.
                //lstItems.ClearSelected();

                //tempItem.startPoint = new Point(-1, 1);
                //tempItem.endPoints = new Point(-1, 1);
                //tempItem.startUVpoint.x = 0.0;
                //tempItem.startUVpoint.y = 0.0;
                //tempItem.endUVpoint.x = 0.0;
                //tempItem.endUVpoint.y = 0.0;

                

               //pic1 = e.Location;
                rPic1 = e.Location;


                //TROUBLE LINE
                // if this is active, rect's draw fine, but cannot be draggable.
                // if not active, rect's can only be +, but are draggable.
                pic1 = rPic1;



                // new code.
                mRect = new Rectangle(e.X, e.Y, 0, 0);
                CheckBounds(mRect);
                Invalidate();

            }
            if(e.Button == MouseButtons.Right)
            {
                MouseDownLocation = e.Location;
            }
            

                
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            
            


            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                
              

                //if (pic2.X > widith)
                //{
                //    pic2.X = widith;
                //    rPic2 = pic2;

                //}
                //if (pic2.Y > height)
                //{
                //    pic2.Y = height;
                //    rPic2 = pic2;
                //}

                // this will do the calculations of the UV for us dynamically.
                startPointUVX = ((float)pic1.X / (float)pictureBox1.Width);
                startPointUVY = ((float)pic1.Y / (float)pictureBox1.Height);

                endPointUVX = ((float)pic2.X / (float)pictureBox1.Width);
                endPointUVY = ((float)pic2.Y / (float)pictureBox1.Height);


                if(pic1.X > pic2.X && pic1.Y > pic2.Y)
                {
                  



                }



                //if (pic2.X < 0)
                //{
                //    pic2.X = 0;
                //}
                //if (pic2.Y < 0)
                //{
                //    pic2.Y = 0;
                //}
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
                isRectDrawn = true;

                    tempX = mRect.X;
                    tempY = mRect.Y;
               
            }
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //if (pic2.X < 0)
            //{
            //    //pic2.X = 0;
            //    e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(rPic1.X, rPic1.Y, 0 - rPic1.X, rPic2.Y - rPic1.Y));
            //}
            //if (pic2.Y < 0)
            //{
            //    // pic2.Y = 0;
            //    e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(rPic1.X, rPic1.Y, rPic2.X - rPic1.X, 0 - rPic1.Y));
            //}
            //if (pic2.X > pictureBox1.Width)
            //{
            //    // pic2.X = pictureBox1.Width;
            //    e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(rPic1.X, rPic1.Y, pictureBox1.Width - rPic1.X, rPic2.Y - rPic1.Y));
            //}
            //if (pic2.Y > pictureBox1.Height)
            //{
            //    //  pic2.Y = pictureBox1.Height;
            //    e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(rPic1.X, rPic1.Y, rPic2.X - rPic1.X, rPic2.Y - pictureBox1.Height));
            //}
            selectedIndex = lstItems.SelectedIndex;
            if (selectedIndex != -1)
            {
                //e.Graphics.Clear(pictureBox1.BackColor);
                e.Graphics.DrawRectangle(Pens.Red, new Rectangle(items.ElementAt(selectedIndex).startPoint.X,
                                    items.ElementAt(selectedIndex).startPoint.Y,
                                    items.ElementAt(selectedIndex).endPoints.X - items.ElementAt(selectedIndex).startPoint.X,
                                    items.ElementAt(selectedIndex).endPoints.Y - items.ElementAt(selectedIndex).startPoint.Y
                                    ));
            }


            else
            {

                if (pic1.X >= 0 && pic1.Y >= 0 && pic2.X >= 0 && pic2.Y >= 0)
                {
                    //pictureBox1..Refresh();
                    mRect = new Rectangle(rPic1.X, rPic1.Y, rPic2.X - rPic1.X, rPic2.Y - rPic1.Y);
                    
                     
                    if (pictureBox1.Image != null)
                    {
                        e.Graphics.DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
                        //e.Graphics.DrawImage(pictureBox1.Image, new Rectangle(rPic1.X, rPic1.Y, rPic2.X - rPic1.X, rPic2.Y - rPic1.Y), picBoxPreview.Location.X, picBoxPreview.Location.Y, picBoxPreview.Width, picBoxPreview.Height,);
                        //e.Graphics.DrawImage(pictureBox1.Image, picBoxPreview.Location.X, picBoxPreview.Location.Y, picBoxPreview.Width, picBoxPreview.Height);
                        //e.Graphics.DrawImage(pictureBox1.Image, 0, 0, 200, 200);
                     
                    }
                    e.Graphics.DrawRectangle(Pens.Blue, mRect);
                 
                   
                    
                    
                }
                // new code.
                e.Graphics.DrawRectangle(Pens.Blue, mRect);
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
            textOutput.Text = "";
            rPic1.X = 0;
            rPic1.Y = 0;
            rPic2.X = 0;
            rPic2.Y = 0;
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstItems.DoDragDrop(lstItems.Items.IndexOf(selectedIndex), DragDropEffects.Move);

            if (lstItems.SelectedIndex == -1)
            {
                textOutput.Text = "";
                rPic1.X = 0;
                rPic1.Y = 0;
                rPic2.X = 0;
                rPic2.Y = 0;
                btnDelete.Visible = false;
            }
            //else
            //{
            //    btnDelete.Visible = true;



            //    textOutput.Text = items.ElementAt(lstItems.SelectedIndex).startPoint.ToString() + Environment.NewLine;
            //    textOutput.Text += items.ElementAt(lstItems.SelectedIndex).endPoints.ToString() + Environment.NewLine;

            //    selectedIndex = lstItems.SelectedIndex;
            //    pictureBox1.Invalidate();
            //}

        }

        private void lstItems_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Red, new Rectangle(items.ElementAt(lstItems.SelectedIndex).startPoint.X, 
                                    items.ElementAt(lstItems.SelectedIndex).startPoint.Y, 
                                    items.ElementAt(lstItems.SelectedIndex).endPoints.X - items.ElementAt(lstItems.SelectedIndex).startPoint.X,
                                    items.ElementAt(lstItems.SelectedIndex).endPoints.Y - items.ElementAt(lstItems.SelectedIndex).startPoint.Y
                                    ));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(selectedIndex != -1)
            {
                lstItems.Items.RemoveAt(selectedIndex);
                items.RemoveAt(selectedIndex);
            }
        }

        private void lstItems_DragLeave(object sender, EventArgs e)
        {
            //if (selectedIndex != -1)
            //{
            //    lstItems.Items.RemoveAt(selectedIndex);
            //    items.RemoveAt(selectedIndex);
            //}
        }

        //private void lstItems_DragDrop(object sender, DragEventArgs e)
        //{
        //    if (selectedIndex != -1)
        //    {
        //        lstItems.Items.RemoveAt(selectedIndex);
        //        items.RemoveAt(selectedIndex);
        //    }
        //}

        private void lstItems_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstItems.SelectedIndex == -1)
            {
                //textOutput.Text = "";
                //rPic1.X = 0;
                //rPic1.Y = 0;
                //rPic2.X = 0;
                //rPic2.Y = 0;
                btnDelete.Visible = false;
            }
            else
            {
                btnDelete.Visible = true;
                


                textOutput.Text = items.ElementAt(lstItems.SelectedIndex).startPoint.ToString() + Environment.NewLine;
                textOutput.Text += items.ElementAt(lstItems.SelectedIndex).endPoints.ToString() + Environment.NewLine;

                selectedIndex = lstItems.SelectedIndex;
                pictureBox1.Invalidate();
                
            }
            
            
        }

        private void picBoxPreview_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(pictureBox1.Image, picBoxPreview.Location.X, picBoxPreview.Location.Y, picBoxPreview.Width, picBoxPreview.Height);
            //if (isRectDrawn == true)

            if(pictureBox1.Image != null)
            {
                //e.Graphics.DrawImage(pictureBox1.Image, rPic1.X, rPic1.Y, picBoxPreview.Width, picBoxPreview.Height);
                //e.Graphics.DrawImage(pictureBox1.Image, picBoxPreview.Location.X, picBoxPreview.Location.Y, picBoxPreview.Width, picBoxPreview.Height);
                e.Graphics.DrawImage(pictureBox1.Image, mRect);
            }
        }

        private void lblPictures_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
           e.Effect = DragDropEffects.All;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (selectedIndex != -1)
            {
                
                items.RemoveAt(selectedIndex);
                lstItems.Items.RemoveAt(selectedIndex);
            }
        }

        private void Form1_DragLeave(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                lstItems.Items.RemoveAt(selectedIndex);
                items.RemoveAt(selectedIndex);
            }
        }

        private void textOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstItems_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            //lstItems.DoDragDrop(lstItems.Items.IndexOf(selectedIndex), DragDropEffects.Move);
        }

        private void lstItems_DoubleClick(object sender, EventArgs e)
        {
            int index = lstItems.SelectedIndex;

            textOutput.Text = items.ElementAt(index).startPoint.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           pictureBox1.Refresh();
            picBoxPreview.Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadNewPict();
        }

        private void btnUVLoad_Click(object sender, EventArgs e)
        {

           
            LoadUVCoords();
           

          
            
            
            
        }

    }
}
