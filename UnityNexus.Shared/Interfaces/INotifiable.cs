namespace UnityNexus.Shared.Interfaces
{
    public interface INotifiable
    {
        public string Identifier { get; }

        public bool ShouldIdentify { get; }
    }
}
