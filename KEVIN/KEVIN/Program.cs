using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KEVIN
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public string albumInfo;
        [STAThread]        
        static void Main()
        {           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmKEVINMain());
        }
        public void albumIDLookUp(string temp)
        {
            albumInfo = temp;
        }
    }
}
