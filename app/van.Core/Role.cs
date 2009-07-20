using SharpArch.Core.DomainModel;

namespace van.Core {
    public class Role : Entity
    {
        [DomainSignature]
        public virtual string RoleName{ get; set; }
        
    }
}
