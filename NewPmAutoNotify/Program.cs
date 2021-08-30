using NewPmAutoNotify.StepObjects;
using NSelene;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System.Windows.Forms;

namespace NewPmAutoNotify
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 4)
                return;
            var username = args[0];
            var password = args[1];
            var projectName = args[2];
            bool headless = bool.Parse(args[3]);

            try
            {
                SetUp(headless);
                AutoNotify(username, password, projectName);
                Console.Clear();
                Console.WriteLine("Task completed successfully");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                MessageBox.Show($"Task was not successful, please do it by hand. Error message: {e.Message}");
            }
            finally
            {
                TearDown();
            }

        }
        public static void AutoNotify(string username, string password, string projectName)
        {
            NewPmSteps.Open(username, password)
                   .ClickTemporarelyOccupied()
                   .SelectProject(projectName)
                   .ClickSend()
                   .AssertActionWasSuccessful();
        }
        public static void SetUp(bool headless)
        {
            string chromeVersion = "Latest";
            new DriverManager().SetUpDriver(new ChromeConfig(), version: chromeVersion);
            var chromeOptions = new ChromeOptions();
            if(headless)
            {
                chromeOptions.AddArguments("headless");
            }
            Configuration.Driver = new ChromeDriver(chromeOptions);
            Configuration.WaitForNoOverlapFoundByJs = true;
        }
        public static void TearDown()
        {
            Configuration.Driver.Dispose();
        }
    }
}
