namespace UnityNexus.Shared.Models
{
    public class AnswerTypeModel
    {
        public byte AnswerTypeId { get; set; }
        public string Name { get; set; }

        public AnswerTypeModel()
        {
            Name = string.Empty;
        }
    }
}
