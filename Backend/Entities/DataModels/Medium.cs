using Entities.Abstract;

namespace Entities.DataModels
{
    public class Medium : IdentityEntity<byte>
    {
        public string Title { get; set; } = null!;
    }
}