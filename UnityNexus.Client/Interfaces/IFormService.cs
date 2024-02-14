namespace UnityNexus.Client.Interfaces
{
    public interface IFormService
    {
        public static FormBuilder CreateFormBuilder()
        {
            return new FormBuilder();
        }
    }
}
