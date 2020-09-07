
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
    /// Groups creator
    /// </summary>
    public class GroupCreator:IDao<Group>
    {
        private string connectionString;
        public GroupCreator(string str)
        {
            connectionString = str;
        }

        public bool Create(Group value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    db.GetTable<Group>().InsertOnSubmit(value);
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

                    Table<Group> groups = db.GetTable<Group>();
                    Group deleted = groups.FirstOrDefault(g => g.Id == id);
                    groups.DeleteOnSubmit(deleted);
                    db.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ICollection<Group> GetAll()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Group>().ToList();
            }
        }

        public Group Read(int id)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Group>().FirstOrDefault(g => g.Id == id);
            }
        }

        public bool Update(Group value)
        {
            try
            {
                using (DataContext db = new DataContext(connectionString))
                {
                    Group gr = db.GetTable<Group>().FirstOrDefault(g => g.Id == value.Id);
                    if (gr != null)
                    {
                        gr.Id = value.Id;
                        gr.GroupName = value.GroupName;
                        gr.SpecificationId = value.SpecificationId;
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
