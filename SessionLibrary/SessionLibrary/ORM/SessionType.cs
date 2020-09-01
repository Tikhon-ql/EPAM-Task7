using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Models
{
    public class SessionType
    {
        public int Id { get; private set; }
        public string SessionTypeName { get; set; }

        public SessionType(int id, string sessionTypeName)
        {
            Id = id;
            SessionTypeName = sessionTypeName;
        }
    }
}
