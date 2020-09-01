using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Models
{
    public class WorkType
    {
        public int Id { get; private set; }
        public string WorkTypeName { get; set; }

        public WorkType(int id, string workTypeName)
        {
            Id = id;
            WorkTypeName = workTypeName;
        }
    }
}
