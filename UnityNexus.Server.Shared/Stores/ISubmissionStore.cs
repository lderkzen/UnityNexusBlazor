namespace UnityNexus.Server.Shared.Stores
{
    public interface ISubmissionStore
    {
        public Task<Submission> GetSubmissionIdAsync(SubmissionId submissionId, bool tracking = false);
        public Task<List<Submission>> GetSubmissionsAsync(bool tracking = false);
        public Task<int> CountSubmissionsByFilterAsync(string? filter, bool tracking = false);
        public Task<List<Submission>> GetSubmissionsByFilterAsync(string? filter, bool tracking = false);
        public Task<List<Submission>> GetSubmissionsByFilterAndPageAsync(string? filter, int skip, int take, bool tracking = false);
        public Task<List<Submission>> GetPendingSubmissionsAsync(FormId? formId, bool tracking = false);

        public Task<UserModel> GetApplicantBySubmissionIdAsync(SubmissionId submissionId);
        public Task<UserModel> GetApplicantAsync(Submission submission);

        public Task<int> CountSubmissionsByFormIdAsync(FormId formId);

        public void CreateSubmission(Submission submission);
        public Task<(Dictionary<string, (string OldValue, string NewValue)>? Changes, Exception? Exception)> UpdateSubmissionAsync(
            Submission dbEntity,
            Submission requestEntity
        );
        public Task<Exception?> DeleteSubmissionAsync(Submission submission);
        public Task<Exception?> DestroyDeletedSubmissionAsync(Submission submission);
        public Task<Exception?> SaveChangesAsync();
    }
}
