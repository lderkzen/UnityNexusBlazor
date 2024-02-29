namespace UnityNexus.Shared.Models
{
    public class CategoryTypeModel
    {
        public byte CategoryTypeId { get; set; }
        
        public string Name { get; set; }

        public short Position { get; set; }

        public CategoryTypeModel()
        {
            Name = string.Empty;
        }
    }
}
