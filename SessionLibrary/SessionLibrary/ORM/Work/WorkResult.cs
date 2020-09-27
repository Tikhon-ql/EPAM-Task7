using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Work
{
    /// <summary>
    /// Work result's class
    /// </summary>
    [Table(Name = "WorkResult")]
    public class WorkResult
    {
        /// <summary>
        /// Work result's id property
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }
        /// <summary>
        /// Student's id property
        /// </summary>
        [Column(Name = "StudentId")]
        public int StudentId{ get; set; }
        /// <summary>
        /// Subject's id property
        /// </summary>
        [Column(Name = "SubjectId")]
        public int SubjectId{ get; set; }
        /// <summary>
        /// Wokr's result property
        /// </summary>
        [Column(Name = "Result")]
        public string Result { get; set; }
        /// <summary>
        /// Work type's id property
        /// </summary>
        [Column(Name = "WorkTypeId")]
        public int WorkTypeId { get; set; }
        /// <summary>
        /// Session shedule's id property
        /// </summary>
        [Column(Name = "SessionSheduleId")]
        public int SessionSheduleId { get; set; }

        public WorkResult(int id, string result,  int student, int subject, int workTypeId,int sesShId)
        {
            Id = id;
            StudentId = student;
            SubjectId = subject;
            Result = result;
            WorkTypeId = workTypeId;
            SessionSheduleId = sesShId;
        }
        public WorkResult()
        {

        }
        public override bool Equals(object obj)
        {
            return obj is WorkResult result &&
                   StudentId == result.StudentId &&
                   SubjectId == result.SubjectId &&
                   Result == result.Result &&
                   WorkTypeId == result.WorkTypeId &&
                   SessionSheduleId == result.SessionSheduleId;
        }

        public override int GetHashCode()
        {
            int hashCode = 552405456;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + StudentId.GetHashCode();
            hashCode = hashCode * -1521134295 + SubjectId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Result);
            hashCode = hashCode * -1521134295 + WorkTypeId.GetHashCode();
            hashCode = hashCode * -1521134295 + SessionSheduleId.GetHashCode();
            return hashCode;
        }
    }
}
