using Choose_lang.Interface;
using Choose_lang.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Choose_lang.Models
{
   public class LangBODB
    {
        SQLiteConnection _objdbConn;
        public LangBODB()
        {
            _objdbConn = DependencyService.Get<ISQLite>().GetConnection();
            // create the table(s)
            _objdbConn.CreateTable<LangBO>();
        }
        public List<LangBO> GetAllLoginReg()
        {
            return _objdbConn.Query<LangBO>("Select * From [LangBO]");
        }
        public int SaveLoginReg(LangBO loginreg)
        {
             

            int x = _objdbConn.Insert(loginreg);
            return x;

        }
        public LangBO ParticularUser(String name)
        {
            // return dbConn.Query<LoginReg>("Select * From [LoginReg] where UserName"+ "=" + name);
            return _objdbConn.Query<LangBO>("SELECT  * FROM  [LoginReg] where EmailId = ?", name).FirstOrDefault();


            //  dbConn.ExecuteScalar<int>("SELECT Count(*) FROM Person WHERE FirstName="Amy");
        }
      
        public void Delete(string name)
        {
            _objdbConn.Delete<LangBO>(name);
        }
        public int EditLoginReg(LangBO loginreg)
        {
            return _objdbConn.Update(loginreg);
        }
    }
}
