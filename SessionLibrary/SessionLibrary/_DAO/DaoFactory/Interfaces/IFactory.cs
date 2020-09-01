using SessionLibrary._DAO.Interface;
using SessionLibrary._DAO.Models;
using SessionLibrary.ORM.Another;
using SessionLibrary.ORM.Session;
using SessionLibrary.ORM.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.DaoFactory.Interfaces
{
    /// <summary>
    /// Factory's interface
    /// </summary>
    public interface IFactory
    {
        /// <summary>
        /// Get student's creator method
        /// </summary>
        /// <returns></returns>
        IDao<Student> GetStudentCreator();
        /// <summary>
        /// Get gender's creator method
        /// </summary>
        /// <returns></returns>
        IDao<Gender> GetGenderCreator();
        /// <summary>
        /// Get group's creator method
        /// </summary>
        /// <returns></returns>
        IDao<Group> GetGroupCreator();
        /// <summary>
        /// Get session's creator method
        /// </summary>
        /// <returns></returns>
        IDao<Session> GetSessionCreator();
        /// <summary>
        /// Get session shedule's creator method
        /// </summary>
        /// <returns></returns>
        IDao<SessionShedule> GetSessionSheduleCreator();
        /// <summary>
        /// Get work result's creator method
        /// </summary>
        /// <returns></returns>
        IDao<WorkResult> GetWorkResultCreator();
        /// <summary>
        /// Get work type's creator method
        /// </summary>
        /// <returns></returns>
        IDao<WorkType> GetWorkTypeCreator();
        /// <summary>
        /// Get subject's creator method
        /// </summary>
        /// <returns></returns>
        IDao<Subject> GetSubjectCreator();
        /// <summary>
        /// Get session type's creator method
        /// </summary>
        /// <returns></returns>
        IDao<SessionType> GetSessionTypeCreator();
    }
}
