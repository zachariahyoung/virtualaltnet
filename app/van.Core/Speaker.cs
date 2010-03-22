using NHibernate.Validator.Constraints;
using SharpArch.Core.DomainModel;

namespace van.Core
{
    public class Speaker : Entity
    {
        public Speaker() { }
		
		[DomainSignature]
		[NotNull, NotEmpty]
		public virtual string Name { get; set; }       
        
        public virtual string Email { get; set; }       

        public virtual string Bio { get; set; }

        public virtual string Website { get; set; }
    }
}
