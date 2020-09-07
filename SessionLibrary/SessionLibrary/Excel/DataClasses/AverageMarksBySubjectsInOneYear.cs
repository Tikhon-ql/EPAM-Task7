using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.DataClasses
{
    public class AverageMarksBySubjectsInOneYear
    {
        public string Year { get; set; }
        public List<AverageMarkBySubject> AverageMarks { get; set; } = new List<AverageMarkBySubject>();
        public AverageMarksBySubjectsInOneYear(string year, params AverageMarkBySubject[] averages)
        {
            Year = year;
            AverageMarks = averages.ToList();
        }
        public AverageMarksBySubjectsInOneYear()
        {

        }
    }
}
