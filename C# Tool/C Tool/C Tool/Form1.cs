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

        public void addItem()
        {
            lstItems.Items.Add(txtRecName.Text);
            tempItem.rectangle = rec;
            items.Add(tempItem);
            tempItem = new Item();
        }

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

        public void clearEverything()
        {
            // clears the draw area and clear all text fields.
            txtStartText.Text = " ";
            txtEndText.Text = " ";
            txtStartUV.Text = " ";
            txtEndUV.Text = " ";
            txtWidth.Text = " ";
            txtHeight.Text = " ";
            rec = new Rectangle();
        }

        public void mouseUpFill()
        {
            // clean the area.
            cleanStart();

            // calculate the UVs.
            calUVS();

            // clean up the uv's incase it is great then the picture box.
            CleanUpUVS();


            txtStartText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString();
            txtEndText.Text = endPoint.X.ToString() + " " + endPoint.Y.ToString();
            txtStartUV.Text = StartUVX.ToString("n2") + " " + StartUVY.ToString("n2");
            txtEndUV.Text = EndUVX.ToString("n2") + " " + EndUVY.ToString("n2");
            txtWidth.Text = rec.Width.ToString();
            txtHeight.Text = rec.Height.ToString();


            tempItem.startPoint = rec.Location;
            tempItem.endPoints = endPoint;
            tempItem.startUVpoint.x = StartUVX;
            tempItem.startUVpoint.y = StartUVY;
            tempItem.endUVpoint.x = EndUVX;
            tempItem.endUVpoint.y = EndUVY;
            tempItem.width = rec.Width;
            tempItem.height = rec.Height;

            //ConvertCoordinates(pictureBox1, rPic1.X, rPic1.Y, e.X, e.Y);

            setImage(rec);
            //pictureBox2.Image = CropImage(pictureBox1.Image, rec.Location.X, rec.Location.Y, rec.Width, rec.Height);

            pictureBox2.Invalidate();
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

        public void changeInfo(string itemCausing)
        {
            if (itemCausing.Equals("startPoint"))
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
            }
            else if (itemCausing.Equals("endPoint"))
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
                    else if (Convert.ToInt32(values[0]) > rec.Location.X && Convert.ToInt32(values[1]) < rec.Location.Y)
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
            else if (itemCausing.Equals("startUV"))
            {
                try
                {
                    string[] values = txtStartUV.Text.Split();

                    // If the UV inputted is less then 0. thats bad, so dont do it!
                    if (Convert.ToDouble(values[0]) < 0.00 || Convert.ToDouble(values[1]) < 0.00)
                    {
                        throw new widthException("the UV inputted is less then the picturebox.");
                    }



                    // if they dont throw the exceptions, we want to caculate our position from the uv's provided.
                    double startPosX = convertToPixel(Convert.ToDouble(values[0]),pictureBox1.Width);
                    double startPosY = convertToPixel(Convert.ToDouble(values[1]), pictureBox1.Height);



                    // If the UV inputted would be greater then the picturebox, then thats also bad!
                    if (startPosX + rec.Width > pictureBox1.Width || startPosY + rec.Height > pictureBox1.Height)
                    {
                        throw new widthException("the UV inputter is greated then the picutrebox.");
                    }
                    var tempWidth = Convert.ToInt32(startPosX) + rec.Width;
                    var tempHeight = Convert.ToInt32(startPosY) + rec.Height;

                    // and then we want to set the position of the rec to be that of the calculation.

                    rec.Location = new Point(Convert.ToInt32(startPosX), Convert.ToInt32(startPosY));
                    //rec.Width = tempWidth;
                    //rec.Height = tempHeight;


                    // then we want to update the text fields so that the text reflects the new values.
                    txtStartText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString();
                    txtStartUV.Text = Convert.ToDouble(values[0]).ToString("n2") + " " + Convert.ToDouble(values[1]).ToString("n2");
                    txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();



                    double endUVX = rec.Location.X + rec.Width;
                    endUVX = endUVX / pictureBox1.Width;
                    double endUVY = rec.Location.Y + rec.Height;
                    endUVY = endUVY / pictureBox1.Height;

                    txtEndUV.Text = endUVX.ToString("n2") + " " + endUVY.ToString("n2");



                }
                catch (widthException ex)
                {
                    MessageBox.Show(ex.Message);

                }
                catch
                {

                }
            }
            else if (itemCausing.Equals("EndUV"))
            {
                
                    try
                    {
                        string[] values = txtEndUV.Text.Split();
                        // If the UV inputted is less then 0. thats bad, so dont do it!
                        if (Convert.ToDouble(values[0]) < (rec.Location.X / pictureBox1.Width) || Convert.ToDouble(values[1]) < (rec.Location.Y / pictureBox1.Height))
                        {
                            throw new widthException("the UV inputted is less then the start point.");
                        }


                        int endPosX = convertToPixel(Convert.ToDouble(values[0]), pictureBox1.Width);
                        int endPosY = convertToPixel(Convert.ToDouble(values[1]), pictureBox1.Height);
                        if (endPosX > pictureBox1.Width || endPosY > pictureBox1.Height)
                        {
                            throw new widthException("the UV inputted is greater then the picturebox.");
                        }
                        rec.Width = Convert.ToInt32(endPosX) - rec.Location.X;
                        rec.Height = Convert.ToInt32(endPosY) - rec.Location.Y;

                        // then we want to update the text fields so that the text reflects the new values.
                        txtStartText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString();

                        double startuvx, startuvy;

                        startuvx = convertToUV(rec.Location.X, pictureBox1.Width);
                        startuvy = convertToUV(rec.Location.Y, pictureBox1.Height);

                        txtStartText.Text = rec.Location.X + " " + rec.Location.Y;
                        txtStartUV.Text = startuvx.ToString("n2") + " " + startuvy.ToString("n2");
                        txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();
                        txtEndUV.Text = convertToUV(endPosX,pictureBox1.Width).ToString("n2") + " " + convertToUV(endPosY,pictureBox1.Height).ToString("n2");
                        txtWidth.Text = rec.Width.ToString();
                        txtHeight.Text = rec.Height.ToString();

                    }
                    catch (widthException ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    catch
                    {

                    }
                
            }
            else if (itemCausing.Equals("width"))
            {
                try
                {

                    int value = Convert.ToInt32(txtWidth.Text);
                    // we cant have a width of 0.
                    if (value < 0)
                    {
                        throw new widthException("you cannot have the rectangle be a width of 0.");
                    }
                    // we also cant have our width be greater then that of the picturebox.
                    if (rec.Location.X + value > pictureBox1.Width)
                    {
                        throw new widthException("you cannot have the rectangle be a width greater then the picturebox.");
                    }
                    rec.Width = value;



                    double startuvx = Convert.ToDouble(rec.Location.X) / Convert.ToDouble(pictureBox1.Width);
                    double startuvy = Convert.ToDouble(rec.Location.Y) / Convert.ToDouble(pictureBox1.Height);
                    txtStartText.Text = rec.Location.X + " " + rec.Location.Y;
                    txtStartUV.Text = startuvx.ToString("n2") + " " + startuvy.ToString("n2");
                    txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();
                    double endUVx = Convert.ToDouble(rec.Location.X + rec.Width) / Convert.ToDouble(pictureBox1.Width);
                    double endUVy = Convert.ToDouble(rec.Location.Y + rec.Height) / Convert.ToDouble(pictureBox1.Height);

                    txtEndUV.Text = endUVx.ToString("n2") + " " + endUVy.ToString("n2");

                    txtWidth.Text = rec.Width.ToString();
                    txtHeight.Text = rec.Height.ToString();

                }
                catch (widthException ex)
                {
                    MessageBox.Show(ex.Message);

                }
                catch
                {
                }
            }
            else if (itemCausing.Equals("height"))
            {

                try
                {

                    int value = Convert.ToInt32(txtHeight.Text);
                    // we cant have a height of 0.
                    if (value < 0)
                    {
                        throw new widthException("you cannot have the rectangle be a width of 0.");
                    }
                    // we also cant have our height be greater then that of the picturebox.
                    if (rec.Location.Y + value > pictureBox1.Width)
                    {
                        throw new widthException("you cannot have the rectangle be a width greater then the picturebox.");
                    }
                    rec.Height = value;

                    double endPosX = Convert.ToDouble(rec.Location.X + rec.Width) * Convert.ToDouble(pictureBox1.Width);
                    double endPosY = Convert.ToDouble(rec.Location.Y + rec.Height) * Convert.ToDouble(pictureBox1.Height);

                    double startuvx = Convert.ToDouble(rec.Location.X) / Convert.ToDouble(pictureBox1.Width);
                    double startuvy = Convert.ToDouble(rec.Location.Y) / Convert.ToDouble(pictureBox1.Height);
                    txtStartText.Text = rec.Location.X + " " + rec.Location.Y;
                    txtStartUV.Text = startuvx.ToString("n2") + " " + startuvy.ToString("n2");

                    double endUVx = Convert.ToDouble(rec.Location.X + rec.Width) / Convert.ToDouble(pictureBox1.Width);
                    double endUVy = Convert.ToDouble(rec.Location.Y + rec.Height) / Convert.ToDouble(pictureBox1.Height);

                    txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();
                    txtEndUV.Text = endUVx.ToString("n2") + " " + endUVy.ToString("n2");
                    txtWidth.Text = rec.Width.ToString();
                    txtHeight.Text = rec.Height.ToString();

                }
                catch (widthException ex)
                {
                    MessageBox.Show(ex.Message);

                }
                catch
                {
                }
            }
            else
            {

            }
        }
        public double convertToUV(int rectangle, int pictureBox)
        {
            if (rectangle > pictureBox)
            {
                return 0.0;
            }
            else
            {
                double tempUV = Convert.ToDouble(rectangle) / Convert.ToDouble(pictureBox);
                return tempUV;
            }
        }

        public int convertToPixel(double uv, int pictureBox)
        {
            if (uv > 1 || uv < 0)
            {
                return pictureBox;
            }
            else
            {
                double tempPixel = Convert.ToDouble(pictureBox) * uv;
                return Convert.ToInt32(tempPixel);
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


        public void getSelectedItem()
        {
            txtStartText.Text = items.ElementAt(lstItems.SelectedIndex).startPoint.X.ToString() + " ";
            txtStartText.Text += items.ElementAt(lstItems.SelectedIndex).startPoint.Y.ToString();



            txtEndText.Text = items.ElementAt(lstItems.SelectedIndex).endPoints.X.ToString() + " ";
            txtEndText.Text += items.ElementAt(lstItems.SelectedIndex).endPoints.Y.ToString();



            txtStartUV.Text = items.ElementAt(lstItems.SelectedIndex).startUVpoint.x.ToString("n2") + " ";
            txtStartUV.Text += items.ElementAt(lstItems.SelectedIndex).startUVpoint.y.ToString("n2");



            txtEndUV.Text = items.ElementAt(lstItems.SelectedIndex).endUVpoint.x.ToString("n2") + " ";
            txtEndUV.Text += items.ElementAt(lstItems.SelectedIndex).endUVpoint.y.ToString("n2");

            txtWidth.Text = items.ElementAt(lstItems.SelectedIndex).width.ToString();
            txtHeight.Text = items.ElementAt(lstItems.SelectedIndex).height.ToString();


            selectedIndex = lstItems.SelectedIndex;

            setImage(items.ElementAt(lstItems.SelectedIndex).rectangle);

            pictureBox1.Invalidate();
            pictureBox2.Invalidate();

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

                    try
                    {
                        foreach (var item in AddNameForm.file)
                        {

                            // This splits the values up and stores them in the temporary item.
                            string[] values = item.Split();
                            tempItem.startPoint = (new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1])));
                            tempItem.endPoints = (new Point(Convert.ToInt32(values[2]), Convert.ToInt32(values[3])));
                            tempItem.startUVpoint = (new PointD(Convert.ToDouble(values[4]), Convert.ToDouble(values[5])));
                            tempItem.endUVpoint = (new PointD(Convert.ToDouble(values[6]), Convert.ToDouble(values[7])));
                            tempItem.width = Convert.ToInt32(values[8]);
                            tempItem.height = Convert.ToInt32(values[9]);

                            tempItem.rectangle = new Rectangle(tempItem.startPoint.X, tempItem.startPoint.Y, Math.Abs(tempItem.startPoint.X - tempItem.endPoints.X), Math.Abs(tempItem.startPoint.Y - tempItem.endPoints.Y));
                            AddNameForm.ofItemsToChange.Add(tempItem);
                            tempItem = new Item();
                        }
                    }
                    // In case the user has inputted the wrong text file or they have missing stuff.
                    catch
                    {
                        MessageBox.Show("Falied to load in the UV coordinates. check the txt file and try again.");
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
            // make the delete item buttom invisible, since they are drawing a box, they dont need this.
            btnDeleteItem.Visible = false;

            if (e.Button == MouseButtons.Left)

            {
                lstItems.SelectedIndex = -1;
                rPic1 = e.Location;
                tempItem.startPoint = rPic1;
                rec = new Rectangle(e.X, e.Y, 1, 1);

                CheckBounds(e.Location);

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
                clearEverything();
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
                    myStream.Write(items.ElementAt(i).width.ToString() + " ");
                    myStream.Write(items.ElementAt(i).height.ToString() + " ");
                    startOfFile = false;
                }


                // Code to write the stream goes here. 
                myStream.Close();

            }
        }

        private void btnClearArea_Click(object sender, EventArgs e)
        {
            // clear all the text in every box and clear the draw area.
            clearEverything();
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
                
                    changeInfo("startPoint");
                
            }
        }

        private void txtEndText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //try
                //{
                //    string[] values = txtEndText.Text.Split();

                //    if (Convert.ToInt32(values[0]) < rec.Location.X && Convert.ToInt32(values[1]) < rec.Location.Y)
                //    {
                //        if (Convert.ToInt32(values[0]) < 0 || Convert.ToInt32(values[1]) < 0)
                //        {
                //            throw new widthException("Either the X or Y is less than the picturebox.");
                //        }


                //        int tempInt;
                //        tempInt = rec.Location.X;
                //        rec.Location = new Point(Convert.ToInt32(values[0]), rec.Location.Y);
                //        rec.Width = tempInt - Convert.ToInt32(values[0]);
                //        tempInt = 0;
                //        tempInt = rec.Location.Y;
                //        rec.Location = new Point(rec.Location.X, Convert.ToInt32(values[1]));
                //        rec.Height = tempInt - Convert.ToInt32(values[1]);
                //        txtStartText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString() + " ";
                //        txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();


                //    }
                //    else if (Convert.ToInt32(values[0]) > rec.Location.X && Convert.ToInt32(values[1]) > rec.Location.Y)
                //    {
                //        if (Convert.ToInt32(values[0]) >= pictureBox1.Width || Convert.ToInt32(values[1]) >= pictureBox1.Height)
                //        {
                //            throw new widthException("Either the X or Y is more than the picturebox.");
                //        }

                //        int tempWidith, tempHeight;

                //        tempWidith = Convert.ToInt32(values[0]) - rec.Location.X;
                //        tempHeight = Convert.ToInt32(values[1]) - rec.Location.Y;
                //        rec.Width = tempWidith;
                //        rec.Height = tempHeight;
                //    }
                //    else if(Convert.ToInt32(values[0]) > rec.Location.X && Convert.ToInt32(values[1]) < rec.Location.Y)
                //    {


                //        throw new widthException("awkward. you are not making a rectangle.");
                //    }
                //    else if (Convert.ToInt32(values[0]) < rec.Location.X && Convert.ToInt32(values[1]) > rec.Location.Y)
                //    {
                //        throw new widthException("awkward. you are not making a rectangle.");
                //    }
                //    else
                //    {
                //        throw new widthException("awkward. i dont know what you are doing.");
                //    }



                //}


                //catch (widthException ex)
                //{
                //    MessageBox.Show(ex.Message);
                //    txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();
                //}

                //catch
                //{


                //    MessageBox.Show("Please input valid data for the start box. (Int Int)");
                //    txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();

                //}
                changeInfo("endPoint");
            }
        }

        private void txtStartUV_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtStartUV_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                //try
                //{
                //    string[] values = txtStartUV.Text.Split();

                //    // If the UV inputted is less then 0. thats bad, so dont do it!
                //    if (Convert.ToDouble(values[0]) < 0.00 || Convert.ToDouble(values[1]) < 0.00)
                //    {
                //        throw new widthException("the UV inputted is less then the picturebox.");
                //    }



                //    // if they dont throw the exceptions, we want to caculate our position from the uv's provided.
                //    double startPosX = Convert.ToDouble(values[0]) * pictureBox1.Width;
                //    double startPosY = Convert.ToDouble(values[1]) * pictureBox1.Height;



                //    // If the UV inputted would be greater then the picturebox, then thats also bad!
                //    if (startPosX + rec.Width > pictureBox1.Width || startPosY + rec.Height > pictureBox1.Height)
                //    {
                //        throw new widthException("the UV inputter is greated then the picutrebox.");
                //    }
                //    var tempWidth = Convert.ToInt32(startPosX) + rec.Width;
                //    var tempHeight = Convert.ToInt32(startPosY) + rec.Height;

                //    // and then we want to set the position of the rec to be that of the calculation.

                //    rec.Location = new Point(Convert.ToInt32(startPosX), Convert.ToInt32(startPosY));
                //    //rec.Width = tempWidth;
                //    //rec.Height = tempHeight;


                //    // then we want to update the text fields so that the text reflects the new values.
                //    txtStartText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString();
                //    txtStartUV.Text = Convert.ToDouble(values[0]).ToString("n2") + " " + Convert.ToDouble(values[1]).ToString("n2");
                //    txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();



                //    double endUVX = rec.Location.X + rec.Width;
                //    endUVX = endUVX / pictureBox1.Width;
                //    double endUVY = rec.Location.Y + rec.Height;
                //    endUVY = endUVY / pictureBox1.Height;

                //    txtEndUV.Text = endUVX.ToString("n2") + " " + endUVY.ToString("n2");



                //}
                //catch (widthException ex)
                //{
                //    MessageBox.Show(ex.Message);

                //}
                //catch
                //{

                //}
                changeInfo("startUV");
            }
        }

        private void txtEndUV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //    try
                //    {
                //        string[] values = txtEndUV.Text.Split();
                //        // If the UV inputted is less then 0. thats bad, so dont do it!
                //        if (Convert.ToDouble(values[0]) < (rec.Location.X / pictureBox1.Width)|| Convert.ToDouble(values[1]) < (rec.Location.Y / pictureBox1.Height))
                //        {
                //            throw new widthException("the UV inputted is less then the start point.");
                //        }


                //        double endPosX = convertToUV(Convert.ToInt32(values[0]), pictureBox1.Width);
                //        double endPosY = convertToUV(Convert.ToInt32(values[1]), pictureBox1.Height);
                //        if (endPosX > pictureBox1.Width || endPosY > pictureBox1.Height)
                //        {
                //            throw new widthException("the UV inputted is greater then the picturebox.");
                //        }
                //        rec.Width = Convert.ToInt32(endPosX) - rec.Location.X;
                //        rec.Height = Convert.ToInt32(endPosY) - rec.Location.Y;

                //        // then we want to update the text fields so that the text reflects the new values.
                //        txtStartText.Text = rec.Location.X.ToString() + " " + rec.Location.Y.ToString();

                //        double startuvx, startuvy;

                //        startuvx = convertToUV(rec.Location.X, pictureBox1.Width);
                //        startuvy = convertToUV(rec.Location.Y, pictureBox1.Height);

                //        txtStartText.Text = rec.Location.X + " " + rec.Location.Y;
                //        txtStartUV.Text = startuvx.ToString("n2") + " " + startuvy.ToString("n2");
                //        txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();
                //        txtEndUV.Text = (endPosX / pictureBox1.Width).ToString("n2") + " " + (endPosY / pictureBox1.Height).ToString("n2");
                //        txtWidth.Text = rec.Width.ToString();
                //        txtHeight.Text = rec.Height.ToString();

                //    }
                //    catch (widthException ex)
                //    {
                //        MessageBox.Show(ex.Message);

                //    }
                //    catch
                //    {

                //    }
                //}
                changeInfo("EndUV");
            }
        }

        private void txtWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                //try
                //{

                //    int value = Convert.ToInt32(txtWidth.Text);
                //    // we cant have a width of 0.
                //    if (value < 0)
                //    {
                //        throw new widthException("you cannot have the rectangle be a width of 0.");
                //    }
                //    // we also cant have our width be greater then that of the picturebox.
                //    if (rec.Location.X + value > pictureBox1.Width)
                //    {
                //        throw new widthException("you cannot have the rectangle be a width greater then the picturebox.");
                //    }
                //    rec.Width = value;



                //    double startuvx = Convert.ToDouble(rec.Location.X) / Convert.ToDouble(pictureBox1.Width);
                //    double startuvy = Convert.ToDouble(rec.Location.Y) / Convert.ToDouble(pictureBox1.Height);
                //    txtStartText.Text = rec.Location.X + " " + rec.Location.Y;
                //    txtStartUV.Text = startuvx.ToString("n2") + " " + startuvy.ToString("n2");
                //    txtEndText.Text = (rec.Location.X + rec.Width).ToString() + " " + (rec.Location.Y + rec.Height).ToString();
                //    double endUVx = Convert.ToDouble(rec.Location.X + rec.Width) / Convert.ToDouble(pictureBox1.Width);
                //    double endUVy = Convert.ToDouble(rec.Location.Y + rec.Height) / Convert.ToDouble(pictureBox1.Height);

                //    txtEndUV.Text = endUVx.ToString("n2") + " " + endUVy.ToString("n2");

                //    txtWidth.Text = rec.Width.ToString();
                //    txtHeight.Text = rec.Height.ToString();

                //}
                //catch (widthException ex)
                //{
                //    MessageBox.Show(ex.Message);

                //}
                //catch
                //{
                //}
                changeInfo("width");
            }
        }

        private void txtHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

         
                changeInfo("height");
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
                getSelectedItem();


  

              
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRecName != null)
            {
                addItem();
            }
            clearEverything();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                mouseUpFill();
            }
     
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            pictureBox2.Refresh();
            
        }
    }
}
