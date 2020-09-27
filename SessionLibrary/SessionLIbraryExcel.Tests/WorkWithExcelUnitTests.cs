using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SessionLibrary.Excel.DataClasses;
using SessionLibrary.Excel.Enums;
using SessionLibrary.Excel.Models;

namespace SessionLIbraryExcel.Tests
{
    [TestClass]
    public class WorkWithExcelUnitTests
    {
        /// <summary>
        /// Connection string
        /// </summary>
        string connectionString = @"Data Source = DESKTOP-7D5VMQO\SQLEXPRESS;Initial Catalog = SessionLibrary_7; Integrated Security = True;";
        /// <summary>
        /// Checing excle worker write students results method
        /// </summary>
        [TestMethod]
        public void ExcelWriteSessionResults()
        {
            //arrange
            SessionResultGetter getter = new SessionResultGetter(connectionString);
            List<GroupResult> results = getter.GetSessionResult(1).ToList<GroupResult>();
            //act
            bool flag = ExcelWorker.Write(@"SessionResults.xlsx",results);
            //assert
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void ExcelWriteSessionResultsWithSortingByDateAscending()
        {
            //arrange
            SessionResultGetter getter = new SessionResultGetter(connectionString);
            List<GroupResult> results = getter.GetSessionResult(1,(i) => i.StudentName,SortType.Ascending).ToList<GroupResult>();
            //act
            bool flag = ExcelWorker.Write(@"SessionResultsWithSorting.xlsx", results);
            //assert
            Assert.IsTrue(flag);
        }
        /// <summary>
        /// Checing excle worker write group with them average, minimum and maximum results method
        /// </summary>
        [TestMethod]
        public void ExcelWriteGroupAvgMinMax()
        {
            //arrange
            AllGroupsAvgMaxMinGetter getter = new AllGroupsAvgMaxMinGetter(connectionString);
            List<GroupsAvgMinMax> results = getter.GetGroupsAvgMinMax().ToList<GroupsAvgMinMax>();
            //act
            bool flag = ExcelWorker.Write(@"GroupAvgMinMax.xlsx",results);
            //assert
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void ExcelWriteGroupAvgMinMaxWithSortingByMaxDescending()
        {
            //arrange
            AllGroupsAvgMaxMinGetter getter = new AllGroupsAvgMaxMinGetter(connectionString);
            List<GroupsAvgMinMax> results = getter.GetGroupsAvgMinMax((i)=>i.Max,SortType.Descending).ToList<GroupsAvgMinMax>();
            //act
            bool flag = ExcelWorker.Write(@"GroupAvgMinMaxWithSorting.xlsx", results);
            //assert
            Assert.IsTrue(flag);
        }
        /// <summary>
        /// Checing excle worker write dopout students method
        /// </summary>
        [TestMethod]
        public void ExcelWriteDropOutStudents()
        {
            //arrange
            DropoutStudentsGetter getter = new DropoutStudentsGetter(connectionString);
            List<DropOutStudentsByGroup> results = getter.GetExpelStudents().ToList<DropOutStudentsByGroup>();
            //act
            bool flag = ExcelWorker.Write(@"DropoutStudents.xlsx", results);
            //assert
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void ExcelWriteWithSortingBySurnameAscendingDropOutStudents()
        {
            //arrange
            DropoutStudentsGetter getter = new DropoutStudentsGetter(connectionString);
            List<DropOutStudentsByGroup> results = getter.GetExpelStudents((res) => res.Surname,SortType.Ascending).ToList<DropOutStudentsByGroup>();
            //act
            bool flag = ExcelWorker.Write(@"DropoutStudentsAscendingWithSorting.xlsx", results);
            //assert
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void ExcelWriteAverageMarkBySpecification()
        {
            //arrange
            AverageMarkBySpecificationGetter getter = new AverageMarkBySpecificationGetter(connectionString);
            List<AverageMarkBySpecification> results = getter.GetAverageMark(1).ToList();
            //act
            bool flag = ExcelWorker.Write(@"AverageMarkBySpecification.xlsx", results);
            //assert
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void ExcelWriteWithSortingByAverageMarkAverageMarkBySpecification()
        {
            //arrange
            AverageMarkBySpecificationGetter getter = new AverageMarkBySpecificationGetter(connectionString);
            List<AverageMarkBySpecification> results = getter.GetAverageMark(1,i=>i.AverageMark,SortType.Ascending).ToList();
            //act
            bool flag = ExcelWorker.Write(@"AverageMarkBySpecificationWithSorting.xlsx", results);
            //assert
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void ExcelWriteAverageMarkByExaminer()
        {
            //arrange
            AverageMarkByExaminerGetter getter = new AverageMarkByExaminerGetter(connectionString);
            List<AverageMarkByExaminer> results = getter.GetAverageMark(1).ToList();

            //act
            bool flag = ExcelWorker.Write(@"AverageMarkByExaminer.xlsx", results);
            //assert
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void ExcelWriteWithSortingByAverageMarkAverageMarkByExaminer()
        {
            //arrange
            AverageMarkByExaminerGetter getter = new AverageMarkByExaminerGetter(connectionString);
            List<AverageMarkByExaminer> results = getter.GetAverageMark(1,i=>i.AverageMark,SortType.Descending).ToList();

            //act
            bool flag = ExcelWorker.Write(@"AverageMarkByExaminerWithSorting.xlsx", results);
            //assert
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void ExcelWriteAverageMarkBySubject()
        {
            //arrange
            AverageMarksBySubjectsGetter getter = new AverageMarksBySubjectsGetter(connectionString);
            List<AverageMarksBySubjectsInOneYear> results = getter.GetAverageMarks().ToList();

            //act
            bool flag = ExcelWorker.Write(@"AverageMarkBySubject.xlsx", results);
            //assert
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void ExcelWriteWithSortingDescendingAverageMarkBySubject()
        {
            //arrange
            AverageMarksBySubjectsGetter getter = new AverageMarksBySubjectsGetter(connectionString);
            List<AverageMarksBySubjectsInOneYear> results = getter.GetAverageMarks(r=>r.AverageMark,SortType.Descending).ToList();

            //act
            bool flag = ExcelWorker.Write(@"AverageMarkBySubjectWithSorting.xlsx", results);
            //assert
            Assert.IsTrue(flag);
        }
    }
}
