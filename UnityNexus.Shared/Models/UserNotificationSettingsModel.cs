namespace UnityNexus.Shared.Models
{
    public class UserNotificationSettingsModel
    {
        public UserId UserId { get; set; }

        public int NotificationFlagSum { get; set; }

        public UserNotificationSettingsModel()
        {
            UserId = (UserId)Guid.Empty;
        }

        public List<NotificationFlag> NotificationFlags()
        {
            List<NotificationFlag> result = [];

            for (int currentPow = 1; currentPow != 0; currentPow <<= 1)
            {
                if ((currentPow & NotificationFlagSum) != 0)
                    result.Add((NotificationFlag)currentPow);
            }

            return result;
        }
    }
}
