using BankManagement.DTO;
using System.Collections.Generic;
using System.Data;

namespace BankManagement.BLL
{
    public interface IBank
    {
        void DeleteBankDetail(int accountNumber);
        BankDetail  AddBankDetail(BankDetail bankDetail);
        BankDetail GetSingleBankAccountDetail(int AccountNumber);
        List<BankDetail> ShowAllBankDetail();
        void UpdatebankDetail(int AccountNumber, string CustomerEmail, string CustomerPhoneNumber);
    }
}
