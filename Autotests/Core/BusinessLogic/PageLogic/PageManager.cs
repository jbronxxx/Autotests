using Core.Models;
using Core.Models.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.BusinessLogic.PageLogic {
	public static class PageManager {
		public static TPage OpenPage<TPage>(string url, IWebDriver driver) where TPage : Page {
			TPage newPage = CreatePage<TPage>(url, driver);
			newPage.Driver.Navigate().GoToUrl(newPage.Url);
			WaitForPageOpen(newPage.Driver);
			return newPage;
		}

		private static TPage CreatePage<TPage>(string url, IWebDriver driver) where TPage : Page =>
			(TPage)Activator.CreateInstance(typeof(TPage), url, driver);

		public static WebDriverWait WaitForPageOpen(IWebDriver driver) {
			return new WebDriverWait(driver, TimeSpan.FromSeconds(Waits.EXPLICIT_WAIT));
		}
	}
}