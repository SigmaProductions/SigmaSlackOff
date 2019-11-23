using Microsoft.AspNetCore.SignalR.Client;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using ChiefTabberUI.Properties;

namespace ChiefTabberUI
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        const int WM_COMMAND = 0x111;
        const int MIN_ALL = 419;
        private HubConnection hubConnection;
        public Form1()
        {
            InitializeComponent();
            this.hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44354/homehub")
                .Build();
           this.hubConnection.On("HideWindows", () =>
            {
                IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
                SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL, IntPtr.Zero);
                async Task MakeCommits()
                {

                    while (true)
                    {
                        var lines = File.ReadAllLines("..\\..\\..\\..\\..\\..\\..\\MakeCommits\\commit_messages.txt");
                        var r = new Random();
                        var randomLineNumber = r.Next(0, lines.Length - 1);
                        var line = lines[randomLineNumber];
                        var currentPath = Directory.GetCurrentDirectory();
                        using (var file = new StreamWriter("..\\..\\..\\..\\..\\..\\..\\MakeCommits\\commits.txt", true))
                        {
                            file.WriteLine(line);
                        }

                        try
                        {
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo.Verb = "runas";
                            startInfo.FileName = "cmd.exe";
                            startInfo.Arguments = "/K cd  ..\\..\\..\\..\\..\\..\\..\\MakeCommits && git add * && git commit -m \"" + line.Trim() + "\" && git push";
                            process.StartInfo = startInfo;
                            process.Start();
                            

                            await Task.Delay(60000);
                            process.Kill();
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    } 
                }
                if (this.CheckboxCommit.Checked)
                {
                    MakeCommits();
                }
                if (this.CheckboxPlayKeyboardSound.Checked)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resources.keyboard);
                    player.PlayLooping();
                }
                if (this.CheckboxHackerTyper.Checked) { 
                var options = new ChromeOptions();
                options.AddExcludedArgument("enable-automation");
                options.AddAdditionalCapability("useAutomationExtension", false);
                options.AddArgument("--kiosk");
                using (var driver = new FirefoxDriver())
                {
                    driver.Navigate().GoToUrl("http://hackertyper.com");
                    var console = driver.FindElementById("console");
                    console.Click();
                    Actions actiddon = new Actions(driver);
                    actiddon.SendKeys("{F11}");
                    actiddon.Perform();
                    while (true)
                    {
                        try
                        {
                            Actions action = new Actions(driver);
                            action.SendKeys("d");
                            action.Perform();
                        }
                        catch (Exception)
                        {
                            break;
                        }
                       
                    }
                }
                }  //Thread.Sleep(1);
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await this.hubConnection.StartAsync();

            }).GetAwaiter().GetResult();
        }
        private void ButtonCommit_Click(object sender,EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
