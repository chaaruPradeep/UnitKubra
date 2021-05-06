using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitKubra.Configuration;

namespace UnitKubra.Interfaces
{
  public  interface IConfig
    {
        BrowserType? GetBrowser();
        int GetPageLoadTimeOut();
        int GetElementLoadTimeOut();
        string GetWebsite();
    }
}
