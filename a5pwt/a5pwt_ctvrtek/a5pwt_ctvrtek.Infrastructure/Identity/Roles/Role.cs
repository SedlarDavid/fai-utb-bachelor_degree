using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Infrastructure.Identity.Roles
{
    public class Role : IdentityRole<int>
    {
        public Role(string name) : base(name)
        {
        }
    }
}
