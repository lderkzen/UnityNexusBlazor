namespace UnityNexus.Shared.Models
{
    public class GroupTypeModel
    {
        public byte GroupTypeId { get; set; }
        public string Name { get; set; }

        public GroupTypeModel()
        {
            Name = string.Empty;
        }
    }
}
