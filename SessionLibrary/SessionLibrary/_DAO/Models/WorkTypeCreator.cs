
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
    /// Work type's creator
    /// </summary>
    public class WorkTypeCreator:IDao<WorkType>
    {
        private string connectionString;
        public WorkTypeCreator(string str)
        {
            connectionString = str;
        }

        public bool Create(WorkType value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    db.GetTable<WorkType>().InsertOnSubmit(value);
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

                    Table<WorkType> table = db.GetTable<WorkType>();
                    WorkType deleted = table.FirstOrDefault(g => g.Id == id);
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

        public ICollection<WorkType> GetAll()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<WorkType>().ToList();
            }
        }

        public WorkType Read(int id)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<WorkType>().FirstOrDefault(g => g.Id == id);
            }
        }

        public bool Update(WorkType value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    WorkType gn = db.GetTable<WorkType>().FirstOrDefault(g => g.Id == value.Id);
                    if (gn != null)
                    {
                        gn.Id = value.Id;
                        gn.WorkTypeName = value.WorkTypeName;
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
