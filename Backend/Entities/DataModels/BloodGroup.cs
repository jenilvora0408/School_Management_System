using Entities.Abstract;

namespace Entities.DataModels;

public class BloodGroup : IdentityEntity<byte>
{
    public string Title { get; set; } = null!;
}

