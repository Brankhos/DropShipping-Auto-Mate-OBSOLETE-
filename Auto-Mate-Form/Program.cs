using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Drawing;
using System.Text;
using HtmlAgilityPack;
using IronXL;
using System.Net;
using System.Net.Http.Headers;
using System.IO;
using System.Collections;

namespace Auto_Mate_Form
{
    public class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            
        }

        


    }

}
