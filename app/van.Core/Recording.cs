using NHibernate.Validator.Constraints;
using SharpArch.Core.DomainModel;
using System;
using Newtonsoft.Json;
using SharpArch.Core.PersistenceSupport;

namespace van.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class Recording : Entity
    {

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [JsonProperty]
        public virtual int Id { get; set; }
        /// <summary>
        /// Gets or sets the recording title.
        /// </summary>
        /// <value>The recording title.</value>
        [DomainSignature]
		[NotNull, NotEmpty]
        [JsonProperty]
		public virtual string RecordingTitle { get; set; }

        /// <summary>
        /// Gets or sets the recording URL.
        /// </summary>
        /// <value>The recording URL.</value>
		[DomainSignature]
		[NotNull, NotEmpty]
        [JsonProperty]
		public virtual string RecordingUrl { get; set; }

        /// <summary>
        /// Gets or sets the recording date.
        /// </summary>
        /// <value>The recording date.</value>
        [Past]
        [JsonProperty]
		public virtual DateTime RecordingDate { get; set; }

        /// <summary>
        /// Gets or sets the duration of the recording.
        /// </summary>
        /// <value>The duration of the recording.</value>
        [NotNull]
        [JsonProperty]
        public virtual string RecordingDuration { get; set; }
        
   }
}
