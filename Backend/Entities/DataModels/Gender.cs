using Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataModels;

public class Gender : IdentityEntity<byte>
{
    public string Title { get; set; } = null!;
}

