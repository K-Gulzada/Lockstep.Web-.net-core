﻿using Lockstep.Domain.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStep.Domain.DAO
{
    public class Check : BaseModel
    {
        public string IdRequest { get; set; }
        public string Email { get; set; }
        public Book Book { get; set; }
        public int Status { get; set; }
    }
}
