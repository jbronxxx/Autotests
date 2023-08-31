using OpenQA.Selenium;

namespace Models.Pages {
	public class HomePage : PageBase {
		private readonly string _url = "https://www.google.com/";

        public HomePage(){
            OpenPage(_url);
        }

		public bool IsLogoVisible() {
			return !_logo.Criteria.Equals(string.Empty);
		}

		#region Locators

		private readonly By _logo = By.XPath("//img[@alt='Google']");

		#endregion
	}
}
