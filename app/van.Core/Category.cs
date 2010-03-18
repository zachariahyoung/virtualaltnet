using NHibernate.Validator.Constraints;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.DomainModel;
using System;

namespace van.Core
{
    public class Category : Entity
    {
        public Category() { }
		
		[DomainSignature]
		[NotNull, NotEmpty]
        public virtual string Description { get; set; }
    }
}
