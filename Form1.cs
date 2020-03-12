using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunOrange_Gaming_Software
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Console.WriteLine("Entered Form1 constructor");
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Entered textBox1_TextChanged");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Entered label1_Click");
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Entered label10_Click");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var m = (MouseEventArgs)e;
            Console.WriteLine("rebind button 1 pressed");
            Console.WriteLine("x: " + m.X + " y: " + m.Y);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("KeyCode: " + e.KeyCode);
        }
    }
}
