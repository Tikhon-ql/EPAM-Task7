using SessionLibrary.ORM.Another;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary._DAO.Models
{
    public class ExaminerCreator:Dao<Examiner>
    {
        public ExaminerCreator(string connect):base(connect) { }
    }
}
