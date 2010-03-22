using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Transform;
using SharpArch.Data.NHibernate;
using van.Core;
using van.Core.DataInterfaces;
using van.Core.Dto;

namespace van.Data
{
    public class RecordingRepository : Repository<Recording>, IRecordingRepository
    {
        public IList<RecordingDto> GetRecordingSummaries() {
            ISession session = SharpArch.Data.NHibernate.NHibernateSession.Current;

            IQuery query = session. GetNamedQuery("GetRecordingSummaries")
                .SetResultTransformer(Transformers.AliasToBean<RecordingDto>());

            return query.List<RecordingDto>();

        }
    }
}