using BankManagement.BLL;
using BankManagement.DAL;
using BankManagement.DTO;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using Xunit;

namespace BankManagementUnitTestBLL
{
    public class BankManagementUnitTestBll
    {//this test case is for selection of 1 account.
        [Fact]
        public void To_Check_Single_Selection_Is_Working()
        {
          
            //Arrange
          var ID = 1;
            var bankDetailAccess = new Mock<IBankDetailAccess>();
          //  var sqlhelper = new Mock<ISqlhelper>();

            bankDetailAccess.Setup(x => x.GetSingleAccountDetail(ID));
            Bank bn = new Bank(bankDetailAccess.Object);
           
            //Act
            bn.GetSingleBankAccountDetail();
      
            //Assert
            bankDetailAccess.VerifyAll();
        }
        //this test case is for add of 1 account.
        [Fact]
        public void To_Check_Add_Detail_Is_Working()
        {
            //var bank = new Mock<IBank>();
            //Arrange

            var bankDetailAccess = new Mock<IBankDetailAccess>();
         //   var sqlhelper = new Mock<ISqlhelper>();
            bankDetailAccess.Setup(x => x.SaveBankDetail(It.IsAny<BankDetail>()));
            Bank bn = new Bank(bankDetailAccess.Object);
           
            //Act
            bn.AddBankDetail();

            // Assert
         
            bankDetailAccess.VerifyAll();
        }

        //this test case is for update of 1 account.
        [Fact]
        public void To_Check_Update_Is_Working()
        {
          
            //Arrange
            var ID = 1;
            var bankDetailAccess = new Mock<IBankDetailAccess>();
         //   var sqlhelper = new Mock<ISqlhelper>();
            bankDetailAccess.Setup(x => x.UpdateBankAccount(ID));
            Bank bn = new Bank(bankDetailAccess.Object);

            //Act
            bn.UpdatebankDetail();

            //Assert
            bankDetailAccess.VerifyAll();
        }
        //this test case is for delete of 1 account.
        [Fact]
        public void To_Check_Delete_Is_Working()
        {
            
            //Arrange
            var ID = 1;
            var bankDetailAccess = new Mock<IBankDetailAccess>();
           // var sqlhelper = new Mock<ISqlhelper>();
            bankDetailAccess.Setup(x => x.DeleteBankAccount(ID));
            Bank bn = new Bank(bankDetailAccess.Object);

            //Act
            bn.DeleteBankDetail();

            //Assert
            bankDetailAccess.VerifyAll();
        }
        //this test case is for selection of all account.
        [Fact]
        public void To_Check_All_Selection_Is_Working()
        {
            
            //Arrange
           
            var bankDetailAccess = new Mock<IBankDetailAccess>();
          //  var sqlhelper = new Mock<ISqlhelper>();
            bankDetailAccess.Setup(x => x.ShowBankDetail()).Returns(DataOfBank);
            Bank bn = new Bank(bankDetailAccess.Object);

            //Act
            bn.ShowAllBankDetail();

            //Assert
            bankDetailAccess.VerifyAll();
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
