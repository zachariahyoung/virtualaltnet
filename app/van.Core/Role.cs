using System;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;
using SharpArch.Core.DomainModel;

namespace van.Core {
    public class Role : Entity
    {
        [DomainSignature]
        [NotNullNotEmpty]
        public virtual string RoleName{ get; set; }

    }
}
