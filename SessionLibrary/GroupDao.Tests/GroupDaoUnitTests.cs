using System;
using System.Collections.Generic;
using System.Linq;
using AbstractUnitTestLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SessionLibrary._DAO.Models;
using SessionLibrary.ORM.Another;

namespace GroupDao.Tests
{
    [TestClass]
    public class GroupDaoUnitTests : MyUnitTest
    {
        /// <summary>
        /// Checking write down into database method
        /// </summary>
        /// <param name="student"></param>
        [DynamicData(nameof(TestMethodCreate), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void CreateTestMethod(Group group)
        {
            //arrange
            GroupCreator creator = (GroupCreator)factory.GetGroupCreator();
            //act
            bool isCreated = creator.Create(group);
            //assert
            Assert.IsTrue(isCreated);
        }
        /// <summary>
        /// Data for checking create method
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Group[]> TestMethodCreate()
        {
            return new[]
            {
                new Group[] { new Group(5,"Group-5",1) },
                new Group[] { new Group(6,"Group-6",2) },
            };
        }
        /// <summary>
        /// Checking read method
        /// </summary>
        [TestMethod]
        public void ReadTestMethod()
        {
            //arrange
            Group expected = new Group(1, "Group-1",1);
            //act
            GroupCreator creator = (GroupCreator)factory.GetGroupCreator();
            Group actual = creator.Read(1);
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
            GroupCreator creator = (GroupCreator)factory.GetGroupCreator();
            //act
            bool isDeleted = creator.Delete(id);
            //assert
            Assert.IsTrue(isDeleted);
        }
        /// <summary>
        /// Checking update method
        /// </summary>
        /// <param name="group"></param>
        [DynamicData(nameof(TestMethodUpdate), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void UpdateTestMethod(Group group)
        {
            //arrange
            GroupCreator creator = (GroupCreator)factory.GetGroupCreator();
            //act
            bool isUpdated = creator.Update(group);
            //assert
            Assert.IsTrue(isUpdated);
        }
        /// <summary>
        /// Data for checking update method
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Group[]> TestMethodUpdate()
        {
            return new[]
            {
                new Group[] { new Group(5,"_Group-5",1) },
                new Group[] { new Group(6,"_Group-6",2) },
            };
        }
        /// <summary>
        /// Checking read all data method
        /// </summary>
        [TestMethod]
        public void GetAllTestMethod()
        {
            //arrange
            GroupCreator creator = (GroupCreator)factory.GetGroupCreator();
            List<Group> expected = new List<Group> {new Group(1,"Group-1",1),
                                                    new Group(2, "Group-2",2),
                                                    new Group(3,"Group-3",3),
                                                    new Group(4,"Group-4",4)};
            //act
            List<Group> actual = creator.GetAll().ToList<Group>();
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
