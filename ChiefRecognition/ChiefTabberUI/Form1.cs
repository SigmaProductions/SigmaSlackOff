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
                if (this.CheckboxPlayKeyboardSound.Checked)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resources.keyboard);
                    player.Play();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
