using OpenQA.Selenium;

namespace Models.Pages.HomePage
{
    public class HomePage : PageBase
    {
        private readonly string _url = "https://uzumnasiya.uz/";

        public HomePage()
        {
            OpenPage(_url);
        }

        public bool IsLogoVisible()
        {
            return _nasiyaLogo.Enabled;
        }

        public void ChangeLanguage(string lang)
        {
            _languageSelectButton.Click();
            var selectItem = _languageMenuItem.FirstOrDefault(e => e.Text == lang);

            if (selectItem == null)
            {
                new NotFoundException("Language is not found");
            }
            selectItem?.Click();
        }

        public string DownloadLinkText()
        {
            return _downloadAppLink.Text;
        }

        #region Locators

        private IWebElement _nasiyaLogo => FindElement(By.XPath("//div[@class='flex items-center ml-8']//a[@class='router-link-active router-link-exact-active']"));

        private IWebElement _languageSelectButton => FindElement(By.XPath("//button[@id='languageDropdownMenuTrigger']"));

        private List<IWebElement> _languageMenuItem => FindElements(By.XPath("//a[@role='menuitem']"));

        private IWebElement _downloadAppLink => FindElement(By.XPath("//a[@href='https://onelink.to/awxvfn']"));

        #endregion
    }
}
