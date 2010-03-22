using Newtonsoft.Json.Converters;
using NHibernate.Validator.Constraints;
using SharpArch.Core.DomainModel;
using System;
using Newtonsoft.Json;

namespace van.Core
{
    public class Recording : Entity
    {
        [DomainSignature]
		[NotNull, NotEmpty]
		public virtual string Title { get; set; }

		[DomainSignature]
		[NotNull, NotEmpty]
		public virtual string Url { get; set; }
		
		public virtual DateTime Date { get; set; }
		
		public virtual string Duration { get; set; }
                
        public virtual Speaker Speaker { get; set; }

        public virtual Group Group { get; set; }

        public virtual string LiveMeetingUrl { get; set; }

        public virtual string Description { get; set; }

    }
}
