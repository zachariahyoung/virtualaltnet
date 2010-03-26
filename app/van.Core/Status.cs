using NHibernate.Validator.Constraints;
using SharpArch.Core.DomainModel;

namespace van.Core
{
    public class Status : Entity
    {
        public Status() { }

        [DomainSignature]
        [NotNull, NotEmpty(Message = "Name must be provided")]
        public virtual string Name { get; set; }
        
    }
}