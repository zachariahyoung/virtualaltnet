using NHibernate.Validator.Constraints;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.DomainModel;
using System;

namespace van.Core
{
    public class Group : Entity
    {
        public Group() { }
		
		[DomainSignature]
        [NotNull, NotEmpty(Message = "Name must be provided")]
		public virtual string Name { get; set; }

        [DomainSignature]
        [NotNull, NotEmpty(Message = "ShortName must be provided")]
        public virtual string ShortName { get; set; }

		public virtual string Blog { get; set; }

        public virtual string Rss { get; set; }

        public virtual string Description { get; set; }

        public virtual string StartTime { get; set; }

        public virtual string EndTime { get; set; }

        public virtual string TimeZone { get; set; }

		[NotNull]
		public virtual User Manager { get; set; }
    }
}
