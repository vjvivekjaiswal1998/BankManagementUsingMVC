using System.Data;
using BankManagement.DTO;

namespace BankManagement.DAL
{
    public interface IBankDetailAccess
    {
        void AddConstraint();
        bool DeleteBankAccount(int accountId);
        DataTable GetSingleAccountDetail(int accountId);
        void SaveBankDetail(BankDetail bankDetail);
        DataTable ShowBankDetail();
        void UpdateBankAccount(int accountid);
    }
}