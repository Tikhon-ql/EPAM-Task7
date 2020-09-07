
using SessionLibrary._DAO.Interface;
using SessionLibrary.ORM.Session;
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
    /// Session type's creator
    /// </summary>
    public class SessionTypeCreator:IDao<SessionType>
    {
        private string connectionString;
        public SessionTypeCreator(string str)
        {
            connectionString = str;
        }

        public bool Create(SessionType value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    db.GetTable<SessionType>().InsertOnSubmit(value);
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

                    Table<SessionType> table = db.GetTable<SessionType>();
                    SessionType deleted = table.FirstOrDefault(g => g.Id == id);
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

        public ICollection<SessionType> GetAll()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<SessionType>().ToList();
            }
        }

        public SessionType Read(int id)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<SessionType>().FirstOrDefault(g => g.Id == id);
            }
        }

        public bool Update(SessionType value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    SessionType gn = db.GetTable<SessionType>().FirstOrDefault(g => g.Id == value.Id);
                    if (gn != null)
                    {
                        gn.Id = value.Id;
                        gn.SessionTypeName = value.SessionTypeName;
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
