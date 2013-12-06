using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace GraphicConstructor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //System.Windows.Forms.MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory);
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + ex.StackTrace);
            }
        }
    }
}
