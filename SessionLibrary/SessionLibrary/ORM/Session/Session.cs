
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Session
{
    /// <summary>
    /// Session's class
    /// </summary>
    [Table(Name = "Session")]
    public class Session
    {
        /// <summary>
        /// Session's id property
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public int Id { get; private set; }
        /// <summary>
        /// Session's academic years property
        /// </summary>
        [Column(Name = "AcademicYears")]
        public string AcademicYears { get; set; }
        /// <summary>
        /// Session type's id property
        /// </summary>
        [Column(Name = "SessionTypeId")]
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
