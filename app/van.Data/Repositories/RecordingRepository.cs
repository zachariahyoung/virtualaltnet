using System.Collections.Generic;
using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using van.Core;
using van.Core.DataInterfaces;

namespace van.Data.Repositories   {
    class RecordingRepository : Repository<Recording>, IRecordingRepository

    {
        public IList<Recording> FindAllMatching(string filter)
        {
            var criteria = Session.CreateCriteria(typeof(Recording))
                .Add(Restrictions.Eq("RecordingTitle", filter));

            return criteria.List<Recording>();
        }
    }
}
