using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Entity
{
    public class ForgotPassword1 : BaseEntity
    {

        public virtual string Token { get; set; }
        public virtual string TokenStart { get; set; }
        public virtual bool TokenExpired { get; set; }
        public virtual bool PasswordChanged { get; set; }
        public virtual string Email { get; set; }
        public virtual object GetJson()

        {
            return new
            {
                ID = this.ID,
                Token = this.Token,
                TokenStart = this.TokenStart,
                TokenExpired = this.TokenExpired,
                PasswordChanged = this.PasswordChanged,
                Email = this.Email
            };
        }
    }
}
