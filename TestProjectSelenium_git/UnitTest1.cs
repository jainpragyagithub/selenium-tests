
  
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace Test_Selenium_c_
    {
    [TestFixture]
    public class GoogleSearchTestOnChrome
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--start-maximized");

            // Launch Firefox
            driver = new FirefoxDriver(options);
            /*ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            // Launch Chrome
            driver = new ChromeDriver("C://Users//PragyaJain//Downloads//new//chromedriver-win64//chromedriver-win64//chromedriver.exe", options);
*/
            // Navigate to Google
            driver.Navigate().GoToUrl("http://www.google.com");
        }

        [Test]
        public void TestGoogleSearch()
        {
            // Find the text input element by its name
            IWebElement element = driver.FindElement(By.Name("q"));

            // Enter something to search for
            element.SendKeys("Selenium testing tools cookbook");

            // Now submit the form. WebDriver will find
            // the form for us from the element
            element.Submit();

            // Google's search is rendered dynamically with JavaScript.
            // Wait for the page to load, timeout after 10 seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.ToLower().StartsWith("selenium testing tools cookbook"));

            Assert.AreEqual("Selenium testing tools cookbook - Google Search", driver.Title);
            Thread.Sleep(2000);
        }

        [TearDown]
        public void TearDown()
        {
            // Close the browser
            driver.Quit();
        }
    }
}

