using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockstep.Domain.DAO
{
    public class Book : BaseModel
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
