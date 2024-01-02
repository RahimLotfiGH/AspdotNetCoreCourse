using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace EX_Asynchronous
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
          await  AddItemsAsync();

        }


        public  async  Task AddItemsAsync()
        {
            
            await Task.Run(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(1000);
                    listBox1.Items.Add(i.ToString());
                }
            });

        }
    }
}
