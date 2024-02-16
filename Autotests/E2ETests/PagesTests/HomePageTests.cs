using Core.BusinessLogic.PageLogic;
using Core.Models.Pages.HomePage;

namespace E2ETests.PagesTests {
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class HomePageTests : BaseTests {
        [Test]
        public void HomePageOpens() {
            Assert.That(OpenHomePage().NavigationBar.IsLogoVisible(), Is.True, "Logo is not found");
        }

        [Test]
        public void HomePageNavigationBarIsVisible() {
            Assert.That(OpenHomePage().IsNavBarVisible(), Is.True, "Navigation bar is not found");
        }

        [Test]
        public void ChangeHomePageLanguage() {
            var linkText = "Скачать приложение";
            HomePage homePage = OpenHomePage();
            homePage.NavigationBar.ChangeLanguage("RU");
            Assert.That(homePage.NavigationBar.DownloadLinkText, Is.EqualTo(linkText), "Link's text is not expected");
        }

        private HomePage OpenHomePage() {
            return PageManager.OpenPage<HomePage>(Driver);
        }
    }
}