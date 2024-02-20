using UnityNexus.Server.Shared.Models;

namespace UnityNexus.Server.Shared.Mappers
{
    [Mapper]
    public static partial class TagMapper
    {
        public static partial TagModel Map(Tag tag);
        public static partial Tag Map(TagModel tagModel);
    }
}
