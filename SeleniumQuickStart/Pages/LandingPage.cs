using System.Linq;
using OpenQA.Selenium;

namespace SeleniumQuickStart.Pages
{
    public class LandingPage
    {
        readonly IWebDriver _driver;
        public LandingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Logo => _driver.FindElements(By.XPath("//a[@class='header__logo']"))?.FirstOrDefault();
        public IWebElement RegionBlock => _driver.FindElements(By.CssSelector("span .header__top-description-region"))?.FirstOrDefault();
        public IWebElement RegionSelector =>
            _driver.FindElements(By.XPath("//form[@class='geo' and contains(normalize-space(),'Ваш регион доставки')]"))?.FirstOrDefault();

        public IWebElement PlaceAutoDetector =>
            _driver.FindElements(
                    By.XPath("//form[@class='geo']//descendant::span[normalize-space()='Определить автоматически']"))
                ?.FirstOrDefault();
        public IWebElement PlaceField =>
            _driver.FindElements(By.XPath("//form[@class='geo']//descendant::input[contains(@class,'text-field')]"))
                ?.FirstOrDefault();
        public IWebElement SaveLocationButton => _driver.FindElements(By.XPath(
            "//form[@class='geo']//descendant::button[contains(@class,'geo__button-save') and normalize-space()='Запомнить выбор']"))?.FirstOrDefault();
        public IWebElement Questioner => _driver.FindElements(By.ClassName("basewebquestioner__modal"))?.FirstOrDefault();

        public void Goto()
        {
            _driver.Navigate().GoToUrl("https://lamoda.ru");
        }
    }
}
