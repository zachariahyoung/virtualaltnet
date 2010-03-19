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

        [DomainSignature]
        [NotNull, NotEmpty]
        [JsonProperty]
        public virtual string LiveMeetingUrl { get; set; }


        
    }
}
