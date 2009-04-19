using SharpArch.Core.DomainModel;

namespace van.Core
{
    public class Recording : Entity
    {
        [DomainSignature]
        public virtual string RecordingTitle { get; set; }
        [DomainSignature]
        public virtual string RecordingUrl { get; set; }
    }
}