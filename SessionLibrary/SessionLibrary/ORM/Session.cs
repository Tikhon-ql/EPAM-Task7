
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Models
{
    public class Session
    {
        public int Id { get; private set; }
        public string AcademicYears { get; set; }
        public int SessionTypeId { get; set; }

        public Session(int id, string academicYears, int sessionTypeId)
        {
            Id = id;
            AcademicYears = academicYears;
            SessionTypeId = sessionTypeId;
        }
        public void GetSessionResults()
        {
           
        }
        ///Итоги сессии
        //select s.Name, s.Surname, s.MidleName, g.GroupName, ss.Date, wt.WorkTypeName, w.Result, sub.SubjectName
        //from Student s,Group g,SessionShedule ss,WorkResult w,WorkType wt,Subject sub
        //where s.Id = w.StudentId and s.GroupId = g.Id and ss.GroupId = g.Id and sub.Id = ss.SubjectId, ss.WorkTypeId = wt.Id

        //select g.GroupName, ,avg(w.Result)
        //from Group g,Student s,WorkResult w
        //
        //group by g.Id
    }
}
