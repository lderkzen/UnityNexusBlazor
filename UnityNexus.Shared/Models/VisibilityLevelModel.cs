namespace UnityNexus.Shared.Models
{
    public class VisibilityLevelModel
    {
        public byte VisibilityLevelId { get; set; }
        public string Name { get; set; }

        public VisibilityLevelModel()
        {
            Name = string.Empty;
        }
    }
}
