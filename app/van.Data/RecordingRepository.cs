
using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using van.Core;
using van.Core.DataInterfaces;

namespace van.Data
{
    public class RecordingRepository : Repository<Recording>, IRecordingRepository

    {
        public List<Recording> FindAllMatching(string filter)
        {
            ICriteria criteria = Session.CreateCriteria(typeof(Recording))
                .Add(Expression.Eq("RecordingTitle", filter));

            return criteria.List<Recording>() as List<Recording>;
        }

    }
}
