using SessionLibrary.Excel.DataClasses;
using SessionLibrary.Excel.DataClasses.Abstract;
using SessionLibrary.Excel.Enums;
using SessionLibrary.ORM.Another;
using SessionLibrary.ORM.Session;
using SessionLibrary.ORM.Work;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.Models
{
    /// <summary>
    /// The class, that provide average marks by specification
    /// </summary>
    public class AverageMarkBySpecificationGetter : DataClass
    {
        public AverageMarkBySpecificationGetter(string connect) : base(connect) { }
        /// <summary>
        /// Get list of average marks method
        /// </summary>
        public IEnumerable<AverageMarkBySpecification> GetAverageMark(int sesId)
        {
            Session currentSession = Sessions.FirstOrDefault(s => s.Id == sesId);
            List<AverageMarkBySpecification> results = new List<AverageMarkBySpecification>();
            AverageMarkBySpecification.SetSessionName($"Session({currentSession.AcademicYears})");
            foreach(Specification spec in Specifications)
            {
                List<Group> groups = Groups.Where(g => g.SpecificationId == spec.Id).ToList();
                foreach (Group item in groups)
                {
                    List<WorkResult> groupResults = new List<WorkResult>();
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
                        AverageMarkBySpecification average = new AverageMarkBySpecification();
                        average.AverageMark = Math.Round(groupResults.Average(i => Convert.ToInt32(i.Result)), 2);
                        average.Specifcation = Specifications.FirstOrDefault(s => s.Id == item.SpecificationId).SpecificationName;
                        results.Add(average);
                        groupResults.Clear();
                    }
                }
            }
           
            return results;
        }
        /// <summary>
        /// Get sorted list of average marks method
        /// </summary>
        /// <param name="sesId">Session's id</param>
        /// <param name="func">Property for sorting</param>
        /// <param name="type">Sorting type</param>
        /// <returns></returns>
        public IEnumerable<AverageMarkBySpecification> GetAverageMark(int sesId,Func<AverageMarkBySpecification,object>func,SortType type)
        {
            Session currentSession = Sessions.FirstOrDefault(s => s.Id == sesId);
            List<AverageMarkBySpecification> results = new List<AverageMarkBySpecification>();
            AverageMarkBySpecification.SetSessionName($"Session({currentSession.AcademicYears})");
            foreach (Group item in Groups)
            {

                List<WorkResult> groupResults = new List<WorkResult>();
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
                    AverageMarkBySpecification average = new AverageMarkBySpecification();
                    average.AverageMark = Math.Round(groupResults.Average(i => Convert.ToInt32(i.Result)), 2);
                    average.Specifcation = Specifications.FirstOrDefault(s => s.Id == item.SpecificationId).SpecificationName;
                    results.Add(average);
                    groupResults.Clear();
                }
            }
            if (type == SortType.Ascending)
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
