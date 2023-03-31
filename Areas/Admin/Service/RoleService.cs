using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Service
{
    public class RoleService
    {
        private BuildingDB db = new BuildingDB();

        public List<Role> getAll ()
        {
            return db.Roles.ToList();
        }
    }
}