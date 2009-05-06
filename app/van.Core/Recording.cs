using NHibernate.Validator.Constraints;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.DomainModel;
using System;
using Newtonsoft.Json;


namespace van.Core
{
    public class Recording : Entity
    {
        public Recording() { }
		
		[DomainSignature]
		[NotNull, NotEmpty]
        [JsonProperty]
		public virtual string RecordingTitle { get; set; }

		[DomainSignature]
		[NotNull, NotEmpty]
        [JsonProperty]
		public virtual string RecordingUrl { get; set; }

        [Past]
        [JsonProperty]
		public virtual DateTime RecordingDate { get; set; }
        
        [NotNull]
        [JsonProperty]
		public virtual string RecordingDuration { get; set; }
    }
}
