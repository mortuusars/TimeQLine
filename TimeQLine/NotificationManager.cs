using System;
using System.Collections.Generic;
using System.Text;

namespace TimeQLine
{
    public static class NotificationManager
    {
        private static NotificationViewModel notificationViewModel;
        private static NotificationView notificationView; 

        public static void ShowNotification(string title, string message)
        {
            if (notificationView == null)
                CreateNotificationWindow();

            notificationView.Show();
            notificationViewModel.AddNotification(title, message);
        }

        private static void CreateNotificationWindow()
        {
            notificationViewModel = new NotificationViewModel();
            notificationView = new NotificationView() { DataContext = notificationViewModel };

            notificationView.Show();
        }
    }
}
