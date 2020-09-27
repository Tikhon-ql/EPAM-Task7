using System;
using System.Collections.Generic;
using System.Linq;
using AbstractUnitTestLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SessionLibrary._DAO.Models;
using SessionLibrary.ORM.Work;

namespace WorkResultDao.Tests
{
    [TestClass]
    public class WorkResultDaoUnitTests : MyUnitTest
    {
        /// <summary>
        /// Checking write down into database method
        /// </summary>
        /// <param name="workResult"></param>
        [DynamicData(nameof(TestMethodCreate), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void CreateTestMethod(WorkResult workResult)
        {
            //arrange
            WorkResultCreator stCreator = (WorkResultCreator)factory.GetWorkResultCreator();
            //act
            bool isCreated = stCreator.Create(workResult);
            //assert
            Assert.IsTrue(isCreated);
        }
        /// <summary>
        /// Data for checking create method
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<WorkResult[]> TestMethodCreate()
        {
            return new[]
            {
                new WorkResult[] { new WorkResult(30,"Credit",14,3,2,1) },
                new WorkResult[] { new WorkResult(31,"7",13,2,1,2) },
            };
        }
        /// <summary>
        /// Checking read method
        /// </summary>
        [TestMethod]
        public void ReadTestMethod()
        {
            //arrange
            WorkResult expected = new WorkResult(1, "8", 1, 1, 1,1);
            //act
            WorkResultCreator stCreator = (WorkResultCreator)factory.GetWorkResultCreator();
            WorkResult actual = stCreator.Read(1);
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Checking delete method
        /// </summary>
        /// <param name="id"></param>
        [DataTestMethod]
        [DataRow(30)]
        [DataRow(31)]
        public void DeleteTestMethod(int id)
        {
            //arrange
            WorkResultCreator stCreator = (WorkResultCreator)factory.GetWorkResultCreator();
            //act
            bool isDeleted = stCreator.Delete(id);
            //assert
            Assert.IsTrue(isDeleted);
        }
        /// <summary>
        /// Checking update method
        /// </summary>
        /// <param name="work"></param>
        [DynamicData(nameof(TestMethodUpdate), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void UpdateTestMethod(WorkResult work)
        {
            //arrange
            WorkResultCreator stCreator = (WorkResultCreator)factory.GetWorkResultCreator();
            //act
            bool isUpdated = stCreator.Update(work);
            //assert
            Assert.IsTrue(isUpdated);
        }
        /// <summary>
        /// Data for checking update method
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<WorkResult[]> TestMethodUpdate()
        {
            return new[]
            {
                     new WorkResult[] { new WorkResult(30,"Uncredit",15,3,2,1) },
                new WorkResult[] { new WorkResult(31,"8",17,2,1,2) },
            };
        }
        /// <summary>
        /// Checking read all data method
        /// </summary>
        [TestMethod]
        public void GetAllTestMethod()
        {
            //arrange
            WorkResultCreator stCreator = (WorkResultCreator)factory.GetWorkResultCreator();
            List<WorkResult> expected = new List<WorkResult> {new  WorkResult(1,"8",1,1,1,1), new  WorkResult(2,"9",2,2,1,2),
                                                        new  WorkResult(3,"Credit",3,3,2,3),new  WorkResult(4,"Credit",4,4,2,4),
                                                        new  WorkResult(5,"Uncredit",5,4,2,5),new  WorkResult(6,"Credit",6,3,2,6),
                                                        new  WorkResult(7,"Credit",7,4,2,7),new  WorkResult(8,"Uncredit",8,3,2,8),
                                                        new  WorkResult(9,"Credit",9,4,2,1),new  WorkResult(10,"Credit",10,3,2,2),
                                                        new  WorkResult(11,"2",11,1,1,3),new  WorkResult(12,"3",12,2,1,4),
                                                        new  WorkResult(13,"4",13,2,1,5),new  WorkResult(14,"6",14,1,1,6),
                                                        new  WorkResult(15,"7",5,2,1,7),new  WorkResult(16,"8",2,1,1,8),
                                                        new  WorkResult(17,"8",4,1,1,1),new  WorkResult(18,"9",1,2,1,2),
                                                        new  WorkResult(19,"Credit",1,3,2,3),new  WorkResult(20,"6",2,1,1,4),
                                                        new  WorkResult(21,"Uncredit",3,4,2,5),new  WorkResult(22,"2",4,1,1,6),
                                                        new  WorkResult(23,"3",3,1,1,7),new  WorkResult(24,"8",9,1,1,8),
                                                        new  WorkResult(25,"4",8,2,1,1),new  WorkResult(26,"7",10,1,1,2),
                                                        new  WorkResult(27,"8",8,1,1,3),new  WorkResult(28,"6",9,2,1,4),
                                                        new  WorkResult(29,"8",10,2,1,5)
            };
            //act
            List<WorkResult> actual = stCreator.GetAll().ToList();
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
