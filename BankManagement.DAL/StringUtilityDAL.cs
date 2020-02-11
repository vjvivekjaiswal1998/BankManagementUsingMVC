using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagement.DAL
{
    class StringUtilityDAL
    {
        public static string sqlSelectQuery = "Select * from Bank";
        public static string sqlInsertQuery = "insert into Bank values(@AccountNumber,@AccountType,@CustomerName,@CustomerAddress,@CustomerEmail,@CustomerPhoneNumber,@NomineeName)";
        public static string exceptionCaught = "execption caught";
        public static string sqlSelectSingleQuery = "Select * from Bank where Accountnumber = ";
        public static string accountDetailsAddedSuccessfully = "Account Details Added Successfully";

    }
}
