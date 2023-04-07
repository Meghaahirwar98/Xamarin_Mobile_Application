using EmployeeAllowanceApp.Model;
using EmployeeAllowanceApp.Service;
using EmployeeAllowanceApp.View_Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllowanceAppUnitTest.Tests
{
    public class AllowanceServiceTest
    {
        public static AllowanceViewModel ViewModel { get; private set; }


        [SetUp]
        public void Setup()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            ViewModel = new AllowanceViewModel();
        }

        #region Get all allowance List
        [Test]
        public void GetAllowanceList_MatchCount_Test()
        {
            //Arrange
            var Service = new AllowanceService();
            int expectedAllowanceCount = 5;

            //Action
            var allowancName = Service.AllowanceNameList();
            var ServiceResult = allowancName as List<AllowanceModel>;
            int ActualResultAllowanceCount = ServiceResult.Count;

            //Assert
            Assert.AreEqual(expectedAllowanceCount, ActualResultAllowanceCount);
        }

        [Test]
        public void AllowanceList_MisMatchCount_Test()
        {
            //Arrange          
            var Service = new AllowanceService();
            int expectedAllowanceCount = 6;

            //Action
            var allowancName = Service.AllowanceNameList();
            var ServiceResult = allowancName as List<AllowanceModel>;
            int ActualResultAllowanceCount = ServiceResult.Count;

            //Assert
            Assert.AreEqual(expectedAllowanceCount, ActualResultAllowanceCount);
        }
        #endregion

        #region Get all today date attendance
        [Test]
        public void GetAllTodayAttendance_MatchCount_Test()
        {
            //Arrange
            var ServiceName = new AllowanceService();
            int expectedPresentEmployeeCount = 0;


            //Action
            var allowancName = ServiceName.PresentEmployeeDetails();
            var ServiceResult = allowancName as List<PresentEmployee>;
            var ActualPresentEmployeeCount = ServiceResult.Count;


            //Assert
            Assert.AreEqual(expectedPresentEmployeeCount, ActualPresentEmployeeCount);
        }

        [Test]
        public void GetAllTodayAttendance_MisMatchCount_Test()
        {
            //Arrange
            var ServiceName = new AllowanceService();
            int expectedPresentEmployeeCount = 1;


            //Action
            var allowancName = ServiceName.PresentEmployeeDetails();
            var ServiceResult = allowancName as List<PresentEmployee>;
            var ActualPresentEmployeeCount = ServiceResult.Count;


            //Assert
            Assert.AreEqual(expectedPresentEmployeeCount, ActualPresentEmployeeCount);
        }
        #endregion

        #region Post allowance data
        [Test]
        public void PostAllowance_Test()
        {
            //Arrenge
            var ObjAllowance = new PostAllowance();
            ObjAllowance.EmployeeKey = 12;
            ObjAllowance.allowanceAmount = 111;
            ObjAllowance.allowanceId = 1;
            ObjAllowance.clockDate = DateTime.Now.Date;

            //Action
            List<PostAllowance> ListAllowance = new List<PostAllowance>();
            var ServiceName = new AllowanceService();
            ListAllowance.Add(ObjAllowance);
           bool result = ServiceName.postAllowance(ListAllowance);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void PostAllowance_InvalidEmployeeKey_Test()
        {
            //Arrenge
            var ObjAllowance = new PostAllowance();
            ObjAllowance.EmployeeKey = 10;
            ObjAllowance.allowanceAmount = 111;
            ObjAllowance.allowanceId = 1;
            ObjAllowance.clockDate = DateTime.Now.Date;

            //Action
            List<PostAllowance> ListAllowance = new List<PostAllowance>();
            var ServiceName = new AllowanceService();
            ListAllowance.Add(ObjAllowance);
            bool result = ServiceName.postAllowance(ListAllowance);

            //Assert
            Assert.IsFalse(result);
        }
        #endregion
    }
}


