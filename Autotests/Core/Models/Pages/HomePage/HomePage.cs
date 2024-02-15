using Core.BusinessLogic.ElementLogic;
using OpenQA.Selenium;

namespace Core.Models.Pages.HomePage {
	public class HomePage : Page {
        private const string URL = "https://uzumnasiya.uz/";

        public static string Url { get { return URL; } }

		public HomePageNavigationBar NavigationBar => FindNavigationBar;

		public HomePage(IWebDriver driver) : base(driver) {
			driver.Url = Url;
		}

		public bool IsNavBarVisible() => FindNavigationBar.WebElement.Displayed;

		#region Search elements

		private HomePageNavigationBar FindNavigationBar =>
			ElementFinder.FindElement<HomePageNavigationBar>(Driver, By.XPath(XPATH_NAVIGATION_BAR));

		#endregion

		#region Locators

		private const string XPATH_NAVIGATION_BAR = "//div[@class='u-container flex items-center justify-between']";

		#endregion
	}
}
