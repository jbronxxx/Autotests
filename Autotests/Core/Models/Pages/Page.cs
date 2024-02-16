using OpenQA.Selenium;

namespace Core.Models.Pages {
    public class Page {
		internal string Title { get; set; }

		internal IWebDriver Driver { get; set; }

		internal Page(IWebDriver driver) {
			Driver = driver;
			Title = driver.Title;
		}

		internal void Refresh() {
			Driver.Navigate().Refresh();
		}
	}
}
