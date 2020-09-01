using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary._DAO.Interface
{
    /// <summary>
    /// Dao class's interface
    /// </summary>
    /// <typeparam name="T">Generic</typeparam>
    public interface IDao<T>
    {
        /// <summary>
        /// Create generic's object  method
        /// </summary>
        /// <param name="value">Object</param>
        /// <returns></returns>
        bool Create(T value);
        /// <summary>
        /// Get generic's object method
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object's id</returns>
        T Read(int id);
        /// <summary>
        /// Delete generic's object method
        /// </summary>
        /// <param name="id">Object's id</param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// Update recording in database method
        /// </summary>
        /// <param name="value">Object</param>
        /// <returns></returns>
        bool Update(T value);
        /// <summary>
        /// Get all recording in generic's table
        /// </summary>
        /// <returns></returns>
        ICollection<T> GetAll();
    }
}
