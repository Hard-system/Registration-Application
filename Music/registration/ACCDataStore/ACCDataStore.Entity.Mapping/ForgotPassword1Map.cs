using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Entity.Mapping
{
    public class ForgotPassword1Map : BaseEntityMap<ForgotPassword1>
    {
        public ForgotPassword1Map()
        {
            
            Map(x => x.PasswordChanged);
            Map(x => x.Token);
            Map(x => x.TokenExpired);
            Map(x => x.TokenStart);
            Map(x => x.Email);
        }
    }
}
