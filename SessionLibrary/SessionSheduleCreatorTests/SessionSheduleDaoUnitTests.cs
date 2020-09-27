using System;
using System.Collections.Generic;
using System.Linq;
using AbstractUnitTestLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SessionLibrary._DAO.Models;
using SessionLibrary.ORM.Session;

namespace _SessionShedule.Tests
{
    [TestClass]
    public class SessionSheduleDaoUnitTests : MyUnitTest
    {
        /// <summary>
        /// Checking write down into database method
        /// </summary>
        /// <param name="student"></param>
        [DynamicData(nameof(TestMethodCreate), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void CreateTestMethod(SessionShedule sh)
        {
            //arrange
            SessionSheduleCreator stCreator = (SessionSheduleCreator)factory.GetSessionSheduleCreator();
            //act
            bool isCreated = stCreator.Create(sh);
            //assert
            Assert.IsTrue(isCreated);
        }
        /// <summary>
        /// Data for checking create method
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<SessionShedule[]> TestMethodCreate()
        {
            return new[]
            {
                new SessionShedule[] { new SessionShedule(9,1,new DateTime(2019,11,16),1,1) },
                new SessionShedule[] { new SessionShedule(10,2, new DateTime(2019, 11, 15), 1,2) },
            };
        }
        /// <summary>
        /// Checking read method
        /// </summary>
        [TestMethod]
        public void ReadTestMethod()
        {
            //arrange
            SessionShedule expected = new SessionShedule(1, 1, new DateTime(2019, 11, 10), 1,1);
            //act
            SessionSheduleCreator stCreator = (SessionSheduleCreator)factory.GetSessionSheduleCreator();
            SessionShedule actual = stCreator.Read(1);
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Checking delete method
        /// </summary>
        /// <param name="id"></param>
        [DataTestMethod]
        [DataRow(9)]
        [DataRow(10)]
        public void DeleteTestMethod(int id)
        {
            //arrange
            SessionSheduleCreator stCreator = (SessionSheduleCreator)factory.GetSessionSheduleCreator();
            //act
            bool isDeleted = stCreator.Delete(id);
            //assert
            Assert.IsTrue(isDeleted);
        }
        /// <summary>
        /// Checking update method
        /// </summary>
        /// <param name="ses"></param>
        [DynamicData(nameof(TestMethodUpdate), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void UpdateTestMethod(SessionShedule ses)
        {
            //arrange
            SessionSheduleCreator stCreator = (SessionSheduleCreator)factory.GetSessionSheduleCreator();
            //act
            bool isUpdated = stCreator.Update(ses);
            //assert
            Assert.IsTrue(isUpdated);
        }
        /// <summary>
        /// Data for checking update method
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<SessionShedule[]> TestMethodUpdate()
        {
            return new[]
            {
                new SessionShedule[] { new SessionShedule(9,1,new DateTime(2019,11,15),1,1) },
                new SessionShedule[] { new SessionShedule(10,2, new DateTime(2019, 11, 14),1,2) },
            };
        }
        /// <summary>
        /// Checking read all data method
        /// </summary>
        [TestMethod]
        public void GetAllTestMethod()
        {
            //arrange
            SessionSheduleCreator stCreator = (SessionSheduleCreator)factory.GetSessionSheduleCreator();
            List<SessionShedule> expected = new List<SessionShedule> { new SessionShedule(1,1,new DateTime(2019,11,10),1,1) , new SessionShedule(2,2,new DateTime(2019,11,15),1,2),
                                                        new SessionShedule(3,3,new DateTime(2020,7,10),1,3),new SessionShedule(4,4,new DateTime(2020,7,14),1,4),
                                                        new SessionShedule(5,1,new DateTime(2019,11,13),1,1),new SessionShedule(6,2,new DateTime(2019,11,14),1,2),
                                                        new SessionShedule(7,3,new DateTime(2020,7,15),1,3),new SessionShedule(8,4,new DateTime(2020,7,16),2,4)
        };
            //act
            List<SessionShedule> actual = stCreator.GetAll().ToList();
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
