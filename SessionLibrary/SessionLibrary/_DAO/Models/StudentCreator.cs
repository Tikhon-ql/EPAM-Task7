using SessionLibrary._DAO.Interface;
using SessionLibrary.ORM.Another;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary._DAO.Models
{
    /// <summary>
    /// Student's creator
    /// </summary>
    public class StudentCreator : IDao<Student>
    {
        private string connectionString;
        public StudentCreator(string str)
        {
            connectionString = str;
        }

        public bool Create(Student value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    db.GetTable<Student>().InsertOnSubmit(value);
                    db.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {

                    Table<Student> table = db.GetTable<Student>();
                    Student deleted = table.FirstOrDefault(g => g.Id == id);
                    table.DeleteOnSubmit(deleted);
                    db.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ICollection<Student> GetAll()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Student>().ToList();
            }
        }

        public Student Read(int id)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Student>().FirstOrDefault(g => g.Id == id);
            }
        }

        public bool Update(Student value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    Student gn = db.GetTable<Student>().FirstOrDefault(g => g.Id == value.Id);
                    if (gn != null)
                    {
                        gn.Id = value.Id;
                        gn.MidleName = value.MidleName;
                        gn.Name = value.Name;
                        gn.Surname = value.Surname;
                        gn.GroupId = value.GroupId;
                        gn.GenderId = value.GenderId;
                        db.SubmitChanges();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
