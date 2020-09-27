using SessionLibrary.Excel.DataClasses;
using SessionLibrary.Excel.DataClasses.Abstract;
using SessionLibrary.Excel.Enums;
using SessionLibrary.ORM.Another;
using SessionLibrary.ORM.Session;
using SessionLibrary.ORM.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.Models
{
    /// <summary>
    /// The class, that provide average marks by subject
    /// </summary>
    public class AverageMarksBySubjectsGetter : DataClass
    {
        public AverageMarksBySubjectsGetter(string connect):base(connect){  }
        /// <summary>
        /// Get list of average marks method
        /// </summary>
        public ICollection<AverageMarksBySubjectsInOneYear> GetAverageMarks()
        {
            List<AverageMarksBySubjectsInOneYear> result = new List<AverageMarksBySubjectsInOneYear>();
            foreach(Session ses in Sessions)
            {
                AverageMarksBySubjectsInOneYear oneYear = new AverageMarksBySubjectsInOneYear();
                oneYear.Year = ses.AcademicYears;
                foreach (Subject item in Subjects)
                {
                    List<WorkResult> wresults = WorkResults.Where(w => w.SubjectId == item.Id).ToList();
                    double sum = 0;
                    int count = 0;
                    foreach (WorkResult res in wresults)
                    {
                        if (int.TryParse(res.Result, out int a))
                        {
                            sum += a;
                            count++;
                        }
                    }
                    if (count != 0)
                    {
                        double average = sum / count;
                        oneYear.AverageMarks.Add(new AverageMarkBySubject(item.SubjectName, Math.Round(average, 2)));
                    }
                }
                result.Add(oneYear);
            }
            return result;
        }
        /// <summary>
        /// Get list of average marks method
        /// </summary>
        /// <param name="func">Property for sorting</param>
        /// <param name="type">Sorting type</param>
        /// <returns></returns>
        public ICollection<AverageMarksBySubjectsInOneYear> GetAverageMarks(Func<AverageMarkBySubject,object> func,SortType type)
        {
            List<AverageMarksBySubjectsInOneYear> result = new List<AverageMarksBySubjectsInOneYear>();
            foreach (Session ses in Sessions)
            {
                AverageMarksBySubjectsInOneYear oneYear = new AverageMarksBySubjectsInOneYear();
                oneYear.Year = ses.AcademicYears;
                foreach (Subject item in Subjects)
                {
                    List<WorkResult> wresults = WorkResults.Where(w => w.SubjectId == item.Id).ToList();
                    double sum = 0;
                    int count = 0;
                    foreach (WorkResult res in wresults)
                    {
                        if (int.TryParse(res.Result, out int a))
                        {
                            sum += a;
                            count++;
                        }
                    }
                    if (count != 0)
                    {
                        double average = sum / count;
                        oneYear.AverageMarks.Add(new AverageMarkBySubject(item.SubjectName, Math.Round(average, 2)));
                    }
                }
                result.Add(oneYear);
            }
            List<AverageMarksBySubjectsInOneYear> r = new List<AverageMarksBySubjectsInOneYear>();
            if (type == SortType.Ascending)
            {
                foreach(AverageMarksBySubjectsInOneYear item in result)
                {
                    r.Add(new AverageMarksBySubjectsInOneYear(item.Year, item.AverageMarks.OrderBy(func).ToArray()));
                }
            }
            else
            {
                foreach (AverageMarksBySubjectsInOneYear item in result)
                {
                    r.Add(new AverageMarksBySubjectsInOneYear(item.Year, item.AverageMarks.OrderByDescending(func).ToArray()));
                }
            }
            return r;
        }
    }
}
