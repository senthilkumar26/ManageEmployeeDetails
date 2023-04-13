using System;
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
        public static string FilePath = @"C:\Users\senth\source\repos\ManageEmployeeDetails\ManageEmployeeDetails\bin\Debug\CSVFile\test.csv";
        #endregion
        #region Token
        public static string Token = "fall4107311259f5f33e70a5d85de34a2499b4401da69af0b1d835cd5ec0d56";
        #endregion
    }
}
