namespace UnityNexus.Server.Shared.Models
{
    [Table("user_notification_settings")]
    public partial class UserNotificationSettings
    {
        public UserNotificationSettings()
        {
            UserId = UserId.From(Guid.Empty);
            NotificationFlagSum = (int)NotificationFlag.Important + (int)NotificationFlag.SubmissionEvents;
        }

        [Key]
        [Column("user_id")]
        public UserId UserId { get; set; }

        [Column("notification_flag_sum")]
        public int NotificationFlagSum { get; set; }
    }
}
