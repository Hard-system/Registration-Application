using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Entity
{
    public class User : BaseEntity
    {
        public virtual string Password { get; set; }
        public virtual string Fullname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Token { get; set; }
        public virtual string TokenStart { get; set; }
        public virtual bool TokenExpired { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual string Organization { get; set; }
        public virtual string Occupation { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Password1 { get; set; }
        public virtual bool Enable { get; set; }
        public virtual bool IsAdministrator { get; set; }


        public virtual object GetJson()

        {
            return new
            {
                ID = this.ID,
                Password = this.Password,
                Fullname = this.Fullname,
                Email = this.Email,
                Token = this.Token,
                TokenStart = this.TokenStart,
                TokenExpired = this.TokenExpired,
                EmailConfirmed = this.EmailConfirmed,
                Organization = this.Organization,
                Occupation = this.Occupation,
                Gender = this.Gender,
                Password1 = this.Password1,
                Enable = this.Enable,

            };
        }
    }
}
