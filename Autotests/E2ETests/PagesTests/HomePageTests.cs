using Core;
using Core.BusinessLogic.PageLogic;
using Core.Models.Pages.HomePage;
using Core.Models.Urls;

namespace E2ETests.PagesTests {
	[TestFixture]
	[Parallelizable(ParallelScope.All)]
	public class HomePageTests {
		HomePage _homePage;
		[SetUp]
		public void Setup() {
			_homePage = PageManager.OpenPage<HomePage>(Urls.HOME_PAGE_URL, DriverBase.GetDriver());
		}

		[Test]
		public void HomePageOpens() {
			Assert.That(_homePage.NavigationBar.IsLogoVisible(), Is.True, "Logo is not found");
		}

		[Test]
		public void HomePageNavigationBarIsVisible() {
			Assert.That(_homePage.IsNavBarVisible(), Is.True, "Navigation bar is not found");
		}

		[Test]
		public void ChangeHomePageLanguage() {
			var linkText = "Скачать приложение";
			_homePage.NavigationBar.ChangeLanguage("RU");
			Assert.That(_homePage.NavigationBar.DownloadLinkText, Is.EqualTo(linkText), "Link's text is not expected");
		}

		[TearDown]
		public void TearDown() {
			_homePage.ClosePage();
		}
	}
}