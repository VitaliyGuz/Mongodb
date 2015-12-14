using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class 1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://chnv2dev.ntracts.net/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void The1Test()
        {
            driver.Navigate().GoToUrl(baseURL + "/#");
            driver.FindElement(By.CssSelector("#ui-id-27 > div")).Click();
            driver.FindElement(By.Name("Group_74617")).Click();
            driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Click();
            driver.FindElement(By.CssSelector("#ui-id-32 > div")).Click();
            driver.FindElement(By.CssSelector("div.ui-dialog-buttonset > button.btn.btn-success")).Click();
            new SelectElement(driver.FindElement(By.Name("ko_unique_7"))).SelectByText("Anesthesiology");
            new SelectElement(driver.FindElement(By.Name("ko_unique_9"))).SelectByText("0.9");
            driver.FindElement(By.XPath("(//input[@name='Group_74623'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@name='Group_74629'])[3]")).Click();
            driver.FindElement(By.XPath("(//input[@name='Group_74637'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@name='Group_74640'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@name='Group_74642'])[2]")).Click();
            new SelectElement(driver.FindElement(By.Name("ko_unique_38"))).SelectByText("Guarantee with additional productivity to Compensation Model");
            new SelectElement(driver.FindElement(By.Name("ko_unique_45"))).SelectByText("three (3)");
            driver.FindElement(By.Id("dp1449162428513")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'3')])[2]")).Click();
            driver.FindElement(By.Name("ko_unique_46")).Clear();
            driver.FindElement(By.Name("ko_unique_46")).SendKeys("Adress1");
            driver.FindElement(By.XPath("(//button[@type='button'])[11]")).Click();
            driver.FindElement(By.CssSelector("#ui-id-37 > div")).Click();
            driver.FindElement(By.CssSelector("div.ui-dialog-buttonset > button.btn.btn-success")).Click();
            driver.FindElement(By.XPath("(//button[@type='button'])[2]")).Click();
            Assert.AreEqual("Please complete required questions and correct any incorrectly formatted answers.", CloseAlertAndGetItsText());
            driver.FindElement(By.XPath("(//button[@type='button'])[8]")).Click();
            driver.FindElement(By.CssSelector("div.ui-dialog-buttonset > button.btn.btn-success")).Click();
            driver.FindElement(By.XPath("(//button[@type='button'])[2]")).Click();
            Assert.AreEqual("Please complete required questions and correct any incorrectly formatted answers.", CloseAlertAndGetItsText());
            driver.FindElement(By.Name("Group_74629")).Click();
            driver.FindElement(By.XPath("(//input[@name='Group_74632'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@name='Group_74629'])[3]")).Click();
            driver.FindElement(By.XPath("(//button[@type='button'])[2]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
