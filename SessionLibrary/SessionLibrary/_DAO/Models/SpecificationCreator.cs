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
    public class SpecificationCreator : IDao<Specification>
    {
        private string connectionString;
        public SpecificationCreator(string str)
        {
            connectionString = str;
        }
        public bool Create(Specification value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    db.GetTable<Specification>().InsertOnSubmit(value);
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

                    Table<Specification> table = db.GetTable<Specification>();
                    Specification deleted = table.FirstOrDefault(g => g.Id == id);
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

        public ICollection<Specification> GetAll()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Specification>().ToList();
            }
        }

        public Specification Read(int id)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Specification>().FirstOrDefault(g => g.Id == id);
            }
        }

        public bool Update(Specification value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    Specification gn = db.GetTable<Specification>().FirstOrDefault(g => g.Id == value.Id);
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
