using Lockstep.Web.Data;
using LockStep.Domain.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lockstep.Web
{
    public class CheckRepository : GenericRepository<Check>, ICheckRepository
    {
        public CheckRepository(ApplicationDbContext context) : base(context) { }
    }
}