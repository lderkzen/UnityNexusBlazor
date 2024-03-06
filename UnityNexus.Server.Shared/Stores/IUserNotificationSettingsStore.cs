namespace UnityNexus.Server.Shared.Stores
{
    public interface IUserNotificationSettingsStore
    {
        public Task<UserNotificationSettings> GetUserNotificationSettingsByUserIdAsync(UserId userId);
        public Task<Exception?> UpdateUserNotificationSettingsAsync(UserId userId, int newValue);
        public Task<Exception?> UpdateUserNotificationSettingsAsync(UserNotificationSettings userNotificationSettings, int newValue);
        public Task<Exception?> ResetUserNotificationSettingsAsync(UserNotificationSettings userNotificationSettings);
        public Task<Exception?> SaveChangesAsync();
    }
}
