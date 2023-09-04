using Core.Elements;
using OpenQA.Selenium;

namespace Models.Pages.HomePage
{
    public class HomePageNavigationBar : ElementBase {
		public HomePageNavigationBar(IWebElement webElement, By locator) : base(webElement, locator) {
		}
		
		#region Search elements

		public ReadOnlyElement NasiyaLogo => ElementFinder.FindElement<ReadOnlyElement>(By.XPath(NASIYA_LOGO));

		public DropdownElement LanguageSelectButton => ElementFinder.FindElement<DropdownElement>(By.XPath(LANGUAGE_BUTTON));

		public List<ButtonElement> LanguageMenuItems => ElementFinder.FindElements<ButtonElement>(By.XPath(LANGUAGE_ITEM));

		public ReadOnlyElement AppDownloadLink => ElementFinder.FindElement<ReadOnlyElement>(By.XPath(DOWNLOAD_APP_LINK));

		#endregion

		#region Locators

		private const string NASIYA_LOGO = "//div[@class='flex items-center ml-8']//a[@class='router-link-active router-link-exact-active']";
		private const string LANGUAGE_BUTTON = "//button[@id='languageDropdownMenuTrigger']";
		private const string LANGUAGE_ITEM = "//a[@role='menuitem']";
		private const string DOWNLOAD_APP_LINK = "//a[@href='https://onelink.to/awxvfn']";

		#endregion
	}
}
