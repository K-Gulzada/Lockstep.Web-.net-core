﻿using Lockstep.Domain.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStep.Domain.DAO
{
    public class BookComment : BaseModel
    {
        public string Email { get; set; }
        public Book Book { get; set; }
        public string Description { get; set; }
        public BookVote BookVote { get; set; }
    }
}
