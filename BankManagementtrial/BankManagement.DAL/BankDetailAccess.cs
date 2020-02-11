using BankManagement.DTO;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BankManagement.DAL
{
    public class BankDetailAccess : IBankDetailAccess
    {
        private readonly ISqlhelper _sqlhelper;

        public BankDetailAccess(ISqlhelper sqlhelper)
        {
            _sqlhelper = sqlhelper;
            _sqlhelper.EstablishConnection();
        }
       Sqlhelper qlhelper = new Sqlhelper();
        private Boolean boolvalue;
        //static string connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        //SqlDataAdapter dataadapter;    
        //SqlConnection bankdataconn;
        //private static DataTable datatable;
        //SqlCommandBuilder sqlcommandbuilder;
    
       

        //public void FillDetail()
        //{
        //    bankdataconn = new SqlConnection(connect);
        //    string query = StringUtilityDAL.sqlSelectQuery;
        //    dataadapter = new SqlDataAdapter(query, bankdataconn);
        //    sqlcommandbuilder = new SqlCommandBuilder(dataadapter);
        //    datatable = new DataTable();
        //    dataadapter.Fill(datatable);
        //}
        public void AddConstraint()
        {
           Sqlhelper.datatable.Constraints.Add("id", Sqlhelper.datatable.Columns[1], true);
        }
        public DataTable ShowBankDetail()
        {
            try
            {
                _sqlhelper.FillDetail();         
              //  FillDetail();
            }
            catch (Exception e)
            {
                Console.WriteLine(StringUtilityDAL.exceptionCaught + e);
            }
            finally
            {
             //   bankdataconn.Close();
            }
            return Sqlhelper.datatable;
        }
        public DataTable GetSingleAccountDetail(int accountId)
        {
            _sqlhelper.FillDetail();
            //FillDetail();
            string query = StringUtilityDAL.sqlSelectSingleQuery + accountId;
            Sqlhelper.dataadapter = new SqlDataAdapter(query, Sqlhelper.bankdataconn);

            Sqlhelper.datatable = new DataTable();

            Sqlhelper.dataadapter.Fill(Sqlhelper.datatable);
            return Sqlhelper.datatable;
        }
        //To Insert The Detail Of Bank To DataBase
        public void SaveBankDetail(BankDetail bankDetail)
        {
            _sqlhelper.FillDetail();
           // FillDetail();
            try
            {
                // code for disconnected architecture
                
                AddConstraint();
                DataRow dataRow = Sqlhelper.datatable.NewRow();
                dataRow[1] = bankDetail.accountNumber;
                dataRow[2] = bankDetail.accountType;
                dataRow[3] = bankDetail.customerName;
                dataRow[4] = bankDetail.customerAddress;
                dataRow[5] = bankDetail.customerEmail;
                dataRow[6] = bankDetail.customerPhoneNumber;
                dataRow[7] = bankDetail.nomieeName;

                Sqlhelper.datatable.Rows.Add(dataRow);
                Sqlhelper.dataadapter.Update(Sqlhelper.datatable);
                Console.WriteLine(StringUtilityDAL.accountDetailsAddedSuccessfully);
            }
            catch (Exception e)
            {
                Console.WriteLine(StringUtilityDAL.exceptionCaught + e);
            }
            finally
            {
             //   bankdataconn.Close();
            }
        }
        public void UpdateBankAccount(int accountid)
        {
            _sqlhelper.FillDetail();
           // FillDetail();
            AddConstraint();
            if (Sqlhelper.datatable.Rows.Contains(accountid))
            {
                DataRow dataRow =Sqlhelper.datatable.Rows.Find(accountid);
                Console.WriteLine("record found for:");
                dataRow.BeginEdit();
                Console.Write("Enter the updated email of the customer: ");
                dataRow["CustomerEmail"] = Console.ReadLine();
                Console.WriteLine("mark record as updated");
                dataRow.EndEdit();
                Sqlhelper.dataadapter.Update(Sqlhelper.datatable);
                Console.WriteLine("Record has been updated Succesfully");
            }
        }

        public Boolean DeleteBankAccount(int accountId)
        {
            _sqlhelper.FillDetail();
            //FillDetail();
            boolvalue = false;
            try
            {
              
               
               
                Console.WriteLine("Find And Delete");
                AddConstraint();
              
                if (!Sqlhelper.datatable.Rows.Contains(accountId))
                {
                    Console.WriteLine("NO records found");
                }
                else
                {
                    DataRow dataRow = Sqlhelper.datatable.Rows.Find(accountId);
                    Console.WriteLine("record found for:" + dataRow[1] + dataRow[2]);
                    dataRow.Delete();
                    Console.WriteLine("mark record as deleted");
                    Sqlhelper.dataadapter.Update(Sqlhelper.datatable);
                    Console.WriteLine("Record deleted");
                }
                boolvalue = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("execption caught" + e);
            }
        
            return boolvalue;
        }
    }
}
