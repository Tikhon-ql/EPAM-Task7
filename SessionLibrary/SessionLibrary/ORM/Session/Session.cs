
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Session
{
    /// <summary>
    /// Session's class
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Session's id property
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Session's academic years property
        /// </summary>
        public string AcademicYears { get; set; }
        /// <summary>
        /// Session type's id property
        /// </summary>
        public int SessionTypeId { get; set; }

        public Session()
        {
                
        }
        public Session(int id, int sessionTypeId, string academicYears)
        {
            Id = id;
            AcademicYears = academicYears;
            SessionTypeId = sessionTypeId;
        }
    }
}
