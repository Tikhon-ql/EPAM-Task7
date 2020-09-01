using SessionLibrary._DAO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Models
{
    public class Group
    {
        public int Id { get; private set; }
        public string GroupName { get; set; }

        public Group(int id, string groupName)
        {
            Id = id;
            GroupName = groupName;
        }
        public static List<Student> GetDropOutStudents(int groupId)
        {
            using (SqlConnection cnn = new SqlConnection())
            {
                SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
                stringBuilder.DataSource = @"(localdb)\mssqllocaldb";
                stringBuilder.InitialCatalog = "SessionLibrary";
                stringBuilder.IntegratedSecurity = true;
                cnn.ConnectionString = stringBuilder.ConnectionString;
                SqlCommand command = new SqlCommand();
                //command.CommandText = "select s.Id from Student s,WorkResult w,Group g where " +
                //                      "s.GroupId = @grId and g.Id = s.GroupId and s.Id = w.StudentId and " +
                //                      "(w.Result = `false` || w.Result <= 3) group by g.Id";
                command.Parameters.AddWithValue("@grId", groupId);
                List<int> ids = new List<int>();
                cnn.Open();
                using (SqlDataReader sdr = command.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        ids.Add(Convert.ToInt32(sdr[0]));
                    }
                }
                List<Student> students = new List<Student>();
                DAO<Student> dao = new DAO<Student>(new SqlConnectionStringBuilder());
                foreach (int id in ids)
                {
                    students.Add(dao.Read(id));
                }
                return students;
            }
        }
    }
}
