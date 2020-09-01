using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.DataClasses
{
    /// <summary>
    /// The class, tha stores the group's name and the group's average, minimum and maximum results
    /// </summary>
    public class GroupsAvgMinMax
    {
        /// <summary>
        /// Group's name property
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// Group's minimum result property
        /// </summary>
        public double Min { get; set; }
        /// <summary>
        /// Group's average result property
        /// </summary>
        public double Avg { get; set; }
        /// <summary>
        /// Group's maximum result property
        /// </summary>
        public double Max { get; set; }

        public GroupsAvgMinMax(string groupName, double min, double avg, double max)
        {
            GroupName = groupName;
            Min = min;
            Avg = Math.Round(avg,2);
            Max = max;
        }
    }
}
