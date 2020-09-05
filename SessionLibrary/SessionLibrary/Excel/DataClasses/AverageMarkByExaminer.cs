using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.DataClasses
{
    public class AverageMarkByExaminer
    {
        static string sessionName;
        public double AverageMark { get; set; }
        public string ExaminerName { get; set; }
        public AverageMarkByExaminer(double avg, string en)
        {
            AverageMark = avg;
            ExaminerName = en;
        }
        public AverageMarkByExaminer()
        {

        }
        public static void SetSessionName(string ses)
        {
            sessionName = ses;
        }
        public string GetSessionName()
        {
            return sessionName;
        }
    }
}
