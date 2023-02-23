using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.pages
{
    public class pageLogin : BaseClass
    {
        public pageLogin(ChromeDriver driver, WebDriverWait wait, Actions actions) : base(driver, wait, actions) { }

        public IWebElement korisnickoImeField => driver.FindElement(By.Name("username"));

        public IWebElement lozinkaField => driver.FindElement(By.Name("password"));

        public IWebElement ulogujSeButton => driver.FindElement(By.Name("login"));

        public IWebElement welcomeBackHeader => driver.FindElement(By.CssSelector("h2"));

        public void getKorisnickoImeField()
        {
            var korisnickoIme = korisnickoImeField;
            korisnickoIme.SendKeys("aaa");
        }

        public void getLozinkaField()
        {
            var lozinka = lozinkaField;
            lozinka.SendKeys("aaa");
        }

        public void clickOnUlogujSeButton()
        {
            var ulogujSe = ulogujSeButton;
            ulogujSe.Click();
        }

        public IWebElement getWelcomeBackHeader()
        {
           return welcomeBackHeader;
        }
    }
}
