using Core.Models.WebElements;
using OpenQA.Selenium;

namespace Core.BusinessLogic.ElementLogic {
    public static class ElementFinder {
		//Create a check if element exist class
		public static TElement FindElement<TElement>(IWebDriver driver, By by) where TElement : ElementBase {
			IWebElement foundElement;
            try {
                foundElement = driver.FindElement(by);
            } catch(Exception) {
				throw new NotFoundException("Element is not found");
			}
            return CreateFromElement<TElement>(foundElement, by, driver);

        }

		public static List<TElement> FindElements<TElement>(IWebDriver driver, By by) where TElement : ElementBase {
			IReadOnlyCollection<IWebElement> foundElements;
            try {
                foundElements = driver.FindElements(by);
            } catch(Exception) {
                throw new NotFoundException("Elements are not found");
            }
			return CreateFromElements<TElement>(foundElements, by, driver);
		}

		private static TElement CreateFromElement<TElement>(IWebElement foundElement, By by, IWebDriver driver) where TElement : ElementBase =>
			(TElement)Activator.CreateInstance(typeof(TElement), driver, foundElement, by);


		private static List<TElement> CreateFromElements<TElement>(IReadOnlyCollection<IWebElement> foundElements,
			By by,
			IWebDriver driver) where TElement : ElementBase {
			var resultList = new List<TElement>();
			foreach(IWebElement foundElement in foundElements) {
				resultList.Add((TElement)Activator.CreateInstance(typeof(TElement), driver, foundElement, by));
			}
			return resultList;
        }
	}
}
