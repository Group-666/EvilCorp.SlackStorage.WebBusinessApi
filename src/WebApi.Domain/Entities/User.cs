using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WebApi.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Nickname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public int UserRole { get; set; }
    }
}