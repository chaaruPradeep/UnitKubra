using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using UnitKubra.Setting;

namespace UnitKubra.ComponentHelper
{
    public class GenericHelper
    {

        
  
  
        public static bool IsElemetPresent(By Locator)
        {
            try
            {
                return ObjectRepository.driver.FindElements(Locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static IWebElement GetElement(By Locator)
        {
            if (IsElemetPresent(Locator))
                return ObjectRepository.driver.FindElement(Locator);
            else
                throw new NoSuchElementException("Element Not Found : " + Locator.ToString());
        }

        public static void TakeScreenShot(string filename = "Screen")
        {
            Screenshot screen = ObjectRepository.driver.TakeScreenshot();
            if (filename.Equals("Screen"))
            {
                filename = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
                screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
                return;
            }
            screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
        }

        public static bool WaitForWebElement(By locator, TimeSpan timeout)
        {
             ObjectRepository.driver.Manage().Timeouts().ImplicitWait=(TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            bool flag = wait.Until(WaitForWebElementFunc(locator));
            ObjectRepository.driver.Manage().Timeouts().ImplicitWait=(TimeSpan.FromSeconds(ObjectRepository.config.GetElementLoadTimeOut()));
            return flag;
        }

        public static IWebElement WaitForWebElementInPage(By locator, TimeSpan timeout)
        {
            ObjectRepository.driver.Manage().Timeouts().ImplicitWait=(TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            IWebElement flag = wait.Until(WaitForWebElementInPageFunc(locator));
            ObjectRepository.driver.Manage().Timeouts().ImplicitWait=(TimeSpan.FromSeconds(ObjectRepository.config.GetElementLoadTimeOut()));
            return flag;
        }

        private static Func<IWebDriver, bool> WaitForWebElementFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return true;
                return false;
            });
        }

        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;
            });
        }
    }
}
