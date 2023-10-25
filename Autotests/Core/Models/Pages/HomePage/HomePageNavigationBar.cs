using Core.BusinessLogic.ElementLogic;
using Core.Models.WebElements;
using OpenQA.Selenium;

namespace Core.Models.Pages.HomePage {
	public class HomePageNavigationBar : ElementBase {
		private IWebDriver _driver;

		public HomePageNavigationBar(IWebDriver driver, IWebElement webElement, By locator) : base(driver, webElement, locator) {
			_driver = driver;
		}

		public string DownloadLinkText => AppDownloadLink.Text;

		public bool IsLogoVisible() => NasiyaLogo.Enabled;

		public void ChangeLanguage(string lang) {
			LanguageSelectDropdown.Click();
			var selectItem = LanguageMenuItems.FirstOrDefault(e => e.Text == lang);
			if(selectItem == null) {
				new NotFoundException("Language is not found");
			}
			selectItem?.Click();
		}

		#region Search elements

		public ReadOnlyElement NasiyaLogo => ElementFinder.FindElement<ReadOnlyElement>(_driver, By.XPath(XPATH_NASIYA_LOGO));

		public DropdownElement LanguageSelectDropdown => ElementFinder.FindElement<DropdownElement>(_driver, By.XPath(XPATH_LANGUAGE_BUTTON));

		public DropdownElement NavigationBarDropdown => ElementFinder.FindElement<DropdownElement>(_driver, By.XPath(XPATH_NAVBAR_DROPDOWN));

		public List<ButtonElement> LanguageMenuItems => ElementFinder.FindElements<ButtonElement>(_driver, By.XPath(XPATH_LANGUAGE_ITEM));

		public ReadOnlyElement AppDownloadLink => ElementFinder.FindElement<ReadOnlyElement>(_driver, By.XPath(XPATH_DOWNLOAD_APP_LINK));

		#endregion

		#region Locators

		private const string XPATH_NASIYA_LOGO = "//div[@class='flex items-center ml-8']//a[@class='router-link-active router-link-exact-active']";
		private const string XPATH_LANGUAGE_BUTTON = "//button[@id='languageDropdownMenuTrigger']";
		private const string XPATH_LANGUAGE_ITEM = "//a[@role='menuitem']";
		private const string XPATH_DOWNLOAD_APP_LINK = "//a[@href='https://nasiya.go.link/?adj_t=14szdiyx']";
		private const string XPATH_NAVBAR_DROPDOWN = "//button[@id='dropdownNavbarTrigger']";

		#endregion
	}
}
