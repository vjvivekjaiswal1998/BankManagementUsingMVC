using System.Data;
using BankManagement.DTO;

namespace BankManagement.DAL
{
    public interface IBankDetailAccess
    {
        void AddConstraint();
        bool DeleteBankAccount(int accountNumber);
        DataTable GetSingleAccountDetail(int accountId);
        void SaveBankDetail(BankDetail bankDetail);
        DataTable ShowBankDetail();
        void UpdateBankAccount(int Accountid, string CustomerEmail, string CustomerPhoneNumber);
    }
}