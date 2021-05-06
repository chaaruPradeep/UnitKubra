using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitKubra.Setting;

namespace UnitKubra.ComponentHelper
{
    public class NavigationHelper
    {
        public static void NavigateToUrl(string Url)
        {
            ObjectRepository.driver.Navigate().GoToUrl(Url);
        }
    }
}
