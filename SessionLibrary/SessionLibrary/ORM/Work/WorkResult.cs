using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Work
{
    /// <summary>
    /// Work result's class
    /// </summary>
    public class WorkResult
    {
        /// <summary>
        /// Work result's id property
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Student's id property
        /// </summary>
        public int StudentId{ get; set; }
        /// <summary>
        /// Subject's id property
        /// </summary>
        public int SubjectId{ get; set; }
        /// <summary>
        /// Wokr's result property
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// Work type's id
        /// </summary>
        public int WorkTypeId { get; set; }

        public WorkResult(int id, string result,  int student, int subject, int workTypeId)
        {
            Id = id;
            StudentId = student;
            SubjectId = subject;
            Result = result;
            WorkTypeId = workTypeId;
        }
    }
}
