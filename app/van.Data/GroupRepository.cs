using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Data.NHibernate;
using van.Core;
using van.Core.DataInterfaces;

namespace van.Data
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
    }
}
