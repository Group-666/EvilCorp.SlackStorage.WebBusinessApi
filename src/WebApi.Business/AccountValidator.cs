using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Contracts;
using WebApi.Domain.Contracts.Validators;

namespace WebApi.Business
{
    public class AccountValidator : IAccountValidator
    {
        private readonly IAccountManager _accountManager;
        private const string InvalidAccountError = "Account not found. Value: {0}";

        public AccountValidator(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        public async Task<bool> IsValidAccount(string userId)
        {
            var account = await _accountManager.Get(userId);
            if (account.Id == Guid.Empty)
                throw new ArgumentException(string.Format(InvalidAccountError, userId), nameof(userId));
            return true;
        }
    }
}