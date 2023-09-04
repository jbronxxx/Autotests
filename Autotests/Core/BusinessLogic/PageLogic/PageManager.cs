using Core.Models;
using Core.Models.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.BusinessLogic.PageLogic
{
    public static class PageManager
    {
        public static T OpenPage<T>(string url, IWebDriver driver) where T : Page
        {
            T newPage = CreatePage<T>(url, driver);
            newPage.Driver.Navigate().GoToUrl(newPage.Url);
            WaitForPageOpen(newPage.Driver);
            return newPage;
        }

        private static T CreatePage<T>(string url, IWebDriver driver) where T : Page
        {
            var page = Activator.CreateInstance(typeof(T), url, driver);
            return (T)page;
        }

        public static WebDriverWait WaitForPageOpen(IWebDriver driver)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(Waits.EXPLICIT_WAIT));
        }
    }
}
