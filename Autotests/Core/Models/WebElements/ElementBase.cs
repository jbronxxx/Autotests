﻿using OpenQA.Selenium;

namespace Core.Models.WebElements {
	public class ElementBase {
		public IWebDriver Driver { get; set; }

		public By Locator { get; }

		public IWebElement WebElement { get; }

		public ElementBase(IWebDriver driver, IWebElement webElement, By locator) {
			Driver = driver;
			WebElement = webElement;
			Locator = locator;
		}
	}
}
