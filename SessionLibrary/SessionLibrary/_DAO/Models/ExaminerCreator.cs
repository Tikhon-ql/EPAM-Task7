using SessionLibrary._DAO.Interface;
using SessionLibrary.ORM.Another;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary._DAO.Models
{
    public class ExaminerCreator : IDao<Examiner>
    {
        private string connectionString;
        public ExaminerCreator(string str)
        {
            connectionString = str;
        }

        public bool Create(Examiner value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    db.GetTable<Examiner>().InsertOnSubmit(value);
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

                    Table<Examiner> examiners = db.GetTable<Examiner>();
                    Examiner deleted = examiners.FirstOrDefault(e => e.Id == id);
                    examiners.DeleteOnSubmit(deleted);
                    db.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ICollection<Examiner> GetAll()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Examiner>().ToList();
            }
        }

        public Examiner Read(int id)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Examiner>().FirstOrDefault(e=>e.Id == id);
            }
        }

        public bool Update(Examiner value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    Examiner ex = db.GetTable<Examiner>().FirstOrDefault(e => e.Id == value.Id);
                    if(ex != null)
                    {
                        ex = value;
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
