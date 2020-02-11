using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Configuration;

namespace BankManagement.DAL
{
    public class Sqlhelper : ISqlhelper
    {
        ////   SqlConnection bankdataconn = new SqlConnection(@"Data Source=CS68-PC\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");

        //public void OpenDataBaseConnection()
        //{
        //    bankdataconn.Open();
        //}
        //public void CloseDataBaseConnection()
        //{
        //    bankdataconn.Close();
        //}
        public static  SqlDataAdapter dataadapter;
        public static SqlConnection bankdataconn;
        public static DataTable datatable;
        public static SqlCommandBuilder sqlcommandbuilder;

        public void EstablishConnection()
        {
            //  bankdataconn = new SqlConnection(@"Data Source=CS68-PC\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True");
             string connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            bankdataconn = new SqlConnection(connect);
        }

        public  DataTable  FillDetail()
        {
          //  bankdataconn = new SqlConnection(connect);
            string query = StringUtilityDAL.sqlSelectQuery;
            dataadapter = new SqlDataAdapter(query, bankdataconn);
            sqlcommandbuilder = new SqlCommandBuilder(dataadapter);
            datatable = new DataTable();
          dataadapter.Fill(datatable);
            return datatable;
        }

    }
}
