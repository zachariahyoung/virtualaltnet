    using Newtonsoft.Json;
    using NHibernate.Validator.Constraints;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.DomainModel;
using System;

namespace van.Core
{
    public class Event : Entity
    {
        public Event() { }
	
		[DomainSignature]
		[NotNull, NotEmpty]
		public virtual string Title { get; set; }
        
        [DomainSignature]
        [NotNull, NotEmpty]
        public virtual string Description { get; set; }

		[DomainSignature]
		[NotNull, NotEmpty]
		public virtual DateTime EventDate { get; set; }

        [DomainSignature]
		[NotNull, NotEmpty]
		public virtual Speaker Presenter { get; set; }
        
        public virtual Recording Recording { get; set; }

        [JsonProperty]
        public virtual Group UserGroup { get; set; }

		[NotNull, NotEmpty]
		public virtual bool Approved { get; set; }
    }
}
