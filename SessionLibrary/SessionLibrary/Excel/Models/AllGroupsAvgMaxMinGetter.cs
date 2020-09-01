using SessionLibrary.Excel.DataClasses;
using SessionLibrary.Excel.DataClasses.Abstract;
using SessionLibrary.Excel.Enums;
using SessionLibrary.ORM.Another;
using SessionLibrary.ORM.Work;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.Models
{
    /// <summary>
    /// The class, that provide all groups with them average, minimum and maximum results
    /// </summary>
    public class AllGroupsAvgMaxMinGetter : DataClass
    {
        public AllGroupsAvgMaxMinGetter(string connect) : base(connect) { }
        /// <summary>
        /// Get groups with them average, minimum and maximum results method
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GroupsAvgMinMax> GetGroupsAvgMinMax()
        {
            List<GroupsAvgMinMax> results = new List<GroupsAvgMinMax>();
            foreach (Group item in Groups)
            {
                List<WorkResult> groupResults = new List<WorkResult>();
                List<Student> students = Students.Where(s => s.GroupId == item.Id).ToList();
                foreach (Student stud in students)
                {
                    List<WorkResult> workResults = WorkResults.Where(w => w.StudentId == stud.Id).ToList();
                    foreach (WorkResult res in workResults)
                    {
                        if(res.WorkTypeId == 1)
                        {
                            groupResults.Add(res);
                        }
                    }
                }
                if(groupResults.Count != 0)
                    results.Add(new GroupsAvgMinMax(item.GroupName, groupResults.Min(r => Convert.ToInt32(r.Result)), groupResults.Average(r => Convert.ToInt32(r.Result)), groupResults.Max(r => Convert.ToInt32(r.Result))));
            }
            return results;
        }
        /// <summary>
        ///  Get groups with them average, minimum and maximum results with sorting
        /// </summary>
        /// <param name="func">Property for sorting</param>
        /// <param name="stype">Sorting type</param>
        /// <returns></returns>
        public IEnumerable<GroupsAvgMinMax> GetGroupsAvgMinMax(Func<GroupsAvgMinMax,object> func,SortType stype)
        {
            List<GroupsAvgMinMax> results = new List<GroupsAvgMinMax>();
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
                    results.Add(new GroupsAvgMinMax(item.GroupName, groupResults.Min(r => Convert.ToInt32(r.Result)), groupResults.Average(r => Convert.ToInt32(r.Result)), groupResults.Max(r => Convert.ToInt32(r.Result))));
            }
            if (stype == SortType.Ascending)
                results.OrderBy(func);
            else
                results.OrderByDescending(func);
            return results;
        }
    }
}
