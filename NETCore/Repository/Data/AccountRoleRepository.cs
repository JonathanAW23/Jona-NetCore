using NETCore.Context;
using NETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Repository.Data
{
    public class AccountRoleRepository : GeneralRepository<MyContext, AccountRole, string>
    {
        public AccountRoleRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
