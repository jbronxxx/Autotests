using Core.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core {
	public class DriverManager {
		private readonly int _driversMaxCount = 20;
		private readonly List<KeyValuePair<string, IWebDriver>> _driversPool = new ();

		public IWebDriver GetDriver(string? id = null) {
			if(_driversPool.Count >= _driversMaxCount) {
				throw new Exception("Maximum drivers count is reached");
			}
			if(_driversPool.Count == 0) {
				IWebDriver driver = CreateNewDriver();
				_driversPool.Add(new KeyValuePair<string, IWebDriver>(id, driver));
				return driver;
			}
            return GetExistingDriverFromPool(id);
        }

        private IWebDriver GetExistingDriverFromPool(string? id) {
            IWebDriver existingDriver = _driversPool.FirstOrDefault(d => d.Key == id).Value;
            return existingDriver;
        }

        //TODO: Create different types of webfriver according to settings
        private IWebDriver CreateNewDriver() {
			IWebDriver newDriver = new ChromeDriver();
			newDriver.Manage().Window.Maximize();
			newDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Waits.IMPLICIT_WAIT);
			return newDriver;
		}

        public void DeleteDriver(string id) {
            if(_driversPool.Count != 0) {
                IWebDriver driverToDelete = _driversPool.FirstOrDefault(d => d.Key == id).Value;
                _driversPool.Remove(_driversPool.FirstOrDefault(i => i.Key == id));
                driverToDelete.Quit();
                driverToDelete.Dispose();
            } else {
                throw new Exception("Drivers pool is empty");
            }
        }

        public void DeleteAllDrivers() {
            if(_driversPool.Count != 0) {
                foreach(KeyValuePair<string, IWebDriver> driver in _driversPool) {
                    _driversPool.Remove(driver);
                }
            } else {
                throw new Exception("Drivers pool is empty");
            }
        }
    }
}
