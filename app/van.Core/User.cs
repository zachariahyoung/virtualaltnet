using Iesi.Collections.Generic;
using SharpArch.Core.DomainModel;

namespace van.Core
{
    public class User : Entity
    {
        [DomainSignature]
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

        public virtual ISet<Role> Roles { get; set; }

        public User()
        {
            Roles = new HashedSet<Role>();
        }


          
    }
}