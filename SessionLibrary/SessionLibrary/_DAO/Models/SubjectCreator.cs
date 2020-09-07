
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
    /// Subject's creator
    /// </summary>
    public class SubjectCreator:IDao<Subject>
    {
        private string connectionString;
        public SubjectCreator(string str)
        {
            connectionString = str;
        }

        public bool Create(Subject value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    db.GetTable<Subject>().InsertOnSubmit(value);
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

                    Table<Subject> table = db.GetTable<Subject>();
                    Subject deleted = table.FirstOrDefault(g => g.Id == id);
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

        public ICollection<Subject> GetAll()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Subject>().ToList();
            }
        }

        public Subject Read(int id)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Subject>().FirstOrDefault(g => g.Id == id);
            }
        }

        public bool Update(Subject value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    Subject gn = db.GetTable<Subject>().FirstOrDefault(g => g.Id == value.Id);
                    if (gn != null)
                    {
                        gn.Id = value.Id;
                        gn.SubjectName = value.SubjectName;
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
