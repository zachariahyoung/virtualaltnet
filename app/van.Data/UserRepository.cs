using System;
using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using van.Core;
using van.Core.DataInterfaces;

namespace van.Data
{
    public class UserRepository : Repository<User>, IUserRepository{

        public User GetByUserName(string userName)
        {
            var criteria = Session.CreateCriteria(typeof(User))
                 .Add(Restrictions.Eq("UserName", userName));

            return criteria.UniqueResult<User>();

        }

        
    }
}