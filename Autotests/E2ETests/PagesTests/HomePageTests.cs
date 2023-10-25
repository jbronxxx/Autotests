using Core.BusinessLogic.PageLogic;
using Core.Models.Pages.HomePage;
using Core.Models.Urls;

namespace E2ETests.PagesTests {
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class HomePageTests : BaseTests {
        [Test]
        public void HomePageOpens() {
            HomePage homePage = PageManager.OpenPage<HomePage>(Urls.HOME_PAGE_URL, Driver);
            Assert.That(homePage.NavigationBar.IsLogoVisible(), Is.True, "Logo is not found");
        }

        [Test]
        public void HomePageNavigationBarIsVisible() {
            HomePage homePage = PageManager.OpenPage<HomePage>(Urls.HOME_PAGE_URL, Driver);
            Assert.That(homePage.IsNavBarVisible(), Is.True, "Navigation bar is not found");
        }

        [Test]
        public void ChangeHomePageLanguage() {
            var linkText = "Скачать приложение";
            HomePage homePage = PageManager.OpenPage<HomePage>(Urls.HOME_PAGE_URL, Driver);
            homePage.NavigationBar.ChangeLanguage("RU");
            Assert.That(homePage.NavigationBar.DownloadLinkText, Is.EqualTo(linkText), "Link's text is not expected");
        }
    }
}