using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SessionLibrary._DAO.Models;
using SessionLibrary.DaoFactory.Models;
using SessionLibrary.ORM.Another;

namespace SessionDao.Tests
{
    [TestClass]
    public class SessionDaoUnitTests
    {
        private static SessionFactory factory;
        static SessionDaoUnitTests()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(localdb)\mssqllocaldb";
            builder.InitialCatalog = @"SessionLibrary";
            builder.IntegratedSecurity = true;
            factory = SessionFactory.GetInstence(builder.ConnectionString);
        }
      
        [DynamicData(nameof(TestMethodCreate),DynamicDataSourceType.Method)]
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
        private static IEnumerable<Student[]> TestMethodCreate()
        {
            return new[]
            {
                new Student[] { new Student(15,"Pavel", "Pavlov","Pavlovich",1,2) },
                new Student[] { new Student(16,"Stas", "Statsov","Stasovich", 1,3) },
            };
        }
        //[DynamicData(nameof(TestMethodRead), DynamicDataSourceType.Method)]
        [TestMethod]
        public void ReadTestMethod()
        {
            //arrange
            Student expected = new Student(1,"Ivan","Ivanov","Ivanovich",1,1);
            //act
            StudentCreator stCreator = (StudentCreator)factory.GetStudentCreator();
            Student actual = stCreator.Read(1);
            //assert
            Assert.AreEqual(expected, actual);
        }
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
        private static IEnumerable<Student[]> TestMethodUpdate()
        {
            return new[]
            {
                new Student[] { new Student(15,"Andrey", "Pavlov","Pavlovich", 2,1) },
                new Student[] { new Student(16,"Vecheslav", "Statsov","Stasovich", 3,1) },
            };
        }

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
