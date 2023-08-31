using Models.Pages;

namespace E2ETests {
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

		[TearDown]
		public void TearDown() {
			_homePage.ClosePage();
		}
	}
}