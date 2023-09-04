using Core.BusinessLogic.ElementLogic;
using OpenQA.Selenium;

namespace Core.Models.Pages.HomePage {
	public class HomePage : Page {
		public HomePage(string url, IWebDriver driver) : base(url, driver) {
		}

		public string DownloadLinkText => FindNavigationBar.AppDownloadLink.Text;

		public bool IsLogoVisible() => FindNavigationBar.NasiyaLogo.Enabled;

		public void ChangeLanguage(string lang) {
			FindNavigationBar.LanguageSelectButton.Click();
			var selectItem = FindNavigationBar.LanguageMenuItems.FirstOrDefault(e => e.Text == lang);
			if(selectItem == null) {
				new NotFoundException("Language is not found");
			}
			selectItem?.Click();
		}

		public bool IsNavBarVisible => FindNavigationBar.WebElement.Displayed;

		#region Search elements

		private HomePageNavigationBar FindNavigationBar =>
			ElementFinder.FindElement<HomePageNavigationBar>(Driver, By.XPath(NAVIGATION_BAR));

		#endregion

		#region Locators

		private const string NAVIGATION_BAR = "//nav[@class='z-[1000] fixed w-full backdrop-blur-[22px] top-0 left-0']";

		#endregion
	}
}
