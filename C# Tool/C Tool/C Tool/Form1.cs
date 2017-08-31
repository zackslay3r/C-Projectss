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
        Point endPoint;
        MainFormManager mfrmmanager = new MainFormManager();
        public Item tempItem = new Item();
        public List<Item> items = new List<Item>();
        public AddName AddNameForm = new AddName();
        public string[] file;
        private int selectedIndex;
        public double StartUVX, StartUVY, EndUVX, EndUVY;

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


        // Copy the selected area to the clipboard.
        private void setImage(Rectangle src_rect)
        {
            if (src_rect.Height != 0 && src_rect.Width != 0)
            {
                // Make a bitmap for the selected area's image.
                Bitmap bm = new Bitmap(src_rect.Width, src_rect.Height);

                // Copy the selected area into the bitmap.
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    if (pictureBox1.Image != null)
                    {
                        Rectangle dest_rect =
                            new Rectangle(0, 0, src_rect.Width, src_rect.Height);
                        gr.DrawImage(pictureBox1.Image, dest_rect, src_rect,
                            GraphicsUnit.Pixel);
                    }
                }

                // Copy the selection image to the clipboard.
                //Clipboard.SetImage(bm);
                pictureBox2.Image = bm;

            }
        }

        public void CheckBounds(Point mousePos)
        {
            if (rec.X < 0)
            {
                rec.X = 0;
            }
            if (rec.Y < 0)
            {
                rec.Y = 0;
            }

            if (rec.Left < 0)
            {
                rec.Location = new Point(0, rec.Top);
                scaleWidith = false;
            }
            else if(mousePos.X + 2 > pictureBox1.Width)
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
            else if(mousePos.Y + 2 > pictureBox1.Height)
            {
                rec.Location = new Point(rec.Left, pictureBox1.Height - rec.Height - 1);
                scaleHeight = false;
            }
            else
            {
                scaleHeight = true;
            }


      

        }

        public void cleanStart()
        {
            if (rec.X < 0)
            {
                rec.X = 0;
            }
            if (rec.Y < 0)
            {
                rec.Y = 0;
            }
        }

        public void CleanUpUVS()
        {
            if((double)EndUVX > 1)
            {
                EndUVX = 1;
            }
            if ((double)EndUVY > 1)
            {
                EndUVY = 1;
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
                rec.Location = new Point(pictureBox1.Width - rec.Width, rec.Top - 1);
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

        public void calUVS()
        {
            // creates a temporary endpoint.
            endPoint = new Point();

            // this is set to the start point + width if its x or height id its y
            endPoint.X = rec.Location.X + rec.Width;
            endPoint.Y = rec.Location.Y + rec.Height;



            StartUVX = ((double)rec.Location.X / (double)pictureBox1.Width);
            StartUVY = ((double)rec.Location.Y / (double)pictureBox1.Height);
            EndUVX = ((double)endPoint.X / (double)pictureBox1.Width);
            EndUVY = ((double)endPoint.Y / (double)pictureBox1.Height);

            CleanUpUVS();

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
                    pictureBox1.SizeMode = PictureBoxSizeMode.Normal;

                    pictureBox1.Image = Image.FromFile(dlg.FileName);

                    //picBox.Image = PictureBox1.Image;

                }
            }
        }

        int i = 0;
        public void animation()
        {
            
            if (chkTestAni.Checked == true)
            {
                setImage(items.ElementAt(i).rectangle);
                pictureBox2.Refresh();
              
                i++;
                if (i == items.Count)
                {
                    i = 0;
                }
                
            }
        }


        public void LoadUVCoords()
        {
            bool loadComplete = false;




            using (OpenFileDialog dlg = new OpenFileDialog())
            {

                dlg.Title = "Open UV";
                dlg.Filter = "Text files (.txt)| *.txt";


                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    AddNameForm.Show();
                    AddNameForm.theFileName = dlg.FileName;
                    AddNameForm.parent = this;

                    AddNameForm.file = File.ReadAllLines(dlg.FileName);
                    foreach (var item in AddNameForm.file)
                    {

                        // This splits the values up and stores them in the temporary item.
                        string[] values = item.Split();
                        tempItem.startPoint = (new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1])));
                        tempItem.endPoints = (new Point(Convert.ToInt32(values[2]), Convert.ToInt32(values[3])));
                        tempItem.startUVpoint = (new PointD(Convert.ToDouble(values[4]), Convert.ToDouble(values[5])));
                        tempItem.endUVpoint = (new PointD(Convert.ToDouble(values[6]), Convert.ToDouble(values[7])));
                        tempItem.rectangle = new Rectangle(tempItem.startPoint.X, tempItem.startPoint.Y, Math.Abs(tempItem.startPoint.X - tempItem.endPoints.X), Math.Abs(tempItem.startPoint.Y - tempItem.endPoints.Y));
                        AddNameForm.ofItemsToChange.Add(tempItem);
                        tempItem = new Item();
                    }

                }
            }







        }

        public static Bitmap CropImage(Image source, int x, int y, int width, int height)
        {
            if (width != 0 && height != 0)
            {

                Rectangle crop = new Rectangle(x, y, width, height);
                var bmp = new Bitmap(crop.Width, crop.Height);
                using (var gr = Graphics.FromImage(bmp))
                {
                    gr.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), crop, GraphicsUnit.Pixel);
                }
                return bmp;
            }
            else
            {
                var bmp = new Bitmap(1,1);
                return bmp;
            }
              
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
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
                e.Graphics.DrawRectangle(Pens.LightGreen, rec);
            
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
        //can also use this one:
        //if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                lstItems.SelectedIndex = -1;
                rPic1 = e.Location;
                tempItem.startPoint = rPic1;
                rec = new Rectangle(e.X, e.Y, 1, 1);

                CheckBounds(e.Location);

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

                //lblStartPText.Text = rPic1.X.ToString() + " " + rPic1.Y.ToString();
                //lblEndPText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();

                txtStartText.Text = rPic1.X.ToString() + " " + rPic1.Y.ToString();
                txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();
                calUVS();
                txtStartUV.Text = StartUVX.ToString("n2") + " " + StartUVY.ToString("n2");
                txtEndUV.Text = EndUVX.ToString("n2") + " " + EndUVY.ToString("n2");


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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LoadUVCoords();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                lstItems.Items.RemoveAt(selectedIndex);
                items.RemoveAt(selectedIndex);
                txtStartText.Text = " ";
                txtEndText.Text = " ";
                txtStartText.Text = " ";
                txtEndUV.Text = " ";
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
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

        private void btnClearArea_Click(object sender, EventArgs e)
        {
            //lblEndPText.Text = " ";
            //lblStartPText.Text = " ";
            //lblStartUvText.Text = " ";
            //lblEndUvText.Text = " ";
            txtStartText.Text = " ";
            txtEndText.Text = " ";
            txtStartText.Text = " ";
            txtEndUV.Text = " ";
            
            rec = new Rectangle();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTestAni_Click(object sender, EventArgs e)
        {
            
        
        }

        private void chkTestAni_CheckedChanged(object sender, EventArgs e)
        {
            bool doAni = chkTestAni.Checked;
            if (doAni == false)
            {
                i = 0;
             
            }
        }

        private void tmrAniTimer_Tick(object sender, EventArgs e)
        {
            animation();
        }

        private void lblStartPText_Click(object sender, EventArgs e)
        {

        }

        private void txtStartText_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }


        //public void widthException(bool higherOrLower)
        //{
        //    if (higherOrLower == true)
        //    {
        //        MessageBox.Show("The x coordinate you inputted is greater then the imagebox. Try a value that's lower.");
        //    }
        //    else
        //    {
        //        MessageBox.Show("The x coordinate you inputted is lower then the imagebox. Try a value that's .");
        //    }
        //}

        public class widthException : Exception
        {
            public widthException(string message) : base(message)
            {
            }


        }
        public class heightException : Exception
        {
            public heightException(string message) : base(message)
            {
            }


        }

        private void txtStartText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string[] values = txtStartText.Text.Split();
                    if (Convert.ToInt32(values[0]) < 0 || Convert.ToInt32(values[1]) < 0)
                    {
                        throw new widthException("x or y value less than the picturebox.");
                    }
                    if ((Convert.ToInt32(values[0]) + rec.Width) >= pictureBox1.Width || (Convert.ToInt32(values[1]) + rec.Height) >= pictureBox1.Height)
                    {
                        throw new widthException("out of bounds.");
                    }
                    if (Convert.ToInt32(values[0]) < rec.Location.X && Convert.ToInt32(values[1]) < rec.Location.Y)
                    {


                        rec.Location = new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));
                        txtStartText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString() + " ";
                        txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();

                    }
                    else if (Convert.ToInt32(values[0]) > rec.Location.X && Convert.ToInt32(values[1]) > rec.Location.Y)
                    {
                        //if ((rec.Location.X + rec.Width) >= pictureBox1.Width || (rec.Location.Y + rec.Height) >= pictureBox1.Height)
                        //{
                        //    throw new widthException("out of bounds.");
                        //}

                        int tempWidth, tempHeight;

                        tempWidth = Math.Abs(Convert.ToInt32(values[0]) - (rec.Width + rec.Location.X));
                        tempHeight = Math.Abs(Convert.ToInt32(values[1]) - (rec.Height + rec.Location.Y));

                        rec.Width = tempWidth;
                        rec.Height = tempHeight;

                        rec.Location = new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));

                        //rec.Width = Convert.ToInt32(values[0]) - rec.Location.X;
                        //rec.Height = Convert.ToInt32(values[1]) - rec.Location.Y;

                        //rec.Width = rec.Location.X -

                        rec.Location = new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));
                        txtStartText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString() + " ";
                        txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();

                    }
                    else if (Convert.ToInt32(values[0]) > (rec.Location.X + rec.Width) && Convert.ToInt32(values[1]) < (rec.Location.Y + rec.Height))
                    {
                        throw new widthException("awkward. you are not making a rectangle.");
                    }
                    else if (Convert.ToInt32(values[0]) < (rec.Location.X + rec.Width) && Convert.ToInt32(values[1]) > (rec.Location.Y + rec.Height))
                    {
                        throw new widthException("awkward. you are not making a rectangle.");
                    }
                    else
                    {
                        throw new widthException("awkward. i dont know what you are doing.");
                    }
                    //        string[] values = txtStartText.Text.Split();

                    //        if (Convert.ToInt32(values[0]) > pictureBox1.Width - rec.Width)
                    //        {
                    //            throw new widthException("The x coordinate you inputted is greater than the imagebox.Try a value that's lower.");
                    //        }
                    //        if (Convert.ToInt32(values[0]) < 0)
                    //        {
                    //            throw new widthException("The x coordinate you inputted is less than the imagebox.Try a value that's higher.");
                    //        }
                    //        if (Convert.ToInt32(values[1]) > pictureBox1.Height - rec.Height)
                    //        {
                    //            throw new heightException("The y coordinate you inputted is greater than the imagebox.Try a value that's lower.");
                    //        }
                    //        if (Convert.ToInt32(values[1]) < 0)
                    //        {
                    //            throw new heightException("The y coordinate you inputted is less than the imagebox.Try a value that's higher.");
                    //        }
                    //        Point tmpPnt = new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));

                    //        int tempW = rec.Location.X - Convert.ToInt32(values[0]);
                    //        int tempH = rec.Location.Y - Convert.ToInt32(values[1]);

                    //        //tempW = rec.Width;
                    //        //tempH = rec.Height;


                    //        rec.Location = tmpPnt;

                    //        if (tempW >= 0)
                    //        {
                    //            rec.Width += tempW;
                    //        }
                    //        if (tempH >= 0)
                    //        {
                    //            rec.Height += tempH;
                    //        }

                    //        txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();
                    //        tmpPnt = new Point();

                    //        //rec.Location = new Point(rec.Location.X + rec.Width, rec.Location.Y + rec.Height);
                    //        //txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();
                    //    }


                    //    catch (widthException ex)
                    //    {
                    //        MessageBox.Show(ex.Message);
                    //        txtStartText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString();
                    //    }
                    //    catch (heightException ex)
                    //    {
                    //        MessageBox.Show(ex.Message);
                    //        txtEndText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString();
                    //    }

                    //    catch
                    //    {


                    //        MessageBox.Show("Please input valid data for the start box. (Int Int)");
                    //        txtStartText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString();
                    //    }
                    //}
                }
                catch (widthException ex)
                {
                    MessageBox.Show(ex.Message);
                    txtStartText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString() + " ";
                }
                catch
                {
                    MessageBox.Show("failed Input.");
                }
            }
        }

        private void txtEndText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string[] values = txtEndText.Text.Split();

                    if (Convert.ToInt32(values[0]) < rec.Location.X && Convert.ToInt32(values[1]) < rec.Location.Y)
                    {
                        if (Convert.ToInt32(values[0]) < 0 || Convert.ToInt32(values[1]) < 0)
                        {
                            throw new widthException("Either the X or Y is less than the picturebox.");
                        }


                        int tempInt;
                        tempInt = rec.Location.X;
                        rec.Location = new Point(Convert.ToInt32(values[0]), rec.Location.Y);
                        rec.Width = tempInt - Convert.ToInt32(values[0]);
                        tempInt = 0;
                        tempInt = rec.Location.Y;
                        rec.Location = new Point(rec.Location.X, Convert.ToInt32(values[1]));
                        rec.Height = tempInt - Convert.ToInt32(values[1]);
                        txtStartText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString() + " ";
                        txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();


                    }
                    else if (Convert.ToInt32(values[0]) > rec.Location.X && Convert.ToInt32(values[1]) > rec.Location.Y)
                    {
                        if (Convert.ToInt32(values[0]) >= pictureBox1.Width || Convert.ToInt32(values[1]) >= pictureBox1.Height)
                        {
                            throw new widthException("Either the X or Y is more than the picturebox.");
                        }

                        int tempWidith, tempHeight;

                        tempWidith = Convert.ToInt32(values[0]) - rec.Location.X;
                        tempHeight = Convert.ToInt32(values[1]) - rec.Location.Y;
                        rec.Width = tempWidith;
                        rec.Height = tempHeight;
                    }
                    else if(Convert.ToInt32(values[0]) > rec.Location.X && Convert.ToInt32(values[1]) < rec.Location.Y)
                    {
             

                        throw new widthException("awkward. you are not making a rectangle.");
                    }
                    else if (Convert.ToInt32(values[0]) < rec.Location.X && Convert.ToInt32(values[1]) > rec.Location.Y)
                    {
                        throw new widthException("awkward. you are not making a rectangle.");
                    }
                    else
                    {
                        throw new widthException("awkward. i dont know what you are doing.");
                    }


                    //if(Convert.ToInt32(values[0]) < rec.Location.X && Convert.ToInt32(values[0]) )
                    //{

                    //    int tempInt = rec.Location.X;
                    //    rec.Location = new Point(Convert.ToInt32(values[0]), rec.Location.Y);
                    //    //rec.Width = tempInt;
                    //    rec.Width = Math.Abs(tempInt - rec.Location.X);

                    //}




                    //if(Convert.ToInt32(values[0]) < rec.Location.X)
                    //{
                    //    throw new widthException("The endpoint along the x coordinate is less than the startpoint x. pick an x coord thats higher.");
                    //}
                    //if (Convert.ToInt32(values[0]) < rec.Location.Y)
                    //{
                    //    throw new widthException("The endpoint along the y coordinate is less than the startpoint y. pick an y coord thats higher.");
                    //}

                    //if (Convert.ToInt32(values[0]) > pictureBox1.Width - rec.Width)
                    //{
                    //    throw new widthException("The x coordinate you inputted is greater than the imagebox.Try a value that's lower.");
                    //}
                    //if (Convert.ToInt32(values[0]) < 0)
                    //{
                    //    throw new widthException("The x coordinate you inputted is less than the imagebox.Try a value that's higher.");
                    //}
                    //if (Convert.ToInt32(values[1]) > pictureBox1.Height - rec.Height)
                    //{
                    //    throw new heightException("The y coordinate you inputted is greater than the imagebox.Try a value that's lower.");
                    //}
                    //if (Convert.ToInt32(values[1]) < 0)
                    //{
                    //    throw new heightException("The y coordinate you inputted is less than the imagebox.Try a value that's higher.");
                    //}


                    //rec.Width = Math.Abs(Convert.ToInt32(values[0]) - rPic1.X);
                    //rec.Height = Math.Abs(Convert.ToInt32(values[1]) - rPic1.Y);
                    //rec.Width = Math.Abs(rec.Location.X - Convert.ToInt32(values[0]));
                    //rec.Height = Math.Abs(rec.Location.Y - Convert.ToInt32(values[1]));

                    // int tempvar = Convert.ToInt32(values[0]) - rec.Location.X;
                    //int tempW, tempH;


                    //tempW = Convert.ToInt32(values[0])- rec.Location.X - rec.Width;
                    //tempH = Convert.ToInt32(values[1])- rec.Location.Y - rec.Height;

                    ////    rec.Width += tempW;

                    //////else
                    //////{
                    //// //   rec.Width -= tempW;
                    //////}

                    ////    rec.Height += tempH;

                    //else
                    //{
                    //  rec.Height -= tempH;
                    //}
                    //Point tempPt;


                    //tempPt = new Point(rec.Location.X - rec.Width, rec.Location.Y - rec.Height);
                    //if (Convert.ToInt32(values[0]) < rec.Location.X || Convert.ToInt32(values[1]) < rec.Location.Y)
                    //{
                    //    if (tempPt.X > pictureBox1.Width)
                    //    {
                    //        throw new widthException("this would cause the rectangle to be drawn outside along the width. fail.");
                    //    }
                    //    else if (tempPt.Y > pictureBox1.Height)
                    //    {
                    //        throw new heightException("this would cause the rectangle to be drawn outside along the height. fail.");
                    //    }
                    //    else if (tempPt.X < 0)
                    //    {
                    //        throw new widthException("this would cause the rectangle to be drawn outside along the width. fail.");
                    //    }
                    //    else if (tempPt.Y < 0)
                    //    {
                    //        throw new widthException("this would cause the rectangle to be drawn outside along the height. fail.");
                    //    }
                    //    else
                    //    {
                    //        rec.Location = new Point(rec.Location.X - rec.Width, rec.Location.Y - rec.Height);
                    //        txtStartText.Text = (rec.Location.X - rec.Width).ToString() + " " + (rec.Location.Y - rec.Height).ToString();
                    //    }
                    //}
                }


                catch (widthException ex)
                {
                    MessageBox.Show(ex.Message);
                    txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();
                }

                catch
                {


                    MessageBox.Show("Please input valid data for the start box. (Int Int)");
                    txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();

                }
            }
        }

        private void txtStartUV_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] values = txtStartUV.Text.Split();

                if (Convert.ToDouble(values[0]) < 0.00 || Convert.ToDouble(values[0]) < 0.00)
                {
                    throw new widthException("the UV inputted is less then the picturebox.");
                }
              

            }
            catch
            {

            }
        }

        private void lstItems_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstItems.SelectedIndex == -1)
            {

                btnDeleteItem.Visible = false;
            }
            else
            {
                btnDeleteItem.Visible = true;



                ////lblStartPText.Text = items.ElementAt(lstItems.SelectedIndex).startPoint.X.ToString() + " ";
                ////lblStartPText.Text += items.ElementAt(lstItems.SelectedIndex).startPoint.Y.ToString() + Environment.NewLine;

                txtStartText.Text = items.ElementAt(lstItems.SelectedIndex).startPoint.X.ToString() + " ";
                txtStartText.Text += items.ElementAt(lstItems.SelectedIndex).startPoint.Y.ToString();


                ////lblEndPText.Text = items.ElementAt(lstItems.SelectedIndex).endPoints.X.ToString() + " ";
                ////lblEndPText.Text += items.ElementAt(lstItems.SelectedIndex).endPoints.Y.ToString() + Environment.NewLine;

                txtEndText.Text = items.ElementAt(lstItems.SelectedIndex).endPoints.X.ToString() + " ";
                txtEndText.Text += items.ElementAt(lstItems.SelectedIndex).endPoints.Y.ToString();


                ////lblStartUvText.Text = items.ElementAt(lstItems.SelectedIndex).startUVpoint.x.ToString("n2") + " ";
                ////lblStartUvText.Text += items.ElementAt(lstItems.SelectedIndex).startUVpoint.y.ToString("n2") + Environment.NewLine;

                txtStartUV.Text = items.ElementAt(lstItems.SelectedIndex).startUVpoint.x.ToString("n2") + " ";
                txtStartUV.Text += items.ElementAt(lstItems.SelectedIndex).startUVpoint.y.ToString("n2");

                ////lblEndUvText.Text = items.ElementAt(lstItems.SelectedIndex).endUVpoint.x.ToString("n2") + " ";
                ////lblEndUvText.Text += items.ElementAt(lstItems.SelectedIndex).endUVpoint.y.ToString("n2") + Environment.NewLine;

                txtEndUV.Text = items.ElementAt(lstItems.SelectedIndex).endUVpoint.x.ToString("n2") + " ";
                txtEndUV.Text += items.ElementAt(lstItems.SelectedIndex).endUVpoint.y.ToString("n2");

                //txtStartText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString();
                //txtEndText.Text = endPoint.X.ToString() + " " + endPoint.Y.ToString();
                //txtStartUV.Text = StartUVX.ToString("n2") + " " + StartUVY.ToString("n2");
                //txtEndUV.Text = EndUVX.ToString("n2") + " " + EndUVY.ToString("n2");


                selectedIndex = lstItems.SelectedIndex;

                setImage(items.ElementAt(lstItems.SelectedIndex).rectangle);
                //pictureBox2.Image = CropImage(pictureBox1.Image, rec.Location.X, rec.Location.Y, rec.Width, rec.Height);
                pictureBox1.Invalidate();
                pictureBox2.Invalidate();
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRecName != null)
            {
                lstItems.Items.Add(txtRecName.Text);
                tempItem.rectangle = rec;
                items.Add(tempItem);
                tempItem = new Item();
            }
            lblEndPText.Text = " ";
            lblStartPText.Text = " ";
            lblStartUvText.Text = " ";
            lblEndUvText.Text = " ";
            
            rec = new Rectangle();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                cleanStart();
                //Point endPoint = new Point();


                //endPoint.X = rec.Location.X + rec.Width;
                //endPoint.Y = rec.Location.Y + rec.Height;

                //StartUVX = ((double)rec.Location.X  / (double)pictureBox1.Width);
                //StartUVY = ((double)rec.Location.Y / (double)pictureBox1.Height);
                //EndUVX = ((double)endPoint.X / (double)pictureBox1.Width);
                //EndUVY = ((double)endPoint.Y / (double)pictureBox1.Height);
                calUVS();
                

                //EndUVX = ((double)e.X / (double)pictureBox1.Width);
                //EndUVY = ((double)e.Y / (double)pictureBox1.Height);
                //EndUVX = ((double)rec.Location.X + (double)rec.Width / (double)pictureBox1.Width);
                //EndUVY = ((double)rec.Location.Y + (double)rec.Height / (double)pictureBox1.Height);

                CleanUpUVS();

                //lblStartPText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString();
                //lblEndPText.Text = endPoint.X.ToString() + " " + endPoint.Y.ToString();
                //lblStartUvText.Text = StartUVX.ToString("n2") + " " + StartUVY.ToString("n2");
                //lblEndUvText.Text = EndUVX.ToString("n2") + " " + EndUVY.ToString("n2");

                txtStartText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString();
                txtEndText.Text = endPoint.X.ToString() + " " + endPoint.Y.ToString();
                txtStartUV.Text = StartUVX.ToString("n2") + " " + StartUVY.ToString("n2");
                txtEndUV.Text = EndUVX.ToString("n2") + " " + EndUVY.ToString("n2");


                tempItem.startPoint = rec.Location;
                tempItem.endPoints = endPoint;
                tempItem.startUVpoint.x = StartUVX;
                tempItem.startUVpoint.y = StartUVY;
                tempItem.endUVpoint.x = EndUVX;
                tempItem.endUVpoint.y = EndUVY;

                //ConvertCoordinates(pictureBox1, rPic1.X, rPic1.Y, e.X, e.Y);

                setImage(rec);
                //pictureBox2.Image = CropImage(pictureBox1.Image, rec.Location.X, rec.Location.Y, rec.Width, rec.Height);

                pictureBox2.Invalidate();
            }
            if(e.Button == MouseButtons.Right)
            {
                

            }
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            pictureBox2.Refresh();
            
        }
    }
}
