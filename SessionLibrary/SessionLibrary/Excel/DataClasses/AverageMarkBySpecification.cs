using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.DataClasses
{
    public class AverageMarkBySpecification
    {
        static string sessionName;
        public double AverageMark { get; set; }
        public string Specifcation { get; set; }
        public AverageMarkBySpecification(double avg, string spec)
        {
            AverageMark = avg;
            Specifcation = spec;
        }
        public AverageMarkBySpecification()
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
