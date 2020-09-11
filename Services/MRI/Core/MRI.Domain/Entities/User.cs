using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class User : Entity
    {
        public virtual Doctor Doctor { get; protected set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }
        public string Email { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public DateTime LastLoginDate { get; protected set; }
        public bool IsLockedOut { get; protected set; }
    }
}
