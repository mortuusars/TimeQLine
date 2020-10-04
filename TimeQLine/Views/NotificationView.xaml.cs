using System.Windows;
using WpfScreenHelper;

namespace TimeQLine
{
    /// <summary>
    /// Interaction logic for NotificationView.xaml
    /// </summary>
    public partial class NotificationView : Window
    {
        public NotificationView()
        {
            InitializeComponent();

            var screenBounds = Screen.PrimaryScreen.Bounds;

            this.Left = (screenBounds.Width / 2) - (this.Width / 2);
            this.Top = screenBounds.Bottom * 0.9 - this.Height;
        }
    }
}
