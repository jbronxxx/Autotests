using Models.Pages.HomePage;

namespace E2ETests
{
    [TestFixture]
	public class HomePageTests {
		private HomePage _homePage;

		[SetUp]
		public void Setup() {
			_homePage = new HomePage();
		}

		[Test]
		public void HomePageOpens() {
			_homePage.RefreshPage();
			Assert.That(_homePage.IsLogoVisible, Is.True, "Logo is not found");
		}

		[Test]
		public void ChangeHomePageLanguage() {
			var linkText = "Скачать приложение";
			_homePage.ChangeLanguage("RU");
			Assert.That(_homePage.DownloadLinkText, Is.EqualTo(linkText), "Link's text is not expected");
		}

		[TearDown]
		public void TearDown() {
			_homePage.ClosePage();
		}
	}
}