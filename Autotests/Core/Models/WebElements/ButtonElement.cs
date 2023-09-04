using OpenQA.Selenium;

namespace Core.Models.WebElements {
	public class ButtonElement : ElementBase {
		public ButtonElement(IWebDriver driver, IWebElement wrappedElement, By locator) : base(driver, wrappedElement, locator) {
		}

		public string Text => WebElement.Text;

		public void Click() {
			WebElement.Click();
		}
	}
}
