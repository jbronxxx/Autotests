using Core.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Core {
	public static class DriverBase {
		public static IWebDriver GetDriver() {
			IWebDriver driver = new EdgeDriver();
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Waits.IMPLICIT_WAIT);
			return driver;
		}
	}
}
