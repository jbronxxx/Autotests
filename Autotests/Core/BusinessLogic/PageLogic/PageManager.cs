using Core.Models;
using Core.Models.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.BusinessLogic.PageLogic {
	public static class PageManager {
		public static TPage OpenPage<TPage>(IWebDriver driver) where TPage : Page {
			TPage newPage = CreatePage<TPage>(driver);
			newPage.Driver.Navigate().GoToUrl(driver.Url);
			WaitForPageOpen(newPage.Driver);
			return newPage;
		}

		private static TPage CreatePage<TPage>(IWebDriver driver) where TPage : Page =>
			(TPage)Activator.CreateInstance(typeof(TPage), driver);

		public static WebDriverWait WaitForPageOpen(IWebDriver driver) {
			return new WebDriverWait(driver, TimeSpan.FromSeconds(3));
		}
	}
}