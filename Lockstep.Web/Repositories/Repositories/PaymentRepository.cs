using Lockstep.Web.Data;
using LockStep.Domain.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lockstep.Web
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext context) : base(context) { }
    }
}