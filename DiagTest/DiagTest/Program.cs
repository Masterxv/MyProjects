﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagTest
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AntiDump.Initialize();// CHECK THIS!!!
            AntiDebugging();// CHECK THIS!!!
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        public static async void AntiDebugging()
        {
        reCheck:
            await Task.Delay(2000);
            Scanner.ScanAndKill();
            goto reCheck;
        }
    }
}
