
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
    /// Session shedule's creator
    /// </summary>
    public class SessionSheduleCreator:IDao<SessionShedule>
    {
        private string connectionString;
        public SessionSheduleCreator(string str)
        {
            connectionString = str;
        }

        public bool Create(SessionShedule value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    db.GetTable<SessionShedule>().InsertOnSubmit(value);
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

                    Table<SessionShedule> sessionShedules = db.GetTable<SessionShedule>();
                    SessionShedule deleted = sessionShedules.FirstOrDefault(g => g.Id == id);
                    sessionShedules.DeleteOnSubmit(deleted);
                    db.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ICollection<SessionShedule> GetAll()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<SessionShedule>().ToList();
            }
        }

        public SessionShedule Read(int id)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<SessionShedule>().FirstOrDefault(g => g.Id == id);
            }
        }

        public bool Update(SessionShedule value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    SessionShedule gn = db.GetTable<SessionShedule>().FirstOrDefault(g => g.Id == value.Id);
                    if (gn != null)
                    {
                        gn.Id = value.Id;
                        gn.GroupId = value.GroupId;
                        gn.SessionId = value.SessionId;
                        gn.SubjectId = value.SubjectId;
                        gn.ExaminerId = value.ExaminerId;
                        gn.Date = value.Date;
                        gn.WorkTypeId = value.WorkTypeId;
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
