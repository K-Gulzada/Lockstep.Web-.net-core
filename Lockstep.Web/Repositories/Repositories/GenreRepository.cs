using Lockstep.Domain.DAO;
using Lockstep.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lockstep.Web
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context) { }
    }
}