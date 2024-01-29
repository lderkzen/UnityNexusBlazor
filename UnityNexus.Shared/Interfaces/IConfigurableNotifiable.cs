using System.Collections.Immutable;

namespace UnityNexus.Shared.Interfaces
{
    public interface IConfigurableNotifiable : INotifiable
    {
        public IImmutableList<NotificationFlag> Flags { get; }

        public uint FlagSum => Flags
            .Aggregate(
                (uint)NotificationFlag.Unconfigured,
                (acc, flag) => acc += (ushort)flag,
                result => result
            );
    }
}
