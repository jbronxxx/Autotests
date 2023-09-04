using OpenQA.Selenium;

namespace Core.Elements{
    public class ElementBase {
        public By Locator { get; protected set; }

        public IWebElement WeElement { get; private set; }

        public ElementBase(IWebElement webElement, By locator){
            WeElement = webElement;
            Locator = locator;
        }
    }
}
