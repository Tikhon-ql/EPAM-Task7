using SessionLibrary.DaoFactory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractUnitTestLib
{
    public abstract class MyUnitTest
    {

        protected SessionFactory factory = SessionFactory.GetInstence(@"Data Source = DESKTOP-7D5VMQO\SQLEXPRESS;Initial Catalog = SessionLibrary_7; Integrated Security = True;");
    }
}
