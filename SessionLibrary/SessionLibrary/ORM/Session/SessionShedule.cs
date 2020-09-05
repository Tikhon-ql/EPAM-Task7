
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Session
{
    /// <summary>
    /// Session shedule's class
    /// </summary>
    [Table(Name = "SessionShedule")]
    public class SessionShedule
    {
        /// <summary>
        /// Session shedule's id property
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public int Id { get; private set; }
        /// <summary>
        /// Groups's id property
        /// </summary>
        [Column(Name = "GroupId")]
        public int GroupId { get; private set; }
        /// <summary>
        /// Work's date property
        /// </summary>
        [Column(Name = "Date")]
        public DateTime Date { get; set; }
        /// <summary>
        /// Subject's id 
        /// </summary>
        [Column(Name = "SubjectId")]
        public int SubjectId { get; set; }
        /// <summary>
        /// Work type's id
        /// </summary>
        [Column(Name = "WorkTypeId")]
        public int WorkTypeId { get; set; }
        /// <summary>
        /// Session's id property
        /// </summary>
        [Column(Name = "SessionId")]
        public int SessionId { get; set; }
        /// <summary>
        /// Examiner's id property
        /// </summary>
        [Column(Name = "ExaminerId")]
        public int ExaminerId { get; set; }

        public SessionShedule(int id, int groupId, DateTime date, int workTypeId, int subjectId, int sesId,int examierId)
        {
            Id = id;
            GroupId = groupId;
            Date = date;
            SubjectId = subjectId;
            WorkTypeId = workTypeId;
            SessionId = sesId;
            ExaminerId = examierId;
        }
        public SessionShedule()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is SessionShedule shedule &&
                   Id == shedule.Id &&
                   GroupId == shedule.GroupId &&
                   Date == shedule.Date &&
                   SubjectId == shedule.SubjectId &&
                   WorkTypeId == shedule.WorkTypeId &&
                   SessionId == shedule.SessionId &&
                   ExaminerId == shedule.ExaminerId;
        }

        public override int GetHashCode()
        {
            int hashCode = 1940496566;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + GroupId.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + SubjectId.GetHashCode();
            hashCode = hashCode * -1521134295 + WorkTypeId.GetHashCode();
            hashCode = hashCode * -1521134295 + SessionId.GetHashCode();
            hashCode = hashCode * -1521134295 + ExaminerId.GetHashCode();
            return hashCode;
        }
    }
}
