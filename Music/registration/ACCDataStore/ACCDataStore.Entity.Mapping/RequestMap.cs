using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Entity.Mapping
{
    public class RequestMap : BaseEntityMap<Request>
    {
        public RequestMap()
        {
            
            Map(x => x.Schoolpro);
            Map(x => x.Datahub);
            Map(x => x.Widerach);
            //Map(x => x.Enable);
        }
    }
}
