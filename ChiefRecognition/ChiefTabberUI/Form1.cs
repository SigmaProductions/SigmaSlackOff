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
using OpenQA.Selenium.Remote;
using System.Diagnostics;

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
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        async Task MakeCommit()
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
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.Verb = "runas";
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/K cd  ..\\..\\..\\..\\..\\..\\..\\MakeCommits && git add * && git commit -m \"" + line.Trim() + "\" && git push";
            process.StartInfo = startInfo;
            process.Start();
            await Task.Delay(5000);
            process.Kill();
        }
        public Form1()
        {
            InitializeComponent();
            this.hubConnection = new HubConnectionBuilder()
                .WithUrl("http://07b9f0d5.ngrok.io/homehub")
                .Build();
           this.hubConnection.On("HideWindows", () =>
            {
                IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
                SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL, IntPtr.Zero);
                async Task MakeCommits()
                {

                    while (true)
                    {
                        try
                        {
                            await MakeCommit();
                            await Task.Delay(55000);
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
                if (this.CheckboxProgram.Checked)
                {
                    Process.Start(openFileDialog1.FileName);
                }
                var options = new ChromeOptions();
                options.AddExcludedArgument("enable-automation");
                options.AddAdditionalCapability("useAutomationExtension", false);
                options.AddArgument("--kiosk");
                var i = 1;
                    switch (i)
                    {
                        case 1:
                        if (this.CheckboxHackerTyper.Checked)
                        {
                           using (var driver = new FirefoxDriver()) { HackerTyper(driver); };
                        }
                        if (this.CheckboxStockMarket.Checked)
                        {
                            using (var driver = new FirefoxDriver()) { OpenWebsite(driver, "https://money.cnn.com/data/markets/"); };
                        }
                        break;
                        case 2:
                        if (this.CheckboxHackerTyper.Checked)
                        {
                            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) { HackerTyper(driver); };
                        }
                        if (this.CheckboxStockMarket.Checked)
                        {
                            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) { OpenWebsite(driver, "https://money.cnn.com/data/markets/"); };
                        }
                        break;
                    }
            });
        }
    public void HackerTyper(RemoteWebDriver driver)
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
    public void OpenWebsite(RemoteWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            Actions actiddon = new Actions(driver);
            actiddon.SendKeys("{F11}");
            actiddon.Perform();
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

        private void ButtonCommit_Click_1(object sender, EventArgs e)
        {
            MakeCommit();
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string browsefilename = openFileDialog1.FileName;
            }
        }
    }
}
