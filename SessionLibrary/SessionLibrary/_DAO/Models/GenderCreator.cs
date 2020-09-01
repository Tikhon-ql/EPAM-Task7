
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
    /// Gender's creator
    /// </summary>
    public class GenderCreator:Dao<Gender>
    {
        public GenderCreator(string str) : base(str) { }
    }
}
