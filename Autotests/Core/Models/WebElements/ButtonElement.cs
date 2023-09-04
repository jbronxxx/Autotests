using OpenQA.Selenium;

namespace Core.Models.WebElements {
	public class ButtonElement : ElementBase {
		public ButtonElement(IWebElement wrappedElement, By locator) : base(wrappedElement, locator) {
		}

		public string Text => WebElement.Text;

		public void Click() {
			WebElement.Click();
		}
	}
}
