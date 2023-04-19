using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageEmployeeDetails.Common
{
  public static  class Constant
    {
        #region Error Message
       public static string EmployeeIDError = "Please Enter EmployeeID..!";
        public static string EmployeeNameError = "Please Enter EmployeeName..!";
        public static string EmployeeEmailError = "Please Enter EmailID..!";
        public static string EmployeeStatusError = "Please Enter Status..!";
        public static string EmployeeGenderError = "Please Select Gender..!";
        public static string MessageBoxCaption = "Alert";
        #endregion
        #region Gender Status
        public static string EmployeeGender = "male";
        public static string EmployeeGenders = "female";
        #endregion
        #region FilePath
        public static string FilePath = Directory.GetCurrentDirectory() +"\\EmployeeDetails.csv";
        #endregion
        #region Token
        public static string Token = "bb06c4f8b4896fa675d458e96b117167fbb8e1ca86028ec7c6d6ff744e96b932";
        #endregion
    }
}
