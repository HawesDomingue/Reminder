using System;
using ReminderApp.DataAccess;
using ReminderApp.Model;

namespace ReminderApp.ViewModel
{
    public class ReminderViewModel : ViewModelBase
    {
        private readonly Reminder _reminder;
        private readonly ReminderRepository _reminderRepository;

        public ReminderViewModel(Reminder reminder, ReminderRepository reminderRepository)
        {
            if (reminder == null)
                throw new ArgumentNullException("reminder");
            if (reminderRepository == null)
                throw new ArgumentNullException("reminderRepository");

            _reminder = reminder;
            _reminderRepository = reminderRepository;
        }

        public string Message
        {
            get { return _reminder.Message; }
            set
            {
                if (_reminder.Message == value)
                    return;

                _reminder.Message = value;
                NotifyPropertyChanged("Message");
            }
        }

        public TimeSpan Interval
        {
            get { return _reminder.Interval; }
            set
            {
                if (_reminder.Interval == value)
                    return;

                _reminder.Interval = value;
                NotifyPropertyChanged("Interval");
            }
        }

        public bool Enabled
        {
            get { return _reminder.Enabled; }
            set
            {
                if (_reminder.Enabled == value) 
                    return;

                _reminder.Enabled = value;
                NotifyPropertyChanged("Enabled");
            }
        }
    }
}
