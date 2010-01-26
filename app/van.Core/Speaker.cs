using NHibernate.Validator.Constraints;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.DomainModel;
using System;

namespace van.Core
{
    public class Speaker : Entity
    {
        public Speaker() { }
		
		[DomainSignature]
		[NotNull, NotEmpty]
		public virtual string FirstName { get; set; }

		[DomainSignature]
		[NotNull, NotEmpty]
		public virtual string LastName { get; set; }

		[DomainSignature]
		[NotNull, NotEmpty]
		public virtual string Email { get; set; }

		public virtual string Website { get; set; }

		[NotNull]
		public virtual Recording Presentation { get; set; }
    }
}
