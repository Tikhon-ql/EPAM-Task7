
using SessionLibrary.ORM.Another;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary._DAO.Models
{
    /// <summary>
    /// Groups creator
    /// </summary>
    public class GroupCreator:Dao<Group>
    {
        public GroupCreator(string str) : base(str) { }
    }
}
