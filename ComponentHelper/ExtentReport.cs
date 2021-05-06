using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWebdriver.ComponentHelper;
using System;
using System.IO;

namespace UnitKubra.ComponentHelper
{
    [TestClass]
    public class ExtentReport
    {
        [Obsolete]
        ILog Logger = (ILog)Log4NetHelper.GetXmlLogger(typeof(ExtentReport));
        private static ExtentReports ReportManager { get; set; }
        private static string ApplicationDebuggingFolder => @"C:\Users\prade\source\repos\UnitKubra\Results";

        private static string HtmlReportFullPath { get; set; }

        public static string LatestResultsReportFolder { get; set; }

        private static TestContext MyTestContext { get; set; }

        private static ExtentTest CurrentTestCase { get; set; }

        private static bool IsExtenetReportStarted = false;
       [TestMethod]
        [Obsolete]
        public  void StartReporter()
        {
            Logger.Info("Starting a one time setup for the entire" +
                            " .CreatingReports namespace." +
                            "Going to initialize the reporter next...");
            CreateReportDirectory();
            var htmlReporter = new ExtentHtmlReporter(HtmlReportFullPath);
            ReportManager = new ExtentReports();
            ReportManager.AttachReporter(htmlReporter);
        }
        [TestInitialize]
        [Obsolete]
        private  void CreateReportDirectory()
        {
            var filePath = Path.GetFullPath(ApplicationDebuggingFolder);
            LatestResultsReportFolder = Path.Combine(filePath, DateTime.Now.ToString("MMdd_HHmm"));
            Directory.CreateDirectory(LatestResultsReportFolder);

            HtmlReportFullPath = $"{LatestResultsReportFolder}\\TestResults.html";
            Logger.Info("Full path of HTML report=>" + HtmlReportFullPath);
        }
        [TestMethod]
        public  void AddTestCaseMetadataToHtmlReport(TestContext testContext)
        {
            MyTestContext = testContext;
            CurrentTestCase = ReportManager.CreateTest(MyTestContext.TestName);
        }
        [TestMethod]
        [Obsolete]
        public  void LogPassingTestStepToBugLogger(string message)
        {
            Logger.Info(message);
            CurrentTestCase.Log(Status.Pass, message);
        }
        [TestMethod]
        [Obsolete]
        public  void ReportTestOutcome(string screenshotPath)
        {
            var status = MyTestContext.CurrentTestOutcome;

            switch (status)
            {
                case UnitTestOutcome.Failed:
                    Logger.Error($"Test Failed=>{MyTestContext.FullyQualifiedTestClassName}");
                    CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    CurrentTestCase.Fail("Fail");
                    break;
                case UnitTestOutcome.Inconclusive:
                    CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    CurrentTestCase.Warning("Inconclusive");
                    break;
                case UnitTestOutcome.Unknown:
                    CurrentTestCase.Skip("Test skipped");
                    break;
                default:
                    CurrentTestCase.Pass("Pass");
                    break;
            }

            ReportManager.Flush();
        }
        [TestMethod]
        [Obsolete]
        public  void LogTestStepForBugLogger(Status status, string message)
        {
            Logger.Info(message);
            CurrentTestCase.Log(status, message);
        }
[TestMethod]
        [Obsolete]
        public  void GetReportManager()
        {
            if (!IsExtenetReportStarted)
            {
                IsExtenetReportStarted = true;
                StartReporter();
            }
        }
    }
}

