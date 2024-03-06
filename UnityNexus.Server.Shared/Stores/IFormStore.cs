namespace UnityNexus.Server.Shared.Stores
{
    public interface IFormStore
    {
        public Task<Form> GetFormByIdAsync(FormId formId, bool tracking = false);
        public Task<Form> GetApplicationFormAsync(GroupId groupId, bool tracking = false);
        public Task<List<Form>> GetFormsAsync(bool tracking = false);
        public Task<List<Form>> GetAllFormsByGroupdIdAsync(GroupId groupId, bool tracking = false);

        public void CreateForm(Form form, GroupId? groupId, bool isApplicationForm = false);
        public Task<(Dictionary<string, (string OldValue, string NewValue)>? Changes, Exception? Exception)> UpdateFormAsync(
            Form dbEntity,
            Form requestEntity
        );
        public Task<Exception?> DeleteFormAsync(Form form);
        public Task<Exception?> DestroyDeletedFormAsync(Form form);
        public Task<Exception?> SaveChangesAsync();
    }
}
