namespace UnityNexus.Server.Shared.Stores
{
    public interface IFormStore
    {
        public Task<List<Form>> GetAllFormsAsync(bool tracking);
        public Task<List<Form>> GetAllFormsWithoutGroupAsync(bool tracking);
        public Task<List<Form>> GetAllFormsByGroupIdAsync(int groupId, bool tracking);
        public Task<List<Question>> GetAllQuestionsByFormIdAsync(int formId, bool tracking);
    }
}
