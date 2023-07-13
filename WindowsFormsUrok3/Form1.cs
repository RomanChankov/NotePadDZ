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

namespace WindowsFormsUrok3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.PerformStep();
                label1.Text = "Value = " +
                progressBar1.Value.ToString();
                this.Update(); Thread.Sleep(50);
            }

        }
    }
}
