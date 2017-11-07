using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Entity.Mapping
{
    public class BaseEntityMap<T> : ClassMap<T> where T : BaseEntity
    {
        public BaseEntityMap()
        {
            Id(x => x.ID);
        }
    }
}
