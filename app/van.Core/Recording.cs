using System;
using SharpArch.Core.DomainModel;

namespace van.Core
{
    public class Recording : Entity
    {
        [DomainSignature]
        public virtual string RecordingTitle { get; set; }
        [DomainSignature]
        public virtual string RecordingUrl { get; set; }
        [DomainSignature]
        public virtual DateTime? RecordingDate { get; set; }
        [DomainSignature]
        public virtual string RecordingDuration { get; set; }
        
        

    }
}