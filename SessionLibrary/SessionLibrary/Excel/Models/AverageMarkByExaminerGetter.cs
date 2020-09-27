using SessionLibrary.Excel.DataClasses;
using SessionLibrary.Excel.DataClasses.Abstract;
using SessionLibrary.Excel.Enums;
using SessionLibrary.ORM.Another;
using SessionLibrary.ORM.Session;
using SessionLibrary.ORM.Work;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.Models
{
    /// <summary>
    /// The class, that provide average marks by examiner
    /// </summary>
    public class AverageMarkByExaminerGetter:DataClass
    {
        public AverageMarkByExaminerGetter(string connect):base(connect) { }
        /// <summary>
        /// Get list of average marks method
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AverageMarkByExaminer> GetAverageMark(int sesId)
        {
            Session currentSession = Sessions.FirstOrDefault(s => s.Id == sesId);
            List<SessionShedule> shedules = SessionShedules.Where(s => s.SessionId == currentSession.Id).ToList();
            List<AverageMarkByExaminer> results = new List<AverageMarkByExaminer>();
            AverageMarkByExaminer.SetSessionName($"Session({currentSession.AcademicYears})");
            foreach (SessionShedule item in shedules)
            {
                Group group = Groups.FirstOrDefault(g => g.Id == item.GroupId);
                List<WorkResult> groupResults = new List<WorkResult>();
                List<Student> students = Students.Where(s => s.GroupId == group.Id).ToList();
                foreach (Student stud in students)
                {
                    List<WorkResult> workResults = WorkResults.Where(w => w.StudentId == stud.Id).ToList();
                    foreach (WorkResult res in workResults)
                    {
                        if (res.WorkTypeId == 1)
                        {
                            groupResults.Add(res);
                        }
                    }
                }
                if (groupResults.Count != 0)
                {
                    AverageMarkByExaminer average = new AverageMarkByExaminer();
                    average.AverageMark = Math.Round(groupResults.Average(i => Convert.ToInt32(i.Result)), 2);
                    average.ExaminerName = Examiners.FirstOrDefault(s => s.Id == item.ExaminerId).Name;
                    results.Add(average);
                    groupResults.Clear();
                }
            }
            return results;
        }
        /// <summary>
        /// Get sorted list of average marks method with
        /// </summary>
        /// <param name="sesId">Session's id</param>
        /// <param name="func">Property for sorting</param>
        /// <param name="type">Sorting type</param>
        /// <returns></returns>
        public IEnumerable<AverageMarkByExaminer> GetAverageMark(int sesId,Func<AverageMarkByExaminer,object> func,SortType type)
        {
            Session currentSession = Sessions.FirstOrDefault(s => s.Id == sesId);
            List<SessionShedule> shedules = SessionShedules.Where(s => s.SessionId == currentSession.Id).ToList();
            List<AverageMarkByExaminer> results = new List<AverageMarkByExaminer>();
            AverageMarkByExaminer.SetSessionName($"Session({currentSession.AcademicYears})");
            foreach (SessionShedule item in shedules)
            {
                List<Group> groups = Groups.Where(g => g.Id == item.GroupId).ToList();
                List<WorkResult> groupResults = new List<WorkResult>();
                foreach (Group group in groups)
                {
                    List<Student> students = Students.Where(s => s.GroupId == item.Id).ToList();
                    foreach (Student stud in students)
                    {
                        List<WorkResult> workResults = WorkResults.Where(w => w.StudentId == stud.Id).ToList();
                        foreach (WorkResult res in workResults)
                        {
                            if (res.WorkTypeId == 1)
                            {
                                groupResults.Add(res);
                            }
                        }
                    }
                    if (groupResults.Count != 0)
                    {
                        AverageMarkByExaminer average = new AverageMarkByExaminer();
                        average.AverageMark = Math.Round(groupResults.Average(i => Convert.ToInt32(i.Result)), 2);
                        average.ExaminerName = Examiners.FirstOrDefault(s => s.Id == item.ExaminerId).Name;
                        results.Add(average);
                        groupResults.Clear();
                    }
                }
            }
            if(type == SortType.Ascending)
            {
                return results.OrderBy(func);
            }
            else
            {
                return results.OrderByDescending(func);
            }
        }
    }
}
