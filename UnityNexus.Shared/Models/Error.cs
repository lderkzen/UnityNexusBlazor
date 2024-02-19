namespace UnityNexus.Shared.Models
{
    public class Error
    {
        public ErrorClassification Classification { get; }

        public string Message { get; }

        [JsonConstructor]
        public Error(ErrorClassification classification, string message)
        {
            Classification = classification;
            Message = message;
        }
    }
}
