using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;

namespace Calculator
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

            // Устанавливаем американскую культуру, чтобы десятичные дроби разделялись точками
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); 

            Application.Run(new Form1());
        }
    }
}
