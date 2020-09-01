
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
    /// Session's creator
    /// </summary>
    public class SessionCreator:Dao<Session>
    {
        public SessionCreator(string str) : base(str) { }
    }
}
