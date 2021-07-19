using Lockstep.Domain.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStep.Domain.DAO
{
    public class BookGenre : BaseModel
    {
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}
