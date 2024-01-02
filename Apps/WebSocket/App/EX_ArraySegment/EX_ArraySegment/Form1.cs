using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EX_ArraySegment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

          

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int[] Myarray = new int[] { 1,2,6,7,8,10};
            ArraySegment<int> AS = new ArraySegment<int>(
                array: Myarray,                
                offset: 1,
                count: 3);

            foreach(int i in AS)
            {
                MessageBox.Show(i.ToString());
            }

        }
    }
}
