using OpenQA.Selenium;

namespace Core.Models.WebElements {
	public class ReadOnlyElement : ElementBase {
		public ReadOnlyElement(IWebDriver driver, IWebElement wrappedElement, By locator) : base(driver, wrappedElement, locator) {
		}

		public string Text => WebElement.Text;

		public bool Enabled => WebElement.Enabled;
	}
}
