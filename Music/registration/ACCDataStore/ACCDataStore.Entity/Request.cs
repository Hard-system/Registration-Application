using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Entity
{
    public class Request : BaseEntity
    {
       
        public virtual bool Schoolpro { get; set; }
        public virtual bool Datahub { get; set; }
        public virtual bool Widerach { get; set; }

        public virtual object GetJson()

        {
            return new
            {
                ID = this.ID,
               
                Schoolpro = this.Schoolpro,
                Datahub = this.Datahub,
                Widerach = this.Widerach
            };
        }
    }
}