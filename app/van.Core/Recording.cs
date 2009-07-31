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
		[JsonProperty]
		public virtual string Title { get; set; }

		[DomainSignature]
		[NotNull, NotEmpty]
		[JsonProperty]
		public virtual string Url { get; set; }

		[JsonProperty]
        [JsonConverter(typeof(JavaScriptDateTimeConverter))]
        //[JsonConverter(typeof(IsoDateTimeConverter))]
		public virtual DateTime Date { get; set; }

		[JsonProperty]
		public virtual string Duration { get; set; }
        
        [JsonProperty]
        public virtual string Speaker { get; set; }

        [JsonProperty]
        public virtual string UserGroup { get; set; }

        [JsonProperty]
        public virtual string LiveMeetingUrl { get; set; }

        [JsonProperty]
        public virtual string Description { get; set; }

    }
}
