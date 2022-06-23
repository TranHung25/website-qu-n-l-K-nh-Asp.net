using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanly.Areas.Admin.model.DAO
{
    public class account
    {
        private static Models.framework.QuanlyEntities db = new Models.framework.QuanlyEntities();
        public account()
        {

        }
        public static int checkLoginUS(string username, string password)
        {
            // Hash password before check
            int num = db.accounts.Count(x => x.username == username && x.password == password);
            if (num > 0) { return 1; }
            else
                return 0;
        }
    }
}