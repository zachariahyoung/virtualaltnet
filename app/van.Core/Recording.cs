using NHibernate.Validator.Constraints;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.DomainModel;
using System;
using Newtonsoft.Json;


namespace van.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class Recording : Entity
    {
        Guid securityKey = Guid.NewGuid();
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
        
        [NotNull]
        [JsonProperty]
        /// <summary>
        /// Gets or sets the duration of the recording.
        /// </summary>
        /// <value>The duration of the recording.</value>
		public virtual string RecordingDuration { get; set; }


        /// <summary>
        /// Gets or sets the security key.
        /// </summary>
        /// <value>The security key.</value>
        public virtual Guid SecurityKey
        {
            get { return securityKey; }
            set { securityKey = value;}
        }
    }
}
