using Entities.Abstract;

namespace Entities.DataModels;

public class UserRole : IdentityEntity<byte>
{
    public string Title { get; set; } = null!;
}

