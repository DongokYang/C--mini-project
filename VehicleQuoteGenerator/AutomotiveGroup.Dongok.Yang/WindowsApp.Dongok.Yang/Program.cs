/*
 * Name: Dongok Yang
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2024-01-21
 * Updated: 2024-03-19
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApp.Dongok.Yang
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new QuoteForm());
        }
    }
}
