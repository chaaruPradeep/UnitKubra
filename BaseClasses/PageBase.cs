using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitKubra.ComponentHelper;
using UnitKubra.Setting;

namespace UnitKubra.BaseClasses
{
    public class PageBase
    {
        private IWebDriver driver;

        [FindsBy(How = How.LinkText, Using = "Home")]
        private IWebElement HomeLink;

        [Obsolete]
        public PageBase(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            this.driver = _driver;
        }

        public void Logout()
        {
            //if (GenericHelper.IsElemetPresent(By.CssSelector
            //    ("table.FormSize:nth-child(16) table.SearchBoard:nth-child(4) table:nth-child(4) tbody:nth-child(1) tr.TblDataExpired:nth-child(2) td:nth-child(1) > a:nth-child(1)")));
            //{
            //    ObjectRepository.driver.Close();
            //    BrowserHelper.SwitchToWindow(0);
            //}
           // GenericHelper.WaitForWebElementInPage(By.Id("welcome"), TimeSpan.FromSeconds(30));

        }

        protected void NaviGateToHomePage()
        {
            //HomeLink.Click();
        }

        public string Title
        {
            get { return driver.Title; }
        }
    }
}
