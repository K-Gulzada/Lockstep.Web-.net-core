using Lockstep.Domain.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStep.Domain.DAO
{
    public class BookAuthor:BaseModel
    {
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
