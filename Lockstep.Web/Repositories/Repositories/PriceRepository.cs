
using Lockstep.Web;
using Lockstep.Web.Data;
using LockStep.Domain.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lockstep.Web
{
    public class PriceRepository : GenericRepository<Price>, IPriceRepository
    {
        public PriceRepository(ApplicationDbContext context) : base(context) { }
    }
}