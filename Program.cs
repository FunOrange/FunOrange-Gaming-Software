using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunOrange_Gaming_Software
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // github commit test
            Console.WriteLine("just before Application.Run(new Form1())");
            Application.Run(new Form1());
            Console.WriteLine("just after Application.Run(new Form1())");
        }
    }
}
