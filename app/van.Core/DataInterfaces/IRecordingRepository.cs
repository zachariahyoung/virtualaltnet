using System.Collections.Generic;
using SharpArch.Core.PersistenceSupport;

namespace van.Core.DataInterfaces
{
    public interface IRecordingRepository : IRepository<Recording> {
        IList<Recording> FindAllMatching(string filter);
    }
}