using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lockstep.Domain.DAO
{
    public class Genre : BaseModel
    {

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

    }
}