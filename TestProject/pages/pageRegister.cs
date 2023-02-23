using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.pages
{
    public class pageRegister : BaseClass
    {
        public pageRegister(ChromeDriver driver, WebDriverWait wait, Actions actions) : base(driver, wait, actions){ }

        public IWebElement firstNameField => driver.FindElement(By.Name("ime"));

        public IWebElement lastNamefield => driver.FindElement(By.Name("prezime"));

        public IWebElement emailField => driver.FindElement(By.Name("email"));

        public IWebElement usernameField => driver.FindElement(By.Name("korisnicko"));

        public IWebElement passwordField => driver.FindElement(By.Id("password"));

        public IWebElement passwordConfirmField => driver.FindElement(By.Id("passwordAgain"));

        public IWebElement registerButton => driver.FindElement(By.Name("register"));

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void getFirstNameField()
        {
            var firstName = firstNameField;
            firstName.SendKeys(RandomString(8));
        }

        public void getLastNameField()
        {
            var lastName = lastNamefield;
            lastName.SendKeys(RandomString(8));
        }

        public void getEmailField()
        {
            var email = emailField;
            email.SendKeys(RandomString(8) + "@example.local");
        }

        public void getUsernameField()
        {
            var username = usernameField;
            username.SendKeys(RandomString(8));
        }

        public void getPasswordField()
        {
            var password = passwordField;
            password.SendKeys("user123OK!");
        }

        public void getPasswordConfirmField()
        {
            var passwordConfirm = passwordConfirmField;
            passwordConfirm.SendKeys("user123OK!");
        }

        public IWebElement getRegisterButton()
        {
            return registerButton;
        }


    }
}
