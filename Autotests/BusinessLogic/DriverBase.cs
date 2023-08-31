using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace BusinessLogic {
	public class DriverBase {
		private IWebDriver? _driver;

		public IWebDriver GetDriver() {
			if (_driver == null) {
				new NotFoundException("Driver is not found");
			}
			_driver = new EdgeDriver();
			_driver.Manage().Window.Maximize();
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Waits.IMPLICIT_WAIT);
			return _driver;
		}
	}
}
