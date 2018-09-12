﻿using ManagementAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ManagementAPI.Controllers
{
       [EnableCors("*", "*", "*", "*")]
     
    public class AspNetRolesController : ApiController
    {
        private ApplicationDbContext Context = new ApplicationDbContext();

        public IHttpActionResult Get()
        {
            var retval = Context.Roles.ToList();

            return Ok(retval);
        }

        public async Task<IHttpActionResult> Post(string Name)
        {
            var roleStore = new RoleStore<IdentityRole>(Context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var result = await roleManager.CreateAsync(new IdentityRole { Name = Name });

            return Ok(result);

        }

        public async Task<IHttpActionResult> Delete(string Id)
        {
            var roleStore = new RoleStore<IdentityRole>(Context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var role = await roleManager.FindByIdAsync(Id);

            var result = await roleManager.DeleteAsync(role);
            return Ok(result);
        }
    }
}
