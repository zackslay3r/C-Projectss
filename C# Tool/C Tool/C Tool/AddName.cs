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
    public partial class AddName : Form
    {
        public bool showPlease;
        public string name = "";
        public Form1 parent;
        public string theFileName;
        public string[] file;
        public int counter;
        Item tempItem = new Item();
        public List<Item> ofItemsToChange = new List<Item>();
        public AddName()
        {
            InitializeComponent();
            showPlease = true;
        }

        private void btnNameRegester_Click(object sender, EventArgs e)
        {
            if (counter >= ofItemsToChange.Count)
            {

                //tempItem.name = txtName.Text;
                //parent.items.Add(tempItem);
                //parent.lstItems.Items.Add(tempItem.name);
                this.Hide();
                this.Enabled = false;
                showPlease = false;

            }
            else
            {
                ofItemsToChange.ElementAt(counter).name = txtName.Text;
                parent.items.Add(ofItemsToChange.ElementAt(counter));
                parent.lstItems.Items.Add(ofItemsToChange.ElementAt(counter).name);
                counter++;
                if (counter >= ofItemsToChange.Count)
                {

                    //tempItem.name = txtName.Text;
                    //parent.items.Add(tempItem);
                    //parent.lstItems.Items.Add(tempItem.name);
                    this.Hide();
                    this.Enabled = false;
                    showPlease = false;

                }
            }
        }
    }
}
