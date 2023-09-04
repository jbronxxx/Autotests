using OpenQA.Selenium;

namespace Core.Models.WebElements {
	public class DropdownElement : ElementBase {
		public DropdownElement(IWebDriver driver, IWebElement wrappedElement, By locator) : base(driver, wrappedElement, locator) {
		}

		public string Text => WebElement.Text;

		public void Click() {
			WebElement.Click();
		}
	}
}
