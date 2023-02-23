using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.pages
{
    public class pageHomepage : BaseClass
    {

        public pageHomepage(ChromeDriver driver, WebDriverWait wait, Actions actions) : base(driver, wait, actions) { }

        public IWebElement successMessageDiv => driver.FindElement(By.XPath("//div[@class='alert alert-success']"));

        public IWebElement getRegisterSuccessMessageDiv()
        {
            return successMessageDiv;
        }

        public IWebElement getPackageDiv(string packageToAdd)
        {
            string xpath = $"//h3[contains(text(), '{packageToAdd}')]/ancestor::div[contains(@class, 'panel')]";
            return driver.FindElement(By.XPath(xpath));
        }

        public IWebElement getPackageSelect(IWebElement packageDiv)
        {
            return packageDiv.FindElement(By.Name("quantity"));
        }

        public IList<IWebElement> getPackageOptions(IWebElement packageSelect)
        {
            return packageSelect.FindElements(By.CssSelector("option"));
        }

        public void clickOnOrderNow(IWebElement packageDiv) 
        {
            string xpath = "descendant::input[@class='btn btn-primary']";
            var orderNowButton = packageDiv.FindElement(By.XPath(xpath));
            orderNowButton.Click();
        }


    }
}
