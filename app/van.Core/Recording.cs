using NHibernate.Validator.Constraints;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.DomainModel;
using System;

namespace van.Core
{
    public class Recording : Entity
    {
        public Recording() { }
		
		[DomainSignature]
		[NotNull, NotEmpty]
		public virtual string RecordingTitle { get; set; }

		[DomainSignature]
		[NotNull, NotEmpty]
		public virtual string RecordingUrl { get; set; }

        [Past]
		public virtual DateTime RecordingDate { get; set; }

		public virtual string RecordingDuration { get; set; }
    }
}
