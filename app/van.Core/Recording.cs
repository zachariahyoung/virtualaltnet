using Newtonsoft.Json.Converters;
using NHibernate.Validator.Constraints;
using SharpArch.Core.DomainModel;
using System;
using Newtonsoft.Json;

namespace van.Core
{
    public class Recording : Entity
    {
        public Recording() { }
		
		[DomainSignature]
		[JsonConverter(typeof(JavaScriptDateTimeConverter))]
		[JsonProperty]
		public virtual DateTime Date { get; set; }

		[DomainSignature]
		[NotNull, NotEmpty]
		[JsonProperty]
		public virtual string UploadedUrl { get; set; }

		[JsonConverter(typeof(JavaScriptDateTimeConverter))]
		[JsonProperty]
		public virtual DateTime StartTime { get; set; }

		[JsonConverter(typeof(JavaScriptDateTimeConverter))]
		[JsonProperty]
		public virtual DateTime EndTime { get; set; }

        [JsonProperty]
		public virtual UpcomingEvent UpcomingEvent { get; set; }

        [JsonProperty]
		public virtual VirtualGroup UserGroup { get; set; }

        [JsonProperty]
		public virtual Category Category { get; set; }
    }
}
