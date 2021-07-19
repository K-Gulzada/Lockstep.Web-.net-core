using System.ComponentModel.DataAnnotations;

namespace Lockstep.Domain.DAO
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}