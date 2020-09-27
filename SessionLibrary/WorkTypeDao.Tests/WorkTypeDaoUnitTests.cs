using System;
using System.Collections.Generic;
using System.Linq;
using AbstractUnitTestLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SessionLibrary._DAO.Models;
using SessionLibrary.ORM.Work;

namespace WorkTypeDao.Tests
{
    [TestClass]
    public class WorkTypeDaoUnitTests : MyUnitTest
    {
        /// <summary>
        /// Checking write down into database method
        /// </summary>
        /// <param name="workType"></param>
        [DynamicData(nameof(TestMethodCreate), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void CreateTestMethod(WorkType workType)
        {
            //arrange
            WorkTypeCreator stCreator = (WorkTypeCreator)factory.GetWorkTypeCreator();
            //act
            bool isCreated = stCreator.Create(workType);
            //assert
            Assert.IsTrue(isCreated);
        }
        /// <summary>
        /// Data for checking create method
        /// </summary>
        /// <returns></returns>

        private static IEnumerable<WorkType[]> TestMethodCreate()
        {
            return new[]
            {
                new WorkType[] { new WorkType(3,"Practical work") },
                new WorkType[] { new WorkType(4,"Laboratory work") },
            };
        }
        /// <summary>
        /// Checking read method
        /// </summary>
        [TestMethod]
        public void ReadTestMethod()
        {
            //arrange
            WorkType expected = new WorkType(1, "Examen");
            WorkTypeCreator stCreator = (WorkTypeCreator)factory.GetWorkTypeCreator();
            //act
            WorkType actual = stCreator.Read(1);
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Checking delete method
        /// </summary>
        /// <param name="id"></param>
        [DataTestMethod]
        [DataRow(3)]
        [DataRow(4)]
        public void DeleteTestMethod(int id)
        {
            //arrange
            WorkTypeCreator stCreator = (WorkTypeCreator)factory.GetWorkTypeCreator();
            //act
            bool isDeleted = stCreator.Delete(id);
            //assert
            Assert.IsTrue(isDeleted);
        }

        /// <summary>
        /// Checking update method
        /// </summary>
        /// <param name="workType"></param>
        [DynamicData(nameof(TestMethodUpdate), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void UpdateTestMethod(WorkType workType)
        {
            //arrange
            WorkTypeCreator stCreator = (WorkTypeCreator)factory.GetWorkTypeCreator();
            //act
            bool isUpdated = stCreator.Update(workType);
            //assert
            Assert.IsTrue(isUpdated);
        }
        /// <summary>
        /// Data for checking update method
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<WorkType[]> TestMethodUpdate()
        {
            return new[]
            {
                  new WorkType[] { new WorkType(3,"Practical_work") },
                new WorkType[] { new WorkType(4,"Laboratorl_work") },
            };
        }
        /// <summary>
        /// Checking read all data method
        /// </summary>
        [TestMethod]
        public void GetAllTestMethod()
        {
            //arrange
            WorkTypeCreator stCreator = (WorkTypeCreator)factory.GetWorkTypeCreator();
            List<WorkType> expected = new List<WorkType> {new WorkType(1,"Examen"),
                                                        new WorkType(2, "Credit") };

            //act
            List<WorkType> actual = stCreator.GetAll().ToList();
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
