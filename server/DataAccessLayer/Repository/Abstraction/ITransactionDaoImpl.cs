using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Abstraction
{
    public interface ITransactionDaoImpl
    {
        bool DeleteAccountFieldbyID(int id);
        TransactionModel FetchAccountById(int id);
        List<TransactionModel> FetchAllAccount(int id);
        int? InsertAccountField(TransactionModel a, int id);
        bool UpdateAccountField(TransactionModel a, int id);
        bool ProceedTransaction(int id);
        TransactionModel FetchAccountBystatus(string status, int id);
    }
}
