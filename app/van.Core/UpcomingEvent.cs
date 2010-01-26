using NHibernate.Validator.Constraints;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.DomainModel;
using System;

namespace van.Core
{
    public class UpcomingEvent : Entity
    {
        public UpcomingEvent() { }
		
		[DomainSignature]
		[NotNull, NotEmpty]
		public virtual string Title { get; set; }

		[DomainSignature]
		[NotNull, NotEmpty]
		public virtual DateTime EventDate { get; set; }

		[NotNull, NotEmpty]
		public virtual string FullDescription { get; set; }

		[NotNull, NotEmpty]
		public virtual string ShortDescription { get; set; }

		[NotNull, NotEmpty]
		public virtual Speaker Presenter { get; set; }

		[NotNull, NotEmpty]
		public virtual bool Approved { get; set; }
    }
}
