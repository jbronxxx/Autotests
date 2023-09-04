using OpenQA.Selenium;

namespace Core.Models.WebElements {
	public class ReadOnlyElement : ElementBase {
		public ReadOnlyElement(IWebElement wrappedElement, By locator) : base(wrappedElement, locator) {
		}

		public string Text => WebElement.Text;

		public bool Enabled => WebElement.Enabled;
	}
}
