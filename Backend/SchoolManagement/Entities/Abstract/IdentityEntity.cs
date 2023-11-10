using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Abstract
{
    public class IdentityEntity<T>
    {
        [Key]
        [Column("id")]
        public T Id { get; set; }
    }
}
