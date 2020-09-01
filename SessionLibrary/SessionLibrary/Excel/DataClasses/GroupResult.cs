using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.DataClasses
{
    /// <summary>
    /// Results by group class 
    /// </summary>
    public class GroupResult
    {
        /// <summary>
        /// Group's name property
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// List of results property
        /// </summary>
        public ICollection<StudentResult> StudentResults { get; set; }
        public GroupResult(string groupName)
        {
            GroupName = groupName;
            StudentResults = new List<StudentResult>();
        }
    }
}
