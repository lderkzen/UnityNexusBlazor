namespace UnityNexus.Shared.Interfaces
{
    public interface INotifiable<TIdentifier>
    {
        public TIdentifier Identifier { get; }

        public bool ShouldIdentify { get; }
    }
}
