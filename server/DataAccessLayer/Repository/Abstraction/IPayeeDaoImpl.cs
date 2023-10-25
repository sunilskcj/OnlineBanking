using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Abstraction
{
    public interface IPayeeDaoImpl
    {
        bool DeleteAccountFieldbyID(int id);
        PayeeModel FetchAccountById(int id);
        List<PayeeModel> FetchAllAccount(int id);
        bool InsertAccountField(PayeeModel a, int id);
        bool UpdateAccountField(PayeeModel a, int id);
    }
}
