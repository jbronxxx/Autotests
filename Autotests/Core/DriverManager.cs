using Core.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Core {
	public class DriverManager {
		private int _driversMaxCount = 20;
		private List<KeyValuePair<string, IWebDriver>> _driversPool = new ();

		public IWebDriver GetDriver(string? id = null) {
			if(_driversPool.Count >= _driversMaxCount) {
				throw new Exception("Maximum drivers count");
			}
			if(_driversPool.Count == 0 && id != null) {
				IWebDriver driver = CreateNewDriver();
				_driversPool.Add(new KeyValuePair<string, IWebDriver>(id, driver));
				return driver;
			}
			return GetExistingDriverFromPool();
		}

		public void DeleteDriver(string id) {
			if(_driversPool.Count == 0) {
				throw new Exception("Drivers pool is empty");
			}
			string idToDelete = _driversPool.FirstOrDefault(i => i.Key == id).Key;
			IWebDriver driverToDelete = _driversPool.FirstOrDefault(d => d.Key == id).Value;
			var itemToDelete = new KeyValuePair<string, IWebDriver>(idToDelete, driverToDelete);
			_driversPool.Remove(itemToDelete);
			driverToDelete.Close();
			driverToDelete.Dispose();
		}

		private IWebDriver CreateNewDriver() {
			IWebDriver newDriver = new EdgeDriver();
			newDriver.Manage().Window.Maximize();
			newDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Waits.IMPLICIT_WAIT);
			return newDriver;
		}

		private IWebDriver GetExistingDriverFromPool() {
			IWebDriver existingDriver = _driversPool.FirstOrDefault(d => d.Value != null).Value;
			return existingDriver;
		}
	}
}
