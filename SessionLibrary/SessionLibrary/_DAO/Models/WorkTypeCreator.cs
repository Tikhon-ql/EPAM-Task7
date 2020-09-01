
using SessionLibrary.ORM.Work;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary._DAO.Models
{
    /// <summary>
    /// Work type's creator
    /// </summary>
    public class WorkTypeCreator:Dao<WorkType>
    {
        public WorkTypeCreator(string str) : base(str) { }
    }
}
