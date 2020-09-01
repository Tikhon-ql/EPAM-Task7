using SessionLibrary.Excel.DataClasses.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.DataClasses
{
    /// <summary>
    /// Student's result class
    /// </summary>
    public class StudentResult
    {
        /// <summary>
        /// Work's date property
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Work's subject property
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Student's name property
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// Student's surname property
        /// </summary>
        public string StudentSurname { get; set; }
        /// <summary>
        /// Student's midle name property
        /// </summary>
        public string StudentMidleName { get; set; }
        /// <summary>
        /// Work's type property
        /// </summary>
        public string WorkType { get; set; }
        /// <summary>
        /// Work's result property
        /// </summary>
        public string Result { get; set; }

        public StudentResult(DateTime date, string subject, string studentName, string studentSurname, string studentMidleName, string workType, string result)
        {
            Date = date;
            Subject = subject;
            StudentName = studentName;
            StudentSurname = studentSurname;
            StudentMidleName = studentMidleName;
            WorkType = workType;
            Result = result;
        }
    }
}
