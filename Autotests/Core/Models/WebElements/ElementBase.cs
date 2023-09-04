using OpenQA.Selenium;

namespace Core.Models.WebElements {
	public class ElementBase {
		public By Locator { get; set; }

		public IWebElement WebElement { get; set; }

		public ElementBase(IWebElement webElement, By locator) {
			WebElement = webElement;
			Locator = locator;
		}
	}
}
