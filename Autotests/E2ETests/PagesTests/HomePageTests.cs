using Core;
using Core.Models.Pages;
using Models.Pages.HomePage;
using Models.Urls;

namespace E2ETests.PagesTests
{
    [TestFixture]
    public class HomePageTests{
        HomePage _homePage;
        [SetUp]
        public void Setup(){
			_homePage = PageBase.OpenPage<HomePage>(Urls.HOME_PAGE_URL, DriverBase.GetDriver());
		}

        [Test]
        public void HomePageOpens() {
            Assert.That(_homePage.IsLogoVisible(), Is.True, "Logo is not found");
        }

        [Test]
        public void ChangeHomePageLanguage(){
            var linkText = "Скачать приложение";
            _homePage.ChangeLanguage("RU");
            Assert.That(_homePage.DownloadLinkText, Is.EqualTo(linkText), "Link's text is not expected");
        }

        [TearDown]
        public void TearDown(){
            _homePage.ClosePage();
        }
    }
}