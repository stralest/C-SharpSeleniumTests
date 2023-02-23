namespace TestProject
{
    public class BaseTest
    {
        public ChromeDriver ?driver;
        //public EdgeDriver? driver;
        public WebDriverWait ?wait;
        public Actions ?actions;
        public pageRegister? pageRegister;
        public pageHomepage? pageHomepage;
        public pageLogin? pageLogin;
        public pageCart? pageCart;
        public pageCheckout? pageCheckout;
        public pageHistory? pageHistory;


        [TestInitialize]

        public void setUpBeforeEveryTest()
        {
            driver = new WebDriverFactory().create(BrowserType.Chrome);
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
            actions = new Actions(driver);
            driver.Manage().Window.Maximize();
            pageRegister = new pageRegister(driver, wait, actions);
            pageHomepage = new pageHomepage(driver, wait, actions);
            pageLogin = new pageLogin(driver, wait, actions);
            pageCart = new pageCart(driver, wait, actions);
            pageCheckout = new pageCheckout(driver, wait, actions);
            pageHistory = new pageHistory(driver, wait, actions);   

        }

        [TestCleanup]

        public void cleanUpAfterEeryTest()
        {
            driver?.Quit();
        }
    }
}
