using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace SessionLibrary.Models
{
    public class Subject
    {
        public int Id { get; private set; }
        public string SubjectName { get; set; }

        public Subject(int id, string subjectName)
        {
            Id = id;
            SubjectName = subjectName;
        }
    }
}