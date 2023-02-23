using OpenQA.Selenium.Remote;

namespace TestProject.pages
{
    public class pageCheckout : BaseClass
    {
        public pageCheckout(ChromeDriver driver, WebDriverWait wait, Actions actions) : base(driver, wait, actions){}

        public IWebElement orderDiv => driver.FindElement(By.CssSelector("h2"));

        public IWebElement getOrderDiv()
        {
            return orderDiv;
        }
    }
}
