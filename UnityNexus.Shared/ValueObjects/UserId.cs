using System.ComponentModel.DataAnnotations.Schema;

namespace UnityNexus.Shared.ValueObjects
{
    [NotMapped]
    [ValueObject(typeof(Guid))]
    public partial class UserId
    {
    }
}
