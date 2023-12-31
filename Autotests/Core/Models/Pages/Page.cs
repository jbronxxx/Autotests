﻿using OpenQA.Selenium;

namespace Core.Models.Pages {
	public class Page {
		public string Title { get; set; }

		public string Url { get; set; }

		public IWebDriver Driver { get; set; }

		public Page(string url, IWebDriver driver) {
			Driver = driver;
			Title = driver.Title;
			Url = url;
		}

		public void ClosePage() {
			Driver.Close();
			Driver.Quit();
			Driver.Dispose();
		}

		public void Refresh() {
			Driver.Navigate().Refresh();
		}
	}
}
