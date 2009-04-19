using SharpArch.Core.DomainModel;

namespace van.Core
{
    public class Recording : Entity
    {
        public Recording(){}

        [DomainSignature]
        public string RecordingTitle { get; set; }
        [DomainSignature]
        public string RecordingUrl { get; set; }
    }
}