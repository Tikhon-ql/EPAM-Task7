using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.DataClasses
{
    public class AverageMarkBySubject
    {
        public string SubjectName { get; set; }
        public double AverageMark { get; set; }

        public AverageMarkBySubject(string subjectName, double averageMark)
        {
            SubjectName = subjectName;
            AverageMark = averageMark;
        }
    }
}
