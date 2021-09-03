using NETCore.Context;
using NETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Repository.Data
{
    public class RoleRepository : GeneralRepository<MyContext, Role, string>
    {
        public RoleRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
