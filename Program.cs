using System;
using System.Windows.Forms;

namespace PFCB
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        /// unjywk79kclwtndin8wop22alec7me ACCESS TOKEN
        /// 0wp27fuyq545irkzgglp36q5wqm7npipshvhhmu32ttg9bmk3a REFRESH TOKEN


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
