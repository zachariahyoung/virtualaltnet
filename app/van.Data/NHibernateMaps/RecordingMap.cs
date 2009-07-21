using FluentNHibernate.Mapping;
using van.Core;

namespace van.Data.NHibernateMaps
{
    public class RecordingMap : ClassMap<Recording>
    {
        public RecordingMap()
        {
            Not.LazyLoad();
        }
    }
}