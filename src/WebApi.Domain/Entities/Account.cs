using System;
using System.Runtime.Serialization;

namespace EvilCorp.AccountService
{
    [DataContract]
    public class Account
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Nickname { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public bool Activated { get; set; }
    }
}