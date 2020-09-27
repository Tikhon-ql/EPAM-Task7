using System;
using System.Collections.Generic;
using System.Linq;
using AbstractUnitTestLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SessionLibrary._DAO.Models;
using SessionLibrary.ORM.Another;

namespace SubjectDao.Tests
{
    [TestClass]
    public class SubjectDaoUnitTests : MyUnitTest
    {

        /// <summary>
        /// Checking write down into database method
        /// </summary>
        /// <param name="subject"></param>
        [DynamicData(nameof(TestMethodCreate), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void CreateTestMethod(Subject subject)
        {
            //arrange
            SubjectCreator stCreator = (SubjectCreator)factory.GetSubjectCreator();
            //act
            bool isCreated = stCreator.Create(subject);
            //assert
            Assert.IsTrue(isCreated);
        }
        /// <summary>
        /// Data for checking create method
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Subject[]> TestMethodCreate()
        {
            return new[]
            {
                new Subject[] { new Subject(5,"Subject-5") },
                new Subject[] { new Subject(6,"Subject-6") },
            };
        }
        /// <summary>
        /// Checking read method
        /// </summary>
        [TestMethod]
        public void ReadTestMethod()
        {
            //arrange
            Subject expected = new Subject(1, "Math");
            //act
            SubjectCreator stCreator = (SubjectCreator)factory.GetSubjectCreator();
            Subject actual = stCreator.Read(1);
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Checking delete method
        /// </summary>
        /// <param name="id"></param>
        [DataTestMethod]
        [DataRow(5)]
        [DataRow(6)]
        public void DeleteTestMethod(int id)
        {
            //arrange
            SubjectCreator stCreator = (SubjectCreator)factory.GetSubjectCreator();
            //act
            bool isDeleted = stCreator.Delete(id);
            //assert
            Assert.IsTrue(isDeleted);
        }
        /// <summary>
        /// Checking update method
        /// </summary>
        /// <param name="subject"></param>
        [DynamicData(nameof(TestMethodUpdate), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void UpdateTestMethod(Subject subject)
        {
            //arrange
            SubjectCreator stCreator = (SubjectCreator)factory.GetSubjectCreator();
            //act
            bool isUpdated = stCreator.Update(subject);
            //assert
            Assert.IsTrue(isUpdated);
        }
        /// <summary>
        /// Data for checking update method
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Subject[]> TestMethodUpdate()
        {
            return new[]
            {
                  new Subject[] { new Subject(5,"Subject-55") },
                  new Subject[] { new Subject(6,"Subject-66") },
            };
        }
        /// <summary>
        /// Checking read all data method
        /// </summary>
        [TestMethod]
        public void GetAllTestMethod()
        {
            //arrange
            SubjectCreator stCreator = (SubjectCreator)factory.GetSubjectCreator();
            List<Subject> expected = new List<Subject> {new Subject(1,"Math"),
                                                        new Subject(2,"Physics"),
                                                        new Subject(3,"Philosophy"),
                                                        new Subject(4,"Psychology")};
            //act
            List<Subject> actual = stCreator.GetAll().ToList();
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
