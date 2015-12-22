using System;

namespace ReminderApp.Model
{
    public class Reminder
    {
        public static Reminder CreateNewReminder()
        {
            return new Reminder();
        }

        public static Reminder CreateReminder(
            string message,
            TimeSpan interval,
            bool enabled)
        {
            return new Reminder
            {
                Message = message,
                Interval = interval,
                Enabled = enabled
            };
        }

        protected Reminder()
        {
        }

        public string Message { get; set; }
        public TimeSpan Interval { get; set; }
        public bool Enabled { get; set; }
    }
}
