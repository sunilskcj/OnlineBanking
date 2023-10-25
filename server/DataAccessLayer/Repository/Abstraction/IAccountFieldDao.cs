
using Server.BusinessModels;

namespace DataAccessLayer.Repository.Implementation
{
    public interface IAccountFieldDao
    {
        AccountModel FetchAccountById(int id);
        List<AccountModel> FetchAllAccount();
        bool InsertAccountField(AccountModel p);
        List<AccountModel> FetchAccountByStatus(string status);
        bool UpdateAccountField(AccountModel p, int id);
        bool DeleteAccountFieldbyID(int id);

    }
}