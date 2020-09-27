
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
        public int Id { get; set; }
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
        public Session(int id, int sessionTypeId, string academicYear)
        {
            Id = id;
            AcademicYears = academicYear;
            SessionTypeId = sessionTypeId;
        }

        public override bool Equals(object obj)
        {
            return obj is Session session &&
                   AcademicYears == session.AcademicYears &&
                   SessionTypeId == session.SessionTypeId;
        }

        public override int GetHashCode()
        {
            int hashCode = -1646005154;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AcademicYears);
            hashCode = hashCode * -1521134295 + SessionTypeId.GetHashCode();
            return hashCode;
        }
    }
}
