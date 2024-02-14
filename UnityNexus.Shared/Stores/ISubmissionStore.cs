namespace UnityNexus.Shared.Stores
{
    public interface ISubmissionStore
    {
        public Task<List<Submission>> GetAllSubmissionsAsync(bool tracking);
        public Task<List<Submission>> GetAllSubmissionsByUserGuidAsync(Guid userGuid, bool tracking);
        public Task<List<Submission>> GetAllSubmissionsByFormIdAsync(int formId, bool tracking);
        public Task<List<Submission>> GetAllSubmissionsByStatusAsync(SubmissionStatus submissionStatus, bool tracking);
        public Task<List<Answer>> GetAllAnswersBySubmissionIdAsync(int submissionId, bool tracking);
    }
}
