
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
    /// Gender's creator
    /// </summary>
    public class GenderCreator:IDao<Gender>
    {
        private string connectionString;
        public GenderCreator(string str)
        {
            connectionString = str;
        }

        public bool Create(Gender value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    db.GetTable<Gender>().InsertOnSubmit(value);
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

                    Table<Gender> table = db.GetTable<Gender>();
                    Gender deleted = table.FirstOrDefault(g => g.Id == id);
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

        public ICollection<Gender> GetAll()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Gender>().ToList();
            }
        }

        public Gender Read(int id)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Gender>().FirstOrDefault(g => g.Id == id);
            }
        }

        public bool Update(Gender value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    Gender gn = db.GetTable<Gender>().FirstOrDefault(g => g.Id == value.Id);
                    if (gn != null)
                    {
                        gn.Id = value.Id;
                        gn.GenderName = value.GenderName;
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
