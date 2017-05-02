using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EvilCorp.AccountService
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        Task<IEnumerable<Account>> GetAll();
    }
}