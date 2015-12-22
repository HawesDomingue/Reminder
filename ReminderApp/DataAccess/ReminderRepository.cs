using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Resources;
using System.Xml;
using System.Xml.Linq;
using ReminderApp.Model;

namespace ReminderApp.DataAccess
{
    public class ReminderRepository
    {
        private readonly List<Reminder> _reminders;

        public ReminderRepository(string reminderDataFile)
        {
            _reminders = LoadReminders(reminderDataFile);
        }

        /// <summary>
        /// Raised when a reminder is placed into the repository.
        /// </summary>
        public event EventHandler<ReminderAddedEventArgs> ReminderAdded;

        /// <summary>
        /// Places the specified reminder into the repository.
        /// If the reminder is already in the repository, an
        /// exception is not thrown.
        /// </summary>
        public void AddReminder(Reminder reminder)
        {
            if (reminder == null)
                throw new ArgumentNullException("reminder");

            if (!_reminders.Contains(reminder))
            {
                _reminders.Add(reminder);

                if (ReminderAdded != null)
                    ReminderAdded(this, new ReminderAddedEventArgs(reminder));
            }
        }

        /// <summary>
        /// Returns true if the specified reminder exists in the
        /// repository, or false if it is not.
        /// </summary>
        public bool ContainsReminder(Reminder reminder)
        {
            if (reminder == null)
                throw new ArgumentNullException("reminder");

            return _reminders.Contains(reminder);
        }

        /// <summary>
        /// Returns a shallow-copied list of all reminders in the repository.
        /// </summary>
        public List<Reminder> GetReminders()
        {
            return new List<Reminder>(_reminders);
        }

        private static List<Reminder> LoadReminders(string reminderDataFile)
        {
            using (Stream stream = GetResourceStream(reminderDataFile))
            using (XmlReader xmlRdr = new XmlTextReader(stream))
            {
                XElement xElement = XDocument.Load(xmlRdr).Element("reminders");
                if (xElement != null)
                    return
                        (from reminderElem in xElement.Elements("reminder")
                            select Reminder.CreateReminder(
                                (string)reminderElem.Attribute("message"),
                                TimeSpan.Parse((string) reminderElem.Attribute("interval")),
                                (bool)reminderElem.Attribute("enabled")
                                )).ToList();
                return null;
            }
        }

        private static void SaveReminders()
        {
            throw new NotImplementedException();
        }

        private static Stream GetResourceStream(string resourceFile)
        {
            Uri uri = new Uri(resourceFile, UriKind.RelativeOrAbsolute);

            StreamResourceInfo info = Application.GetResourceStream(uri);
            if (info == null || info.Stream == null)
                throw new ApplicationException("Missing resource file: " + resourceFile);

            return info.Stream;
        }
    }
}
