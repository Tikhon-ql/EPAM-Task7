
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
    /// Session's creator
    /// </summary>
    public class SessionCreator:IDao<Session>
    {
        private string connectionString;
        public SessionCreator(string str)
        {
            connectionString = str;
        }

        public bool Create(Session value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    db.GetTable<Session>().InsertOnSubmit(value);
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

                    Table<Session> sessions = db.GetTable<Session>();
                    Session deleted = sessions.FirstOrDefault(s => s.Id == id);
                    sessions.DeleteOnSubmit(deleted);
                    db.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ICollection<Session> GetAll()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Session>().ToList();
            }
        }

        public Session Read(int id)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Session>().FirstOrDefault(s => s.Id == id);
            }
        }

        public bool Update(Session value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    Session ses = db.GetTable<Session>().FirstOrDefault(s => s.Id == value.Id);
                    if (ses != null)
                    {
                        ses.Id = value.Id;
                        ses.AcademicYears = value.AcademicYears;
                        ses.SessionTypeId = value.SessionTypeId;
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
