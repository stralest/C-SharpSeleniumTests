using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.pages
{
    public class pageHistory : BaseClass
    {
        public pageHistory(ChromeDriver driver, WebDriverWait wait, Actions actions) : base (driver, wait, actions) { }

        public IWebElement getHistoryTableRow(string orderDiv)
        {
            return driver.FindElement(By.XPath($"//td[contains(., '{orderDiv}')]/parent::tr"));
        }

        public IWebElement getOrderedItemStatus(IWebElement historyTableRow)
        {
            return historyTableRow.FindElement(By.ClassName("status"));
        }
    }
}
