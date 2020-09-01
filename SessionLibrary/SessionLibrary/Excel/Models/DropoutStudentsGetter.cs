using SessionLibrary.Excel.DataClasses;
using SessionLibrary.Excel.DataClasses.Abstract;
using SessionLibrary.Excel.Enums;
using SessionLibrary.ORM.Another;
using SessionLibrary.ORM.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.Models
{
    /// <summary>
    /// Dropout students getter 
    /// </summary>
    public class DropoutStudentsGetter : DataClass
    {
        public DropoutStudentsGetter(string connect) : base(connect) { }
        /// <summary>
        /// Get dropout students method
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DropOutStudentsByGroup> GetExpelStudents()
        {
            List<DropOutStudentsByGroup> result = new List<DropOutStudentsByGroup>();
            foreach(Group group in Groups)
            {
                DropOutStudentsByGroup expel = new DropOutStudentsByGroup(group.GroupName);
                List<Student> students = Students.Where(s => s.GroupId == group.Id).ToList();
                foreach(Student stud in students)
                {
                    List<WorkResult> workResults = WorkResults.Where(w => w.StudentId == stud.Id).ToList();
                    foreach(WorkResult res in workResults)
                    {
                        if(res.WorkTypeId == 1)
                        {
                            if(int.Parse(res.Result) <= 3)
                            {
                                expel.DropoutStudent.Add(new DropoutStudent(stud.Name, stud.Surname, stud.MidleName));
                                break;
                            }
                        }
                        else
                        {
                            if(res.Result == "Uncredit")
                            {
                                expel.DropoutStudent.Add(new DropoutStudent(stud.Name, stud.Surname, stud.MidleName));
                                break;
                            }
                        }
                    }
                }
                result.Add(expel);
            }
            return result;
        }
        /// <summary>
        /// Get dropout students with sorting
        /// </summary>
        /// <param name="func">Propert for sorting</param>
        /// <param name="stype">Sorting type</param>
        /// <returns></returns>
        public IEnumerable<DropOutStudentsByGroup> GetExpelStudents(Func<DropoutStudent,object> func,SortType stype)
        {
            List<DropOutStudentsByGroup> result = new List<DropOutStudentsByGroup>();
            foreach (Group group in Groups)
            {
                DropOutStudentsByGroup expel = new DropOutStudentsByGroup(group.GroupName);
                List<Student> students = Students.Where(s => s.GroupId == group.Id).ToList();
                foreach (Student stud in students)
                {
                    List<WorkResult> workResults = WorkResults.Where(w => w.StudentId == stud.Id).ToList();
                    foreach (WorkResult res in workResults)
                    {
                        if (res.WorkTypeId == 1)
                        {
                            if (int.Parse(res.Result) <= 3)
                            {
                                expel.DropoutStudent.Add(new DropoutStudent(stud.Name, stud.Surname, stud.MidleName));
                                break;
                            }
                        }
                        else
                        {
                            if (res.Result == "Uncredit")
                            {
                                expel.DropoutStudent.Add(new DropoutStudent(stud.Name, stud.Surname, stud.MidleName));
                                break;
                            }
                        }
                    }
                }
                result.Add(expel);
            }
            if (stype == SortType.Ascending)
            {
                foreach(DropOutStudentsByGroup item in result)
                {
                    item.DropoutStudent.OrderBy(func);
                }
            }
            else
            {
                foreach (DropOutStudentsByGroup item in result)
                {
                    item.DropoutStudent.OrderByDescending(func);
                }
            }
            return result;
        }
    }
}
