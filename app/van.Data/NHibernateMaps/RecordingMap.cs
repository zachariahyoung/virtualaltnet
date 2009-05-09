using System;
using FluentNHibernate.AutoMap;
using SharpArch.Data.NHibernate.FluentNHibernate;
using FluentNHibernate.AutoMap.Alterations;
using van.Core;

namespace van.Data.NHibernateMaps {
    public class RecordingMap : IAutoMappingOverride<Recording>
    {
        /// <summary>
        /// Alter the automapping for this type
        /// </summary>
        /// <param name="mapping">Automapping</param>
        public void Override(AutoMap<Recording> mapping)
        {
            mapping.Id(x => x.Id, "RecordingID")
                .WithUnsavedValue(0)
                .GeneratedBy.Identity();
        }
    }
}
