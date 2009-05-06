﻿using FluentNHibernate.Conventions;
using FluentNHibernate.Mapping;

namespace van.Data.NHibernateMaps.Conventions
{
    public class ReferenceConvention : IReferenceConvention
    {
        public bool Accept(IManyToOnePart manyToOnePart)
        {
            return true;
        }

        public void Apply(IManyToOnePart manyToOnePart)
        {
            manyToOnePart.ColumnName(manyToOnePart.Property.Name + "Fk");
        }
    }
}
