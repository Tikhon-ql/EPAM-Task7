
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
    /// Session shedule's creator
    /// </summary>
    public class SessionSheduleCreator:Dao<SessionShedule>
    {
        public SessionSheduleCreator(string str) : base(str) { }
    }
}
