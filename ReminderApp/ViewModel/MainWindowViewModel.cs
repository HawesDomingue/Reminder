using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using ReminderApp.DataAccess;

namespace ReminderApp.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ReminderRepository _reminderRepository;
        private RelayCommand _closeCommand;

        private string _newMessage;
        private int _newDays;
        private int _newHours;
        private int _newMinutes;
        private int _newSeconds;

        private RelayCommand _addCommand;

        public MainWindowViewModel(string reminderDataFile)
        {
            _reminderRepository = new ReminderRepository(reminderDataFile);

            // Subscribe for notifications of when a new reminder is saved.
            _reminderRepository.ReminderAdded += OnReminderAddedToRepository;

            // Populate the AllReminders collection with ReminderViewModels.
            CreateAllReminders(); 
        }

        void CreateAllReminders()
        {
            List<ReminderViewModel> all =
                (from cust in _reminderRepository.GetReminders()
                 select new ReminderViewModel(cust, _reminderRepository)).ToList();

            foreach (ReminderViewModel cvm in all)
                cvm.PropertyChanged += OnReminderViewModelPropertyChanged;

            AllReminders = new ObservableCollection<ReminderViewModel>(all);
            AllReminders.CollectionChanged += OnCollectionChanged;
        }

        public ObservableCollection<ReminderViewModel> AllReminders { get; private set; }

        public string NewMessage
        {
            get { return _newMessage; }
            set
            {
                if (_newMessage != value)
                {
                    _newMessage = value;
                    NotifyPropertyChanged("NewMessage");
                }
            }
        }

        public ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new RelayCommand(param => OnRequestClose())); }
        }

        public event EventHandler RequestClose;

        private void OnRequestClose()
        {
            EventHandler handler = RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (ReminderViewModel reminderVM in e.NewItems)
                    reminderVM.PropertyChanged += OnReminderViewModelPropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ReminderViewModel reminderVM in e.OldItems)
                    reminderVM.PropertyChanged -= OnReminderViewModelPropertyChanged;
        }

        private void OnReminderViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string isSelected = "IsSelected";

            // Make sure that the property name we're referencing is valid.
            // This is a debugging technique, and does not execute in a Release build.
            ReminderViewModel reminderViewModel = sender as ReminderViewModel;
            if (reminderViewModel != null) 
                reminderViewModel.VerifyPropertyName(isSelected);

            // When a reminder is selected or unselected, we must let the
            // world know that the TotalSelectedSales property has changed,
            // so that it will be queried again for a new value.
            if (e.PropertyName == isSelected)
                NotifyPropertyChanged("TotalSelectedSales");
        }

        private void OnReminderAddedToRepository(object sender, ReminderAddedEventArgs e)
        {
            var viewModel = new ReminderViewModel(e.NewReminder, _reminderRepository);
            AllReminders.Add(viewModel);
        }
    }
}
