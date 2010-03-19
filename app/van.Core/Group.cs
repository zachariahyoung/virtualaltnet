using NHibernate.Validator.Constraints;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.DomainModel;
using System;

namespace van.Core
{
    public class Group : Entity
    {
        public Group() { }
		
		[DomainSignature]
		[NotNull, NotEmpty]
		public virtual string GroupName { get; set; }

		public virtual string Website { get; set; }

		[NotNull]
		public virtual User Manager { get; set; }
    }
}
