using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.DataClasses
{
    /// <summary>
    /// The class, that stores the group's name and the list of students to drop out
    /// </summary>
    public class DropOutStudentsByGroup
    {
        /// <summary>
        /// Group's name property
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// List of students to drop out property
        /// </summary>
        public List<DropoutStudent> DropoutStudent { get; set; }
        public DropOutStudentsByGroup(string groupName)
        {
            GroupName = groupName;
            DropoutStudent = new List<DropoutStudent>();
        }
    }
}
