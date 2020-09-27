using SessionLibrary.Excel.DataClasses;
using SessionLibrary.Excel.DataClasses.Abstract;
using SessionLibrary.Excel.Enums;
using SessionLibrary.ORM.Another;
using SessionLibrary.ORM.Session;
using SessionLibrary.ORM.Work;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.Models
{
    /// <summary>
    /// The class, that get sessin results 
    /// </summary>
    public class SessionResultGetter:DataClass
    {
        public SessionResultGetter(string connect):base(connect){ }
        /// <summary>
        /// Get session results method
        /// </summary>
        /// <param name="sessionId">Session id</param>
        /// <returns></returns>
        public ICollection<GroupResult> GetSessionResult(int sessionId)
        {
            List<GroupResult> results = new List<GroupResult>();
            foreach(Group group in Groups)
            {
                GroupResult result = new GroupResult(group.GroupName);
                List<Student> students = Students.Where(s => s.GroupId == group.Id).ToList();
                foreach(Student student in students)
                {
                    List<WorkResult> workResults = WorkResults.Where(w => w.StudentId == student.Id).ToList();
                    foreach(WorkResult item in workResults)
                    {
                        SessionShedule shedule = SessionShedules.FirstOrDefault(s => s.Id == item.SessionSheduleId && s.SessionId == sessionId);
                        Subject subject = Subjects.FirstOrDefault(s => s.Id == item.SubjectId);
                        WorkType type = WorkTypes.FirstOrDefault(w => w.Id == item.WorkTypeId);
                        if (shedule != null && shedule != null && type != null)
                            result.StudentResults.Add(new StudentResult(shedule.Date,subject.SubjectName,student.Name,student.Surname,student.MidleName,type.WorkTypeName,item.Result));
                    }
                }
                
                results.Add(result);
            }
            return results;
        }
        /// <summary>
        /// Get session results with sorting
        /// </summary>
        /// <param name="sessionId">Session's id</param>
        /// <param name="func">Property for sorting</param>
        /// <param name="stype">Sorting type</param>
        /// <returns></returns>
        public ICollection<GroupResult> GetSessionResult(int sessionId,Func<StudentResult,object> func,SortType stype)
        {
            List<GroupResult> results = new List<GroupResult>();
            foreach (Group group in Groups)
            {
                GroupResult result = new GroupResult(group.GroupName);
                List<Student> students = Students.Where(s => s.GroupId == group.Id).ToList();
                foreach (Student student in students)
                {
                    List<WorkResult> workResults = WorkResults.Where(w => w.StudentId == student.Id).ToList();
                    foreach (WorkResult item in workResults)
                    {
                        SessionShedule shedule = SessionShedules.FirstOrDefault(s => s.Id == item.SessionSheduleId && s.SessionId == sessionId);
                        Subject subject = Subjects.FirstOrDefault(s => s.Id == item.SubjectId);
                        WorkType type = WorkTypes.FirstOrDefault(w => w.Id == item.WorkTypeId);
                        if (shedule != null && shedule != null && type != null)
                            result.StudentResults.Add(new StudentResult(shedule.Date, subject.SubjectName, student.Name, student.Surname, student.MidleName, type.WorkTypeName, item.Result));
                    }
                }
                results.Add(result);
            }
            List<GroupResult> res = new List<GroupResult>();
            if (stype == SortType.Ascending)
            {
                foreach (GroupResult item in results)
                {
                    res.Add(new GroupResult(item.GroupName, item.StudentResults.OrderBy(func).ToList()));
                }
            }
            else
                foreach (GroupResult item in results)
                {
                    res.Add(new GroupResult(item.GroupName, item.StudentResults.OrderByDescending(func).ToArray()));
                }
            return res;
        }
    }
}
