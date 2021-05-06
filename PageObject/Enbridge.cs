using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebdriver.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using UnitKubra.BaseClasses;
using UnitKubra.ComponentHelper;
using UnitKubra.Setting;

namespace UnitKubra.PageObject
{
    
    public class Enbridge : PageBase
    {
   
     

        private IWebDriver driver;
        #region WebElement
        ILog Logger = (ILog)Log4NetHelper.GetXmlLogger(typeof(Enbridge));

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Applications')]")]
        private IWebElement ApplicationsLinkButton;

        [FindsBy(How = How.XPath, Using = "//tbody/tr[3]/td[7]/a[1]")]
      
        private IWebElement AdminConsoleLink;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'User')]")]
        private IWebElement UserLinkInAdminConsole;

      [FindsBy(How = How.CssSelector, Using = "table.FormSize:nth-child(16) table.SearchBoard:nth-child(4) table:nth-child(9) tbody:nth-child(1) tr:nth-child(6) td:nth-child(3) > input.button")]
        private IWebElement SearchButtonInUserLink;

        [Obsolete]
        public Enbridge(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        #endregion

        #region Actions

        public void _ApplicationsLinkButton()
        {

            ApplicationsLinkButton.Click();
            Logger.Info("User clicks the applications link");
        }
        public void _AdminConsoleLink()
        {

            AdminConsoleLink.Click();
            Logger.Info("User clicks the adminconsole link");


        }
        public void _UserLinkInAdminConsole()
        {
            BrowserHelper.SwitchToWindow(1);
            Thread.Sleep(5000);
            UserLinkInAdminConsole.Click();
            Logger.Info("User clicks the User link");

        }
        public void _SearchButtonInUserLink()
        {
         
            SearchButtonInUserLink.Click();
            Logger.Info("User clicks the Search link");

        }
        public void _DatatablePresent()
        {
            if (GenericHelper.IsElemetPresent(By.CssSelector
              ("table.FormSize:nth-child(17) table.SearchBoard:nth-child(4) table:nth-child(4) tbody:nth-child(1) tr.TblDataExpired:nth-child(2) td:nth-child(1) > a:nth-child(1)")))
            {
                Logger.Info("Datatable is present");

            }
            else
            {
                Logger.Error("Datatable is not present");
                GenericHelper.TakeScreenShot();

            }
        }
        public void _CloseAdminConsoleWindow()
        {
            ObjectRepository.driver.Close();
            Logger.Info("Admin Console window is closed");

        }

        #endregion

        #region Navigation

        public void NavigateToBackToEnbridgeApplicationsPage()
        {
            
           
                BrowserHelper.SwitchToWindow(0);
            Logger.Info("User is navigated back to the Applications Page");


        }

        #endregion

    }
}
