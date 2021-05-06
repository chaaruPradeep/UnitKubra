using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using ExcelDataReader.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWebdriver.ComponentHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitKubra.ComponentHelper;
using UnitKubra.ExcelReader;
using UnitKubra.PageObject;
using UnitKubra.Setting;

namespace UnitKubra.TestScript.PageObject
{


    
    [TestClass]
    
    public class EnbridgePageObject
    {
        
      
        [TestMethod, TestCategory("Smoke")]
        [Obsolete]
        public void TestPage()
        {
            
            string xlPath = @"C:\Users\prade\source\repos\UnitKubra\ExcelReader\kubra.xlsx";
            NavigationHelper.NavigateToUrl((string)ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 1, 0));
            Enbridge enbridge = new Enbridge(ObjectRepository.driver);
           
          
            enbridge._ApplicationsLinkButton();
            enbridge._AdminConsoleLink();
            enbridge._UserLinkInAdminConsole();
            enbridge._SearchButtonInUserLink();
            enbridge._DatatablePresent();
            enbridge._CloseAdminConsoleWindow();
            enbridge.NavigateToBackToEnbridgeApplicationsPage();
          
        }



    }
}
