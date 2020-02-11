using BankManagement.DAL;
using BankManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BankManagement.BLL
{
    public class BankManager: IBank
    {
        private readonly IBankDetailAccess _ibankDetaiAccess;
        public BankManager(IBankDetailAccess ibankDetaiAccess)
        {
            _ibankDetaiAccess = ibankDetaiAccess;
        }


        private static DataTable dataTable = new DataTable();
        //private BankDetailAccess _bankDataBase = new BankDetailAccess();
        BankDetail bankDetail = new BankDetail();
  
        public BankDetail AddBankDetail(BankDetail bankDetail)
        {


            ////For only TestCase
            //bankDetail.accountNumber = 1;
            //bankDetail.accountType = "saving";
            //bankDetail.customerAddress = "Valsad";
            //bankDetail.customerEmail = "vj@gmail.com";
            //bankDetail.customerName = "vivek";
            //bankDetail.customerPhoneNumber = "7383559109";
            //bankDetail.nomieeName = "vicky";





            //Console.WriteLine(StringUtilityBLL.accountnumber);
            //bankDetail.AccountNumber = int.Parse(Console.ReadLine());


            //Console.WriteLine(StringUtilityBLL.accounttype);
            //bankDetail.AccountType = Console.ReadLine();

            //Console.WriteLine(StringUtilityBLL.customername);
            //bankDetail.CustomerName = Console.ReadLine();

            //Console.WriteLine(StringUtilityBLL.customeraddress);
            //bankDetail.CustomerAddress = Console.ReadLine();

            //Console.WriteLine(StringUtilityBLL.customeremail);
            //bankDetail.CustomerEmail = Console.ReadLine();

            //Console.WriteLine(StringUtilityBLL.customerphonenumber);
            //bankDetail.CustomerPhoneNumber = Console.ReadLine();

            //Console.WriteLine(StringUtilityBLL.nomineename);
            //bankDetail.NomieeName = Console.ReadLine();
            if (bankDetail.AccountNumber != 0)
            {
                _ibankDetaiAccess.SaveBankDetail(bankDetail);
            }
            else
            {
                Console.WriteLine(StringUtilityBLL.pleaseenterid);
            }
            return bankDetail;
        }
        //original 
        //public List<BankDetail> ShowAllBankDetail()
        //{
        //    dataTable = _ibankDetaiAccess.ShowBankDetail();

        //    foreach (DataColumn columnName in dataTable.Columns)
        //    {
        //        Console.Write(columnName.ColumnName + StringUtilityBLL.tab);
        //    }

        //    // Console.WriteLine(" Account Number,AccountType,\t CustomerName, \t CustomerAddress,   CustomerEmail, CustomerPhoneNumber,  NomineeName");

        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        Console.WriteLine(row[StringUtilityBLL.accountnumberfield] + StringUtilityBLL.tab + row[StringUtilityBLL.accounttypefield] + StringUtilityBLL.tab + row[StringUtilityBLL.customernamefield] + StringUtilityBLL.tab + row[StringUtilityBLL.customeraddressfield] + StringUtilityBLL.tab + row[StringUtilityBLL.customeremailfield] + "\t" + row[StringUtilityBLL.customerphonenumberfield] + StringUtilityBLL.tab + row[StringUtilityBLL.nomineenamefield]);

        //    }
        //    //For only TestCase

        //    //bankDetail.accountNumber = 1;
        //    //bankDetail.accountType = "saving";
        //    //bankDetail.customerAddress = "Valsad";
        //    //bankDetail.customerEmail = "vj@gmail.com";
        //    //bankDetail.customerName = "vivek";
        //    //bankDetail.customerPhoneNumber = "7383559109";
        //    //bankDetail.nomieeName = "vicky";


        //    //bankDetail.accountNumber = 2;
        //    //bankDetail.accountType = "saving";
        //    //bankDetail.customerAddress = "Valsad";
        //    //bankDetail.customerEmail = "vj@gmail.com";
        //    //bankDetail.customerName = "vivek";
        //    //bankDetail.customerPhoneNumber = "7383559109";
        //    //bankDetail.nomieeName = "vicky";
        //    return BankList;
        //}
      

        public List<BankDetail> ShowAllBankDetail()
        {
            dataTable = _ibankDetaiAccess.ShowBankDetail();
            var BankData = new List<BankDetail>();
            foreach (DataRow row in dataTable.Rows)
            {
                BankDetail bankDTO = new BankDetail()
                {
                    AccountNumber = int.Parse(row[StringUtilityBLL.accountnumberfield.ToString()].ToString()),
                    AccountType = row[StringUtilityBLL.accounttypefield.ToString()].ToString(),
                    CustomerName = row[StringUtilityBLL.customernamefield.ToString()].ToString(),
                    NomieeName = row[StringUtilityBLL.nomineenamefield.ToString()].ToString(),
                    CustomerAddress = row[StringUtilityBLL.customeraddressfield.ToString()].ToString(),
                    CustomerEmail = row[StringUtilityBLL.customeremailfield.ToString()].ToString(),
                    CustomerPhoneNumber = row[StringUtilityBLL.customerphonenumberfield.ToString()].ToString(),
                };
                BankData.Add(bankDTO);
            }
            return BankData;
        }

        public void UpdatebankDetail(int AccountId, string CustomerEmail, string CustomerPhoneNumber)
        {
            //int accountId;
            //Console.WriteLine(StringUtilityBLL.enteraccountid);
            //accountId = int.Parse(Console.ReadLine());


            ////For only TestCase
            //int accountId = 1;
            //bankDetail.accountNumber = 1;
            //bankDetail.accountType = "saving";
            //bankDetail.customerAddress = "Valsad";
            //bankDetail.customerEmail = "vj@gmail.com";
            //bankDetail.customerName = "vivek";
            //bankDetail.customerPhoneNumber = "7383559109";
            //bankDetail.nomieeName = "vicky";


            _ibankDetaiAccess.UpdateBankAccount(AccountId,CustomerEmail,CustomerPhoneNumber);
        }
        public void DeleteBankDetail(int accountNumber)
        {
            //int accountId;
            //Console.WriteLine(StringUtilityBLL.enteraccountid);
            //accountId = int.Parse(Console.ReadLine());




            //////For only TestCase
            //int accountId = 1;
            //bankDetail.accountNumber = 1;
            //bankDetail.accountType = "saving";
            //bankDetail.customerAddress = "Valsad";
            //bankDetail.customerEmail = "vj@gmail.com";
            //bankDetail.customerName = "vivek";
            //bankDetail.customerPhoneNumber = "7383559109";
            //bankDetail.nomieeName = "vicky";

            _ibankDetaiAccess.DeleteBankAccount(accountNumber);

        }
        public BankDetail  GetSingleBankAccountDetail(int accountNumber)
        {
            //  int accountId = 1;

            dataTable = _ibankDetaiAccess.GetSingleAccountDetail(accountNumber);
           
           // BankDetail bankDetail = new BankDetail();

            foreach (DataRow row in dataTable.Rows)
            {   
                bankDetail.AccountNumber = int.Parse(row[StringUtilityBLL.accountnumberfield.ToString()].ToString());
                bankDetail.AccountType = row[StringUtilityBLL.accounttypefield.ToString()].ToString();
                bankDetail.CustomerName = row[StringUtilityBLL.customernamefield.ToString()].ToString();
                bankDetail.NomieeName = row[StringUtilityBLL.nomineenamefield.ToString()].ToString();
                bankDetail.CustomerAddress = row[StringUtilityBLL.customeraddressfield.ToString()].ToString();
                bankDetail.CustomerEmail = row[StringUtilityBLL.customeremailfield.ToString()].ToString();
                bankDetail.CustomerPhoneNumber = row[StringUtilityBLL.customerphonenumberfield.ToString()].ToString();
                }           
            return bankDetail;




            //For only TestCase

            //bankDetail.accountNumber = 1;
            //bankDetail.accountType = "saving";
            //bankDetail.customerAddress = "Valsad";
            //bankDetail.customerEmail = "vj@gmail.com";
            //bankDetail.customerName = "vivek";
            //bankDetail.customerPhoneNumber = "7383559109";
            //bankDetail.nomieeName = "vicky";
        }

    }
}
