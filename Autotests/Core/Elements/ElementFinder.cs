using OpenQA.Selenium;

namespace Core.Elements
{
    public static class ElementFinder
    {
        public static TElement FindElement<TElement>(By by) where TElement : ElementBase
        {
            IWebElement element = DriverBase.GetDriver().FindElement(by);
            ElementBase elementBase = new ElementBase(element, by);
            return (TElement)elementBase;
        }

        public static List<TElement> FindElements<TElement>(By by) where TElement : ElementBase
        {
            IReadOnlyCollection<IWebElement> elements = DriverBase.GetDriver().FindElements(by);
            var elementBases = new List<ElementBase>();
            var tElements = new List<TElement>();
            foreach (IWebElement elementElement in elements)
            {
                elementBases.Add(new ElementBase(elementElement, by));
            }
            foreach (TElement element in elementBases)
            {
                tElements.Add(element);
            }
            return tElements;
        }
    }
}
