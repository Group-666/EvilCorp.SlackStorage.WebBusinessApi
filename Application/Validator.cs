using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvilCorp.SlackStorage.WebBusinessApi.Business
{
    public class Validator : IValidator
    {
        public bool IsValidId(string id)
        {
            return !string.IsNullOrEmpty(id);
        }
    }
}
