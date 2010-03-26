using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport;
using van.Core.Dto;

namespace van.Core.DataInterfaces
{
    public interface IRecordingRepository : IRepository<Recording>
    {
        IList<RecordingDto> GetRecordingSummaries();
        IList<RecordingDto> GetEventSummaries();
    }
}