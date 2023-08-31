﻿using BusinessLogic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Models.Pages {
	public class PageBase {
		private readonly IWebDriver _driver = new DriverBase().GetDriver();

        public void OpenPage(string url){
           _driver.Navigate().GoToUrl(url);
           WaitForPageOpen();
		}

        public void ClosePage() {
            _driver.Close();
            _driver.Quit();
        }

        public void RefreshPage() {
            _driver.Navigate().Refresh();
			WaitForPageOpen();
		}

        public WebDriverWait WaitForPageOpen() {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(Waits.EXPLICIT_WAIT));
        }
    }
}
