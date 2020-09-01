
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Session
{
    /// <summary>
    /// Session shedule's class
    /// </summary>
    public class SessionShedule
    {
        /// <summary>
        /// Session shedule's id property
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Groups's id property
        /// </summary>
        public int GroupId { get; private set; }
        /// <summary>
        /// Work's date property
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Subject's id 
        /// </summary>
        public int SubjectId { get; set; }
        /// <summary>
        /// Work type's id
        /// </summary>
        public int WorkTypeId { get; set; }
        /// <summary>
        /// Session's id property
        /// </summary>
        public int SessionId { get; set; }

        public SessionShedule(int id, int groupId, DateTime date, int workTypeId, int subjectId, int sesId)
        {
            Id = id;
            GroupId = groupId;
            Date = date;
            SubjectId = subjectId;
            WorkTypeId = workTypeId;
            SessionId = sesId;
        }
    }
}
