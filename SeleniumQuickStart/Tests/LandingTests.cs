using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumQuickStart.Pages;

namespace SeleniumQuickStart
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class LandingTests
    {
        IWebDriver _driver;
        LandingPage _landing;
        WebDriverWait _wait;

        [SetUp]
        public void Initialise()
        {
            _driver = new ChromeDriver();//C:\tools\selenium
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _landing = new LandingPage(_driver);
        }

        [TearDown]
        public void DisposeEnvironment()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void SearchForSomething()
        {
            _landing.Goto();
            Assert.IsNotNull(_landing.Questioner);
        }

        [Test]
        public void GeopositionSelectionCheck()
        {
            _landing.Goto();
            _wait.Until(x => _landing.RegionBlock.Displayed);
            _landing.RegionBlock.Click();
            _wait.Until(x => _landing.RegionSelector.Displayed && _landing.PlaceAutoDetector.Displayed);
            _landing.PlaceAutoDetector.Click();
            Assert.AreEqual("г. Москва", _landing.PlaceField.GetAttribute("value"));
            _landing.SaveLocationButton.Click();
            Assert.That(!_landing.RegionSelector.Displayed);
        }
    }
}
