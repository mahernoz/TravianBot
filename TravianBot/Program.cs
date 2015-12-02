//--------------------------------------------------------
// <copyright file="Program.cs" company="company">
//        Copyright (c) company. All rights reserved.
// </copyright>
// <author>Muhammed Emir Özçevik</author>
//--------------------------------------------------------

using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using TravianBot.UI;

namespace TravianBot
{
    /// <summary>
    ///     Main program.
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Gets main form.
        /// </summary>
        public static Main MainForm { get; private set; }

        [STAThread]
        private static void Main(string[] args)
        {
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new Main();
            Thread formThread = new Thread(() =>
            {
                Application.Run(MainForm);
            });
            formThread.Name = "UI Thread";
            formThread.Start();

            Run();
        }

        private static void Run()
        {
            // TODO:Fix this.
            TravianBot.Parsing.Parser.SetRegex("Parsing/regex.txt");

            var sv1 = Travian.Instance.CreateServer(
                "http://www.bizimtravian.com",
                "s1",
                100000,
                "1. server");

            var a1 = sv1.AccountManager.CreateAccount(
                "Kahval",
                "25252525");

            var tc = sv1.ClientManager.CreateTravianClient(
                a1,
                sv1.Address);

            Travian.Instance.AI.Run();
            Console.ReadLine();
        }
    }
}