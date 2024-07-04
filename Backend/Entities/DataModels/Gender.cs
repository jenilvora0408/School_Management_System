using Entities.Abstract;

namespace Entities.DataModels;

public class Gender : IdentityEntity<byte>
{
    public string Title { get; set; } = null!;
}

