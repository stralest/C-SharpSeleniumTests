namespace TestProject
{
    public class BaseClass {
        
        public ChromeDriver driver;
        //public EdgeDriver driver;
        public WebDriverWait wait;
        public Actions actions;

        public BaseClass(ChromeDriver driver, WebDriverWait wait, Actions actions)
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
        }

        public void goToPage(string Url)
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void assertCurrentUrl(string url)
        {
            driver.Url.Equals(url);
        }

        public void assertCurrentTitle(string title)
        {
            driver.Title.Equals(title); 
        }

        public string getElementText(By locator)
        {
            return driver.FindElement(locator).Text;
        }

        public void clickOnOrderHistoryLink(By locator)
        {
            var historyLink =  driver.FindElement(locator);
            historyLink.Click();
        }
    }
}
