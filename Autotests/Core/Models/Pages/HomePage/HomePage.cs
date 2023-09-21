using Core.BusinessLogic.ElementLogic;
using OpenQA.Selenium;

namespace Core.Models.Pages.HomePage {
	public class HomePage : Page {
		public HomePageNavigationBar NavigationBar => FindNavigationBar;

		public HomePage(string url, IWebDriver driver) : base(url, driver) {
		}

		public bool IsNavBarVisible() => FindNavigationBar.WebElement.Displayed;

		#region Search elements

		private HomePageNavigationBar FindNavigationBar =>
			ElementFinder.FindElement<HomePageNavigationBar>(Driver, By.XPath(XPATH_NAVIGATION_BAR));

		#endregion

		#region Locators

		private const string XPATH_NAVIGATION_BAR = "//nav[@class='z-[1000] fixed w-full backdrop-blur-[22px] top-0 left-0']";

		#endregion
	}
}
