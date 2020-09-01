using SessionLibrary.DaoFactory.Models;
using SessionLibrary.ORM.Another;
using SessionLibrary.ORM.Session;
using SessionLibrary.ORM.Work;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.DataClasses.Abstract
{
    /// <summary>
    /// All data haver's abstract class 
    /// </summary>
    public abstract class DataClass
    {
        /// <summary>
        /// All students
        /// </summary>
        public ICollection<Student> Students { get; set; }
        /// <summary>
        /// All groups
        /// </summary>
        public ICollection<Group> Groups { get; set; }
        /// <summary>
        /// All genders
        /// </summary>
        public ICollection<Gender> Genders { get; set; }
        /// <summary>
        /// All session shedules
        /// </summary>
        public ICollection<SessionShedule> SessionShedules { get; set; }
        /// <summary>
        /// All work types
        /// </summary>
        public ICollection<WorkType> WorkTypes { get; set; }
        /// <summary>
        /// All work results
        /// </summary>
        public ICollection<WorkResult> WorkResults { get; set; }
        /// <summary>
        /// All subjects
        /// </summary>
        public ICollection<Subject> Subjects { get; set; }
        /// <summary>
        /// All sessions
        /// </summary>
        public ICollection<Session> Sessions { get; set; }
        /// <summary>
        /// All session types
        /// </summary>
        public ICollection<SessionType> SessionTypes { get; set; }
        public DataClass(string connect)
        {
            SessionFactory factory = SessionFactory.GetInstence(connect);
            Students = factory.GetStudentCreator().GetAll();
            Groups = factory.GetGroupCreator().GetAll();
            Sessions = factory.GetSessionCreator().GetAll();
            Genders = factory.GetGenderCreator().GetAll();
            WorkResults = factory.GetWorkResultCreator().GetAll();
            WorkTypes = factory.GetWorkTypeCreator().GetAll();
            Subjects = factory.GetSubjectCreator().GetAll();
            SessionTypes = factory.GetSessionTypeCreator().GetAll();
            SessionShedules = factory.GetSessionSheduleCreator().GetAll();
        }
    }
}
