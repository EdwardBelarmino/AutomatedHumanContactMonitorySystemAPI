using Sharer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AHCMS.App
{
    public partial class Form1 : Form
    {
        private SharerConnection connection = new SharerConnection("COM3", 9600);
        public Form1()
        {
            InitializeComponent();

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!connection.Connected)
            {
                connection.Connect();

                // Scan all functions shared
                connection.RefreshFunctions();

                // remote call function on Arduino and wait for the result
                var value = connection.ReadVariable("average");

                label1.Text = value.Value.ToString();
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Scan all functions shared
            connection.RefreshFunctions();

            // remote call function on Arduino and wait for the result
            var value = connection.ReadVariable("average");

            label1.Text = value.Value.ToString();
            
        }
    }
}
