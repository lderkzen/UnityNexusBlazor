namespace UnityNexus.Shared.Models
{
    public class SubmissionStatusModel
    {
        public byte SubmissionStatusId { get; set; }

        public string Name { get; set; }

        public short Position { get; set; }

        public SubmissionStatusModel()
        {
            Name = string.Empty;
        }
    }
}
