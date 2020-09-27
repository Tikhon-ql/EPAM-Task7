using System;
using System.Collections.Generic;
using System.Linq;
using AbstractUnitTestLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SessionLibrary._DAO.Models;
using SessionLibrary.ORM.Another;

namespace _StudentDao.Tests
{
    [TestClass]
    public class StudentDaoUnitTests : MyUnitTest
    {
        /// <summary>
        /// Checking write down into database method
        /// </summary>
        /// <param name="student"></param>
        [DynamicData(nameof(TestMethodCreate), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void CreateTestMethod(Student student)
        {
            //arrange
            StudentCreator stCreator = (StudentCreator)factory.GetStudentCreator();
            //act
            bool isCreated = stCreator.Create(student);
            //assert
            Assert.IsTrue(isCreated);
        }
        /// <summary>
        /// Data for checking create method
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Student[]> TestMethodCreate()
        {
            return new[]
            {
                new Student[] { new Student(15,"Pavel", "Pavlov","Pavlovich",1,2) },
                new Student[] { new Student(16,"Stas", "Statsov","Stasovich", 1,3) },
            };
        }
        /// <summary>
        /// Checking read method
        /// </summary>
        [TestMethod]
        public void ReadTestMethod()
        {
            //arrange
            Student expected = new Student(1, "Ivan", "Ivanov", "Ivanovich", 1, 1);
            //act
            StudentCreator stCreator = (StudentCreator)factory.GetStudentCreator();
            Student actual = stCreator.Read(1);
            //assert
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Checking delete method
        /// </summary>
        /// <param name="id"></param>
        [DataTestMethod]
        [DataRow(15)]
        [DataRow(16)]
        public void DeleteTestMethod(int id)
        {
            //arrange
            StudentCreator stCreator = (StudentCreator)factory.GetStudentCreator();
            //act
            bool isDeleted = stCreator.Delete(id);
            //assert
            Assert.IsTrue(isDeleted);
        }
        /// <summary>
        /// Checking update method
        /// </summary>
        /// <param name="student"></param>
        [DynamicData(nameof(TestMethodUpdate), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void UpdateTestMethod(Student student)
        {
            //arrange
            StudentCreator stCreator = (StudentCreator)factory.GetStudentCreator();
            //act
            bool isUpdated = stCreator.Update(student);
            //assert
            Assert.IsTrue(isUpdated);
        }
        /// <summary>
        /// Data for checking update method
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Student[]> TestMethodUpdate()
        {
            return new[]
            {
                new Student[] { new Student(15,"Andrey", "Pavlov","Pavlovich", 2,1) },
                new Student[] { new Student(16,"Vecheslav", "Statsov","Stasovich", 3,1) },
            };
        }
        /// <summary>
        /// Checking read all data method
        /// </summary>
        [TestMethod]
        public void GetAllTestMethod()
        {
            //arrange
            StudentCreator stCreator = (StudentCreator)factory.GetStudentCreator();
            List<Student> expected = new List<Student> {new Student(1,"Ivan","Ivanov","Ivanovich",1,1), new Student(2, "Andrey", "Andreev", "Andreevich", 1, 1),
                                                        new Student(3,"Sergey","Sergeev","Sergeevich",1,1),new Student(4,"Anna","Ivanova","Ivanovna",2,1),
                                                        new Student(5,"Alexandra","Krasnova","Sergeevna",2,2),new Student(6,"Petr","Petrov","Petrovich",1,2),
                                                        new Student(7,"Evgeniy","Kirpitch","Victorivich",1,2),new Student(8,"Stepan","Stepanov","Stepanovich",1,3),
                                                        new Student(9,"Maxim","Maximov","Maximovich",1,3),new Student(10,"Oleg","Ryba","Olegovich",1,3),
                                                        new Student(11,"Ecaterina","Pervaya","Alecseevna",2,4),new Student(12,"Ilya","Ilyn","Ivanovich",1,4),
                                                        new Student(13,"Denis","Denisov","Denisovich",1,4), new Student(14,"Sonya","Sonnaya","Genadyena",2,4)};
            //act
            List<Student> actual = stCreator.GetAll().ToList();
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
