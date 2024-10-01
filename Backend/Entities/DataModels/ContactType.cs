using Entities.Abstract;

namespace Entities.DataModels;

public class ContactType : IdentityEntity<byte>
{
    public string ContactTitle { get; set; } = null!;

    public virtual ICollection<ContactPrincipal> ClassSubjects { get; set; } = [];
}
