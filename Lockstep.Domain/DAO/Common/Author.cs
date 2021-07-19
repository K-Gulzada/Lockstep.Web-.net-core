using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lockstep.Domain.DAO
{
    public class Author : BaseModel
    {
        [Required]
        [MaxLength(30)]
        public string FullName { get; set; }
    }
}