using System;
using ReminderApp.Model;

namespace ReminderApp.DataAccess
{
    /// <summary>
    /// Event arguments used by ReminderRepository's ReminderAdded event.
    /// </summary>
    public class ReminderAddedEventArgs : EventArgs
    {
        public ReminderAddedEventArgs(Reminder newReminder)
        {
            NewReminder = newReminder;
        }

        public Reminder NewReminder { get; private set; }
    }
}