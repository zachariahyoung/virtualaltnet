using System;
using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using van.Core;
using van.Core.DataInterfaces;

namespace van.Data {
    public class AccountRepository : Repository<Role>, IAccountRepository {
        #region Implementation of IAccountRepository

        public string GetRoleForUser(string userName)
        {

            var criteriaUser = Session.CreateCriteria(typeof(User));
            criteriaUser.Add(Restrictions.Eq("UserName", userName));
            var result = criteriaUser.UniqueResult();

            var userId = Session.GetIdentifier(result);
            var roleName = Session.Get<Role>(userId).RoleName.ToUpper();
            return roleName;
            
            //var criteria2 = Session.CreateCriteria(typeof(Role))
            //    .Add(Restrictions.Eq("Id", userId));
            //if (criteria2 == null) throw new NotImplementedException();
            //return criteria2.UniqueResult<Role>();
        }

        #endregion
    }
}
