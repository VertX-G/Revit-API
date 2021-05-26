using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //string fullstring;
        //Char Character = 'A';

        int i = 1;
        string message;

        //int count = 1;
        //string[] array = new string[26];
        //char arrayset = 'A';

         int x = 1;

         static string[] MakeArray(int size)
         {
             string[] outVal = new string[size];
             for (int i = 0; i < size; i++)
             {
                 outVal[i] = new string((char)('A' + (i % 26)), (i / 26) + 1);
             }
             return outVal;
         }
         
       

        private void click(object sender, EventArgs e)
        {

            int i = 201;

            string message = new string ((char)('A' + (i % 26)), (i / 26) + 1);
            MessageBox.Show(message);
          
           

        }




        private void load(object sender, EventArgs e)
        {

        }

        private void SelectOnClick(object sender, EventArgs eventArgs)
        {
            System.Threading.SynchronizationContext.Current.Post((state) => { ((System.Windows.Forms.TextBox)sender).SelectAll(); }, null);
            //((System.Windows.Forms.TextBox)sender).SelectAll();
            //textBox.Focus();

            // Kick off SelectAll asyncronously so that it occurs after Click
            //BeginInvoke((Action)((System.Windows.Forms.TextBox)sender).SelectAll);
        }

    }
}
