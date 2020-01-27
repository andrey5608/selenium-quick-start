using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumQuickStart.Pages;
using TechTalk.SpecFlow;

namespace SeleniumQuickStart
{
    [Binding]
    public class TestSteps
    {
        IWebDriver _driver;
        LandingPage _landing;
        WebDriverWait _wait;
        
        public TestSteps()
        {
            _driver = new ChromeDriver(@"C:\ProgramData\chocolatey\lib\chromedriver\tools");
            //TODO: register iwebdriver in featurecontext
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _landing = new LandingPage(_driver);
        }

        [AfterScenario]
        public void DisposeEnvironment()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Given(@"I am on lamoda website")]
        [When(@"I go to lamoda website")]
        public void GivenIAmOnLamodaWebsite()
        {
            _landing.Goto();
        }

        [When(@"I select region block")]
        public void WhenISelectRegionBlock()
        {
            _wait.Until(x => _landing.RegionBlock.Displayed);
            _landing.RegionBlock.Click();
        }

        [When(@"save autodetected place")]
        public void WhenSaveAutodetectedPlace()
        {
            _wait.Until(x => _landing.RegionSelector.Displayed && _landing.PlaceAutoDetector.Displayed);
            _landing.PlaceAutoDetector.Click();
            _landing.SaveLocationButton.Click();
        }

        [When(@"click on autodetect button")]
        public void WhenClickOnAutodetectButton()
        {
            _wait.Until(x => _landing.RegionSelector.Displayed && _landing.PlaceAutoDetector.Displayed);
            _landing.PlaceAutoDetector.Click();
        }

        [Then(@"it was detected place '(.*)'")]
        public void ThenItWasDetectedPlace(string expectedText)
        {
            Assert.AreEqual(expectedText, _landing.PlaceField.GetAttribute("value"));
        }

        [Then(@"region selector was closed")]
        public void ThenRegionBlockWasClosed()
        {
            _wait.Message = "Region selector was not closed.";
            _wait.Until(x => !_landing.RegionSelector.Displayed);
            _wait.Message = string.Empty;
        }

        [Then(@"questioner icon is showing on the page")]
        public void ThenQuestionerIsShowingOnThePage()
        {
            _landing.Goto();
            _wait.Message = "Questioner icon is not displayed.";
            _wait.Until(x => _landing.QuestionerIcon != null &&
            _landing.QuestionerIcon.Displayed);
            _wait.Message = string.Empty;
        }
    }
}
