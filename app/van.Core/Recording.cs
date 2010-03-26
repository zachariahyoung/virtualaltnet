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
        [NotNull, NotEmpty(Message = "Title must be provided")]
		public virtual string Title { get; set; }

        [NotNull, NotEmpty(Message = "Description must be provided")]
        public virtual string Description { get; set; }

        [NotNull]
        public virtual DateTime Date { get; set; }

        [NotNull]
        public virtual Speaker Speaker { get; set; }

        [NotNull]
        public virtual Group Group { get; set; }

        [NotNull, NotEmpty(Message = "Url must be provided")]
		public virtual string Url { get; set; }

        [NotNull, NotEmpty(Message = "LiveMeetingUrl must be provided")]
        public virtual string LiveMeetingUrl { get; set; }      

        [NotNull, NotEmpty(Message = "Duration must be provided")]
		public virtual string Duration { get; set; }

        [NotNull]
        public virtual Status Status { get; set; }


    }
}
