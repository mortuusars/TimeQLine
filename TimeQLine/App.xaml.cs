using System.Windows;

namespace TimeQLine
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e) {
            Program.Initialize();
        }
    }
}
