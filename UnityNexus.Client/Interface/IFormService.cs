namespace UnityNexus.Client.Interface
{
    public interface IFormService
    {
        public static FormBuilder CreateFormBuilder()
        {
            return new FormBuilder();
        }
    }
}
