using System.Data;

namespace BankManagement.DAL
{
    public interface ISqlhelper
    {
        void EstablishConnection();
        DataTable FillDetail();
    }
}