namespace AutomationResources
{
    public class WebDriverFactory
    {
        public ChromeDriver create(BrowserType browserType)
        {
            switch(browserType)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver();
                default: 
                    throw new ArgumentOutOfRangeException("No such browser!");
            }

        }
    }
}