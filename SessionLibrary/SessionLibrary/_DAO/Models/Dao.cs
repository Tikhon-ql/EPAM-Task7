
using SessionLibrary._DAO.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary._DAO.Models
{
    /// <summary>
    /// Dao's class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Dao<T> : IDao<T>
    {
        /// <summary>
        /// Connection string 
        /// </summary>
        private string connectionString;
        public Dao(string str)
        {
            connectionString = str;
        }
        public bool Create(T value)
        {
            //try
            //{
                using (SqlConnection cnn = new SqlConnection())
                {
                    cnn.ConnectionString = connectionString;
                    Type type = value.GetType();
                    PropertyInfo[] infos = type.GetProperties();
                    SqlCommand command = new SqlCommand();
                    command.Connection = cnn;
                    string values = "";
                    string columns = "";
                    foreach (PropertyInfo item in infos)
                    {
                        command.Parameters.AddWithValue("@" + item.Name, item.GetValue(value));
                        if (columns != "")
                            columns += "," + item.Name;
                        else
                            columns += item.Name;
                        if (values != "")
                            values += ",@" + item.Name;
                        else
                            values += "@" + item.Name;
                    }
                    command.CommandText = $"insert into [{type.Name}] (" + columns + ")" + " values(" + values + ")";
                    cnn.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            //}
            //catch
            //{
            //    return false;
            //}
        }

        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection())
                {
                    cnn.ConnectionString = connectionString;
                    Type type = typeof(T);
                    SqlCommand command = new SqlCommand($"delete from [{type.Name}] where Id = @id", cnn);
                    command.Parameters.AddWithValue("@id", id);
                    cnn.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public T Read(int id)
        {
            using (SqlConnection cnn = new SqlConnection())
            {
                cnn.ConnectionString = connectionString;
                Type type = typeof(T);
                /////
                SqlCommand command = new SqlCommand($"select * from [{type.Name}] where Id = @id", cnn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@table", type.Name);
                cnn.Open();
                List<object> _params = new List<object>();
                using (SqlDataReader sdr = command.ExecuteReader())
                {
                    sdr.Read();
                    for (int i = 0; i < sdr.FieldCount; i++)
                        _params.Add(sdr[i]);
                }
                ////
                return (T)Activator.CreateInstance(typeof(T), _params.ToArray());
            }
        }

        public bool Update(T value)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection())
                {
                    cnn.ConnectionString = connectionString;
                    Type type = typeof(T);
                    PropertyInfo[] infos = type.GetProperties();
                    SqlCommand command = new SqlCommand();
                    command.Connection = cnn;
                    //PropertyInfo id = type.GetProperty("Id");
                    string setters = "";
                    foreach (PropertyInfo item in infos)
                    {
                        command.Parameters.AddWithValue("@" + item.Name, item.GetValue(value).ToString());
                        if (setters != "")
                            setters += ", " + item.Name + " = @" + item.Name;
                        else
                            setters += item.Name + " = @" + item.Name;
                    }
                    command.CommandText = $"update [{type.Name}] set {setters} where Id = @id";
                    cnn.Open();
                    //Invalid column Andrey
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public ICollection<T> GetAll()
        {
            using (SqlConnection cnn = new SqlConnection())
            {
                ICollection<T> list = new List<T>();
                cnn.ConnectionString = connectionString;
                Type type = typeof(T);
                PropertyInfo[] infos = type.GetProperties();
                SqlCommand command = new SqlCommand("select * from [" + type.Name + "]", cnn);
                cnn.Open();
                List<object> _params = new List<object>();
                using (SqlDataReader sdr = command.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        for (int i = 0; i < sdr.FieldCount; i++)
                        {
                            _params.Add(sdr.GetValue(i));
                        }
                        list.Add((T)Activator.CreateInstance(typeof(T), _params.ToArray()));
                        _params.Clear();
                    }
                }
                return list;
            }
        }
    }
}
