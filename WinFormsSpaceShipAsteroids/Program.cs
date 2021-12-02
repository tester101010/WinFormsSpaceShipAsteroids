using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsSpaceShipAsteroids
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
            Form form = new Form
            {
                Width = 1280,
                Height = 720
            };

            //{
            //    Width = Screen.PrimaryScreen.Bounds.Width, ?????????????????????
            //    Height = Screen.PrimaryScreen.Bounds.Height  ???????????????????
            //};
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(new Form());
            //Application.Run(new Form1());
        }
    }
}
