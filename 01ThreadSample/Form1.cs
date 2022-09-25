using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01ThreadSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread mythread = new Thread(Count);
            mythread.Start();
            Thread yourthread = new Thread(Count);
            yourthread.Start();
        }

        private void Count()
        {
            string lck = "lock";

            for (int i = 0; i < 100; i++)
            {
                lock (lck)
                {
                    listBox1.Invoke((Action)(() => listBox1.Items.Insert(0, i.ToString())));
                }
                
                Thread.Sleep(100);
            }
 
        }
    }
}
