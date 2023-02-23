using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.pages
{
    public class pageCart : BaseClass
    {
       public pageCart(ChromeDriver driver, WebDriverWait wait, Actions actions) : base(driver, wait, actions) { }

        public IWebElement checkoutButton => driver.FindElement(By.Name("checkout"));

        public IWebElement getCartTableRow(string packageToAdd) 
        {
           return driver.FindElement(By.XPath($"//td[contains(., '{packageToAdd.ToUpper()}')]/ancestor::tr"));
        }

        public IWebElement getItemName(IWebElement tableRow)
        {
            return tableRow.FindElement(By.XPath("td[1]"));
        }
        
        public IWebElement getItemQuantity(IWebElement tableRow) 
        {
            return tableRow.FindElement(By.XPath("td[2]"));
        }

        public IWebElement getPricePerItem(IWebElement tableRow)
        {
            return tableRow.FindElement(By.XPath("td[3]"));
        }

        public IWebElement getItemTotalPrice(IWebElement tableRow)
        {
            return tableRow.FindElement(By.XPath("td[4]"));
        }

        public void clickOnCheckoutButton()
        {
            var checkoutBtn = checkoutButton;
            checkoutBtn.Click();
        }
    }
}
