using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Abstraction
{
    public interface ICredentialsDaoImpl
    {
        bool DeleteAccountCredential(int id);
        CredentialModel FetchAccountById(int id);

        List<CredentialModel> FetchAllAccountCredential();

        bool InsertAccountCredential(int id);
        bool UpdateAccountCredential(CredentialModel p, int id);
    }
}
