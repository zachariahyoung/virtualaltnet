using SharpArch.Core.DomainModel;

namespace van.Core {
    public class Account : Entity
    {
        [DomainSignature]
        public virtual string Name { get; set; }
        
    }
}
