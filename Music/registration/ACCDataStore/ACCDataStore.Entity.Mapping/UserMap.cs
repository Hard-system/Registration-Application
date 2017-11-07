using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Entity.Mapping
{
    public class UserMap : BaseEntityMap<User>
    {
        public UserMap()
        {

            Map(x => x.ID);
            Map(x => x.Password);
            Map(x => x.Fullname);            
            Map(x => x.Organization);
            Map(x => x.Occupation);
            Map(x => x.Gender);
            Map(x => x.Password1);
            Map(x => x.Email);
            Map(x => x.EmailConfirmed);
            Map(x => x.Token);
            Map(x => x.TokenExpired);
            Map(x => x.TokenStart);

        }
    }
}
