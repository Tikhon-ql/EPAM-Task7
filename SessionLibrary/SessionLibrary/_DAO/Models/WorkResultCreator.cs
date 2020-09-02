
using SessionLibrary._DAO.Interface;
using SessionLibrary.ORM.Work;
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
    /// Work result's creator
    /// </summary>
    public class WorkResultCreator:IDao<WorkResult>
    {
        private string connectionString;
        public WorkResultCreator(string str)
        {
            connectionString = str;
        }

        public bool Create(WorkResult value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    db.GetTable<WorkResult>().InsertOnSubmit(value);
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

                    Table<WorkResult> table = db.GetTable<WorkResult>();
                    WorkResult deleted = table.FirstOrDefault(g => g.Id == id);
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

        public ICollection<WorkResult> GetAll()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<WorkResult>().ToList();
            }
        }

        public WorkResult Read(int id)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<WorkResult>().FirstOrDefault(g => g.Id == id);
            }
        }

        public bool Update(WorkResult value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    WorkResult gn = db.GetTable<WorkResult>().FirstOrDefault(g => g.Id == value.Id);
                    if (gn != null)
                    {
                        gn = value;
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
