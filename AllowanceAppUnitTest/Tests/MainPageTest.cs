using EmployeeAllowanceApp;
using EmployeeAllowanceApp.Model;
using EmployeeAllowanceApp.View_Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Mocks;

namespace AllowanceAppUnitTest.Tests
{
    [TestFixture]
    public class MainPageTest
    {
        public static AllowanceViewModel ViewModel { get; private set; }

        public static App App { get; set; }

        [SetUp]
        public void Setup()
        {
            MockForms.Init();
            App = new App();
            ViewModel = new AllowanceViewModel();
        }

        #region App is running or not
        [Test]
        public static void IsAppRunningTest()
        {
            Assert.NotNull(App);
        }
        #endregion

        #region Navigation main page to allowance page
        [Test]
        public async Task NavigationFromMainPage_ToAllowancePage_Test()
        {
            //Arrange
            var mainPage = new MainPage();
            var allowancePage = new AllowancePage();

            //Actiron
            await mainPage.Navigation.PushAsync(allowancePage);

            //Assert
            Assert.AreEqual(mainPage.Navigation.NavigationStack.Last(), allowancePage);
        }
        #endregion

        #region DoneButton_Execution_Test
        [Test]
        public void DoneButtonClick_Test()
        {
            var addAllowancePage = new AllowanceViewModel();
            addAllowancePage.SaveCommand.ChangeCanExecute();

        }
        #endregion

        #region Navigation from main page to last(addAllowance) page
        [Test]
        public async Task NavigationFromMainPage_ToAddAllowance_Test()
        {
            //Arrange
            var mainPage = new MainPage();
            var allowancePage = new AllowancePage();
            var addAllowancePage = new AddAllowances();

            //Action
            await mainPage.Navigation.PushAsync(allowancePage);
            await allowancePage.Navigation.PushAsync(addAllowancePage);

            //Assert
            Assert.AreEqual(allowancePage.Navigation.NavigationStack.Last(), addAllowancePage);
        }
        #endregion

        #region AllowanceNameListTest in stacklayout
        [Test]
        public void AllowanceNameList_InStackLayout_Test()
        {
            //Arrange
            var viewModel = new AllowanceViewModel();
            int ExpectedAllowanceCount = 5;

            //Action)
            var AllowanceName = viewModel.AllowanceNameList;
            List<AllowanceModel> AllowanceCount = AllowanceName as List<AllowanceModel>;
            int ActualAllowanceCount = AllowanceCount.Count;

            //Assert
            Assert.AreEqual(ExpectedAllowanceCount, ActualAllowanceCount);
        }
        #endregion

        #region PresentEmployeeList in Listview
        [Test]
        public void PresentEmployeeListInListViewTest()
        {
            //Arrange
            var viewModel = new AllowanceViewModel();
            int ExpectedEmployeeCount = 0;

            //Action)
            var PresentEmployee = viewModel.PresentEmployeeList;
            List<PresentEmployee> EmployeeCount = PresentEmployee as List<PresentEmployee>;
            int ActualEmployeeCount = EmployeeCount.Count;

            //Assert
            Assert.AreEqual(ExpectedEmployeeCount, ActualEmployeeCount);
        }
        #endregion

        #region ReverseNavigationTest

        [Test]
        public async Task ReverseNavigation_fromAllowancePage_ToMainPage_Test()
        {
            //Arrange
            var mainPage = new MainPage();
            var allowancePage = new AllowancePage(); 
            
            //Action
            await mainPage.Navigation.PushAsync(allowancePage);
            await allowancePage.Navigation.PushAsync(mainPage);

            //Assert
            Assert.AreEqual(allowancePage.Navigation.NavigationStack.Last(), mainPage);
        }
        #endregion

        #region TitleTest_onTheMainPage
        [Test]
        public void MainPageTitleTest()
        {
            //Arrange
            var title = new MainPage();
            var ExpectedTitle = "ALLOWANCE APP LOGIN";

            //Action
            var ExactTitle = title.Text;

            //Assert
            Assert.AreEqual(ExpectedTitle, ExactTitle);
        }
        #endregion




        //[Test]
        //public void LoginButtonClickTest()
        //{
        //    var mainPage = new MainPage();
        //    mainPage. .ChangeCanExecute();
        //}
    }
}




