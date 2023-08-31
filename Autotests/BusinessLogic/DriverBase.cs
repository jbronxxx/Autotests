using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace BusinessLogic {
	public class DriverBase {
		public IWebDriver GetDriver() {
			IWebDriver driver = new EdgeDriver();
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Waits.IMPLICIT_WAIT);
			return driver;
		}
	}
}
