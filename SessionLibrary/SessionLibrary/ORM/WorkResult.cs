using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Models
{
    public class WorkResult
    {
        public int Id { get; private set; }
        public int StudentId{ get; set; }
        public int SubjectId{ get; set; }
        public string Result { get; set; }
        public int WorkTypeId { get; set; }

        public WorkResult(int id, int student, int subject, string result,int workTypeId)
        {
            Id = id;
            StudentId = student;
            SubjectId = subject;
            Result = result;
            WorkTypeId = workTypeId;
        }
    }
}
