using Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels
{
    public class BloodGroup : IdentityEntity<byte>
    {
        [MaxLength(10)]
        [Column("blood_group", TypeName = "varchar")]
        public string? Title { get; set; }
    }
}
