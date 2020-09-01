
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
    /// Subject's creator
    /// </summary>
    public class SubjectCreator:Dao<Subject>
    {
        public SubjectCreator(string str) : base(str) { }
    }
}
