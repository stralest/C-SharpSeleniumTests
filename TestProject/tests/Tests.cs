namespace TestProject
{
    [TestClass]
    [TestCategory("Qa shop tests")]
    public class Tests : BaseTest
    {

        [TestMethod]
        [TestProperty("author", "strahinjaStankovic")]
        [Description("Filling out register form, clickg register button and asserting success register message div")]
        public void TestCase1()
        {
            pageRegister?.goToPage("http://shop.qa.rs/register");
            pageRegister?.assertCurrentUrl("http://shop.qa.rs/register");
            var registerButton = pageRegister?.getRegisterButton();
            Assert.IsTrue(registerButton?.Displayed, "register button should be displayed");

            pageRegister?.getFirstNameField();
            pageRegister?.getLastNameField();
            pageRegister?.getEmailField();
            pageRegister?.getUsernameField();
            pageRegister?.getPasswordField();
            pageRegister?.getPasswordConfirmField();
            registerButton?.Click();

            var successMessage = pageHomepage?.getRegisterSuccessMessageDiv();
            Assert.IsTrue(successMessage.Displayed, "Uspeh! Uspešno ste dodali korisnika message should be displayed");

        }

        [TestMethod]
        [TestProperty("author", "strahinjaStankovic")]
        [Description("Logging in user, adding items to cart - pro pack, 3 items, asserting items and price added to cart")]
        public void TestCase2()
        {
            pageLogin?.goToPage("http://shop.qa.rs/login");
            pageLogin?.assertCurrentUrl("http://shop.qa.rs/login");

            pageLogin?.getKorisnickoImeField();
            pageLogin?.getLozinkaField();
            pageLogin?.clickOnUlogujSeButton();

            var welcomeBack = pageLogin?.getWelcomeBackHeader();
            Assert.IsTrue(welcomeBack?.Displayed);

            string packageToAdd = "small";
            string quantityToAdd = "6";

            var packageDiv = pageHomepage?.getPackageDiv(packageToAdd);
            var packageSelect = pageHomepage?.getPackageSelect(packageDiv);
            var packageOptions = pageHomepage?.getPackageOptions(packageSelect);

            foreach (var option in packageOptions)
            {
                var text = option.Text;

                if (text == quantityToAdd)
                {
                    option.Click();
                }

                //var selectedItem = option?.GetAttribute("value");
                //Assert.AreEqual(selectedItem, quantityToAdd);
            }

            wait.Until(ExpectedConditions.ElementToBeClickable(packageDiv));    
            pageHomepage?.clickOnOrderNow(packageDiv);

            pageHomepage?.assertCurrentUrl("http://shop.qa.rs/order");

            var cartTableRow = pageCart?.getCartTableRow(packageToAdd);

            var itemName = pageCart?.getItemName(cartTableRow).Text;
            Assert.AreEqual(itemName, packageToAdd.ToUpper());

            var itemQunatity = pageCart?.getItemQuantity(cartTableRow).Text;
            Assert.AreEqual(itemQunatity, quantityToAdd);
            
            var itemPricePerItem = pageCart?.getPricePerItem(cartTableRow).Text;

            var itemTotalPrice = pageCart?.getItemTotalPrice(cartTableRow).Text;


            
            Regex digitsOnly = new Regex("[^0-9]");
            

            var quantity = Int32.Parse(itemQunatity);

            var pricePerItem = Int32.Parse(digitsOnly.Replace(itemPricePerItem, ""));
            
            var totalItemPrice = Int32.Parse(digitsOnly.Replace(itemTotalPrice, ""));


            var total = quantity * pricePerItem;
            Assert.AreEqual(total, totalItemPrice);

            pageCart?.clickOnCheckoutButton();
            pageCheckout?.assertCurrentUrl("http://shop.qa.rs/checkout");

            var orderDiv = pageCheckout?.getOrderDiv().Text;
            var orderDivOnlyNumbers = digitsOnly.Replace(orderDiv, "");

            pageCheckout?.clickOnOrderHistoryLink(By.LinkText("Order history"));

            var historyTableRow = pageHistory?.getHistoryTableRow(orderDivOnlyNumbers);
            var orderedItemStatus = pageHistory?.getOrderedItemStatus(historyTableRow).Text;
            Assert.AreEqual(orderedItemStatus, "Ordered");
        }
    }
}