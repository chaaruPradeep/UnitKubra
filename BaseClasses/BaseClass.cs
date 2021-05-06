using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using UnitKubra.ComponentHelper;
using UnitKubra.Configuration;
using UnitKubra.CustomException;
using UnitKubra.Setting;

namespace UnitKubra.BaseClasses
{
   [TestClass]

    public class BaseClass

    {
        private static FirefoxProfile GetFirefoxProfile()
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            profile = manager.GetProfile("chaaru1001");
            return profile;
        }
        //public static FirefoxOptions GetFirefoxOptions()
        //{
        //    FirefoxOptions firefoxOptions = new FirefoxOptions();
        //    firefoxOptions.Profile = GetFirefoxProfile();
        //    firefoxOptions.AcceptInsecureCertificates = true;
        //    return firefoxOptions;
        //}
      
        private static IWebDriver GetFirefoxDriver()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.Profile = GetFirefoxProfile();
            IWebDriver driver = new FirefoxDriver("C:\\", firefoxOptions);
            return driver;
        }
        private static IWebDriver GetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--user-data-dir=C:\\Users\\prade\\AppData\\Local\\Google\\Chrome\\User Data\\");
            IWebDriver driver = new ChromeDriver("C:\\", options);
            //WebDriver driver = new ChromeDriver();
            return driver;
        }
        //private static IWebDriver GetIExplorerDriver()
        //{
        //    IWebDriver driver = new InternetExplorerDriver();
        //    return driver;
        //}
        [AssemblyInitialize]
        public static void InitWebdriver(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext tc)
        {
            


            ObjectRepository.config = new AppConfigReader();
            switch (ObjectRepository.config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.driver = GetFirefoxDriver();
                    break;
                case BrowserType.Chrome:
                    ObjectRepository.driver = GetChromeDriver();
                    break;
                //case BrowserType.IExplorer:
                //    ObjectRepository.driver = GetIExplorerDriver();
                //    break;
                default:
                    throw new NoSuitableDriverFound("Driver Not Found : " + ObjectRepository.config.GetBrowser().ToString());
            }
            //NavigationHelper.NavigateToUrl(ObjectRepository.config.GetWebsite());
            //ObjectRepository.driver.Manage()
            //    .Timeouts()
            //    .SetPageLoadTimeout=(TimeSpan.FromSeconds(ObjectRepository.config.GetPageLoadTimeOut()));
            ObjectRepository.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.config.GetElementLoadTimeOut());

                    ObjectRepository.driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(ObjectRepository.config.GetElementLoadTimeOut()));
         
        }
      

        [AssemblyCleanup]
        public static void TearDown()
        {
if(ObjectRepository.driver != null)
            {
        
                ObjectRepository.driver.Close();
                ObjectRepository.driver.Quit();
            }
        }
    }
}
