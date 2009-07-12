using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using van.Core;
using van.Core.DataInterfaces;

namespace van.Data {
    public class AccountRepository : Repository<Account>,IAccountRepository {
        #region Implementation of IAccountRepository

        public Account GetRoleForUser(int accountId)
        {
            var criteria = Session.CreateCriteria(typeof(Account))
                .Add(Restrictions.Eq("Id", accountId));
            return criteria.UniqueResult<Account>();
        }

        #endregion
    }
}
