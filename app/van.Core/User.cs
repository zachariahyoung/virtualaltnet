using Iesi.Collections.Generic;
using NHibernate.Validator.Constraints;
using SharpArch.Core.DomainModel;

namespace van.Core
{
    public class User : Entity
    {
        [DomainSignature]
        [NotNull, NotEmpty(Message = "UserName must be provided")]
        public virtual string UserName { get; set; }

        [DomainSignature]
        [NotNull, NotEmpty(Message = "Name must be provided")]
        public virtual string Name { get; set; }

        [NotNull, NotEmpty(Message = "Password must be provided")]
        public virtual string Password { get; set; }

        [NotNull, NotEmpty(Message = "Email must be provided")]
        public virtual string Email { get; set; }

        public virtual ISet<Role> Roles { get; set; }

        public User()
        {
            Roles = new HashedSet<Role>();
        }


          
    }
}