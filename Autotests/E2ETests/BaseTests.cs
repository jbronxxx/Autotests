using Core;
using OpenQA.Selenium;

namespace E2ETests.PagesTests {
    public class BaseTests : IDisposable {
        protected IWebDriver Driver;
        private DriverManager Manager;

		[OneTimeSetUp]
		public void Init() {
            Manager = new DriverManager();
		}

		[SetUp]
		public void SetUp() {
            Driver = Manager.GetDriver(TestContext.CurrentContext.Test.Name);
        }

		[TearDown]
		public void Dispose() {
            Manager.DeleteDriver(TestContext.CurrentContext.Test.Name);
		}

        [OneTimeTearDown]
        public void DeleteAllDrivers() {
            Manager.DeleteAllDrivers();
        }
    }
}