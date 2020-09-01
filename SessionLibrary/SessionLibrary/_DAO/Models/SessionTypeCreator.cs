
using SessionLibrary.ORM.Session;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary._DAO.Models
{
    /// <summary>
    /// Session type's creator
    /// </summary>
    public class SessionTypeCreator:Dao<SessionType>
    {
        public SessionTypeCreator(string str) : base(str) { }
    }
}
