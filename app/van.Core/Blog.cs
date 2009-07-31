
using System;
using SharpArch.Core.DomainModel;

namespace van.Core
{
    public class Blog : Entity
    {
        [DomainSignature]
        public virtual string Name { get; set; }

        public virtual string Url { get; set; }

        public virtual string Rss { get; set; }
    }
}