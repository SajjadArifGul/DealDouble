using DealDouble.Data;
using DealDouble.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class DealDoubleRolesManager : RoleManager<IdentityRole>
    {
        public DealDoubleRolesManager(IRoleStore<IdentityRole, string> roleStore) : base(roleStore)
        {
        }

        public static DealDoubleRolesManager Create(IdentityFactoryOptions<DealDoubleRolesManager> options, IOwinContext context)
        {
            return new DealDoubleRolesManager(new RoleStore<IdentityRole>(context.Get<DealDoubleContext>()));
        }
    }
}
