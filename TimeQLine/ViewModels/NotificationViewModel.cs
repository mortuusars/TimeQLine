using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Threading;

namespace TimeQLine
{
    public class NotificationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Notification> Notifications { get; set; }

        public NotificationViewModel()
        {
            Notifications = new ObservableCollection<Notification>();
        }

        public void AddNotification(string title, string message)
        {
            var newNotification = new Notification() { Title = title, Message = message };
            Notifications.Add(newNotification);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += (s, e) => { Notifications.Remove(newNotification); timer.Stop(); };
            
            timer.Start();
        }
    }
}
