using BankManagement.DAL;
using BankManagement.DTO;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Xunit;

namespace BankManagementUnitTest
{
    public class BankManagementUnitTestDAL
    {
        //[Fact]
        //public void To_Check_SaveBankDetail_of_Account_is_working()
        //{

        //   // //Arrange
        //   // var sqlHelper= new Mock<ISqlhelper>();
        //   // sqlHelper.Setup(x => x.FillDetail());
        //    BankDetailAccess bankDetailAccess = new BankDetailAccess();                  

        //   // //Act
        //    bankDetailAccess.SaveBankDetail(bd);

        //   // // Assert
        //   // // Assert.Equal(bd,bankdetail);

        //   // sqlHelper.VerifyAll();
        //   //// Assert.Equal("Added",);
        // //  bankDetailAccess.
        //}
    

        [Fact]
        public void To_Check_selection_of_Account_is_working()
        {

            // //Arrange
            DataTable dataTable = new DataTable();
            var sqlHelper= new Mock<ISqlhelper>();
            sqlHelper.Setup(x => x.FillDetail()).Returns(DataOfBank);
            sqlHelper.Setup(x => x.EstablishConnection());
          
            BankDetailAccess bankDetailAccess = new BankDetailAccess(sqlHelper.Object);
           
          
            int i=1;
            // //Act
          dataTable = bankDetailAccess.GetSingleAccountDetail(i);

            // // Assert
            sqlHelper.VerifyAll();
          //  Assert.NotNull(dataTable);
          
        }
        [Fact]
        public void To_Check_Selection_of_All_Account_is_working()
        {

            // //Arrange
            DataTable dataTable = new DataTable();
            var sqlHelper = new Mock<ISqlhelper>();
            sqlHelper.Setup(x => x.FillDetail());
            sqlHelper.Setup(x => x.EstablishConnection());
          
            BankDetailAccess bankDetailAccess = new BankDetailAccess(sqlHelper.Object);

         
            // //Act
            dataTable = bankDetailAccess.ShowBankDetail();

            // // Assert

            // sqlHelper.VerifyAll();
            Assert.NotNull(dataTable);

        }

        readonly BankDetail bd = new BankDetail()
        {
            accountNumber = 1,
            accountType = "saving",
            customerName = "vivek",
            customerAddress = "Valsad",
            customerEmail = "vj@gmail.com",
            customerPhoneNumber = "7383559109",
            nomieeName = "vicky"


        };


        DataTable DataOfBank()
        {
            DataTable DataInBank = new DataTable();
          

            DataInBank.Columns.Add("AccountNumber", Type.GetType("System.Int32"));
            DataInBank.Columns.Add("AccountType", Type.GetType("System.String"));
            DataInBank.Columns.Add("CustomerName", Type.GetType("System.String"));
            DataInBank.Columns.Add("CustomerAddress", Type.GetType("System.String"));
            DataInBank.Columns.Add("CustomerEmail", Type.GetType("System.String"));
            DataInBank.Columns.Add("CustomerPhoneNumber", Type.GetType("System.String"));
            DataInBank.Columns.Add("NomieeName", Type.GetType("System.String"));

          //  DataInBank.Constraints.Add("id", DataInBank.Columns[1], true);
            for (int i = 1; i <= 3; i++)
            {
                DataRow dr = DataInBank.NewRow();

                dr[0] = i;
                dr[1] = "saving";
                dr[2] = "vivek";
                dr[3] = "Valsad" + i;
                dr[4] = "vj@gmail.com" + i;
                dr[5] = "7383559109" + i;
                dr[6] = "vicky" + i;

                DataInBank.Rows.Add(dr);
            }
            return DataInBank;

        }
    }
}