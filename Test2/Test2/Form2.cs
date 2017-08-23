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
    public partial class Form2 : Form
    {
       public bool showPlease;
       public string name = "";
       public Form1 parent;
        public string theFileName;
        public Form2()
        {
            InitializeComponent();
            showPlease = true;

        }

      
        private void btnName_Click(object sender, EventArgs e)
        {
            Item tempItem = new Item();


                    //tempItem.name = newMDIChild.name;
                    string[] file = File.ReadAllLines(theFileName);
                    //int[] positions = new int[file.Length];
                    //double[] uvs = new double[file.Length];

                    for (int i = 0; i <= file.Length; i++)
                    {

                        foreach (var item in file)
                        {

                            // This splits the values up
                            string[] values = item.Split();
                    tempItem.startPoint = (new Point(Convert.ToInt32(values[0]), Convert.ToInt32(values[1])));
                    tempItem.endPoints = (new Point(Convert.ToInt32(values[2]), Convert.ToInt32(values[3])));
                    tempItem.startUVpoint = (new PointD(Convert.ToDouble(values[4]), Convert.ToDouble(values[5])));
                    tempItem.endUVpoint = (new PointD(Convert.ToDouble(values[6]), Convert.ToDouble(values[7])));
                    parent.counter++;

                        }



                    //}
                    //}

                //}
                }

            tempItem.name = txtName.Text;
            parent.items.Add(tempItem);
            parent.lstItems.Items.Add(tempItem.name);

            this.Close();
            this.Enabled = false;
            showPlease = false;
           
        }
    }
}
