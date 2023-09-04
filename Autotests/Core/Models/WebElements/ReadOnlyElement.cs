using OpenQA.Selenium;

namespace Core.Models.WebElements
{
    public class ReadOnlyElement : ElementBase
    {
        public ReadOnlyElement(IWebElement wrappedElement, By locator) : base(wrappedElement, locator)
        {
        }

        public string Text => WeElement.Text;

        public bool Enabled => WeElement.Enabled;
    }
}
