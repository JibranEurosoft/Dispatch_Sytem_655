using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI
{
     public class UserRights
    {
        public int? moduleId;
        public string moduleName;
        public int? formId;
        public string formName;
        public string formTitle;
        public long? formFunctionId;
        public string functionId;
        public bool status;
        public string formType;

        public static UserRights GetUserRights(long formId, long functionId, LoginUser loginObj)
        {
            UserRights rights = new UserRights();
            return rights;

        }

        public static List<UserRights> GetUserRightsCollection(LoginUser loginObj)
        {
            List<UserRights> usrRights = new List<UserRights>();
          

            return usrRights;
        }
    }
}
