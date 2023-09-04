using OpenQA.Selenium;

namespace Core.Models.WebElements {
	public class DropdownElement : ElementBase {
		public DropdownElement(IWebElement wrappedElement, By locator) : base(wrappedElement, locator) {
		}

		public string Text => WebElement.Text;

		public void Click() {
			WebElement.Click();
		}
	}
}
