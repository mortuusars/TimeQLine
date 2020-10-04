using System;
using System.IO;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;
using MortuusLogger;
using TimeQLine.Core;

namespace TimeQLine
{
    public static class Program
    {
        private const string APP_NAME = "TimeQLine";
        private const string LOG_FILENAME = "log.txt";

        /// <summary>
        /// Path to temporary folder to store various help files.
        /// </summary>
        public static string APP_TEMPPATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + APP_NAME + "\\";

        private static TaskbarIcon taskbarIcon;
        private static MainWindow mainWindow;
        private static CommandView commandView;
        private static CommandViewModel commandViewModel;

        /// <summary>
        /// Entry point.
        /// </summary>
        public static void Initialize()
        {
            taskbarIcon = (TaskbarIcon)Application.Current.FindResource("TrayIcon");

            CreateAppFolder();

            LoggingSetup();

            ShowMainWindow();
        }        


        /// <summary>
        /// Shows CommandView. Closes it if already open.
        /// </summary>
        public static void ShowCommandView()
        {
            if (commandView == null)
            {
                commandViewModel = new CommandViewModel();

                commandView = new CommandView();
                commandView.DataContext = commandViewModel;
                commandView.Show();
            }
            else
            {
                commandView.Close();
                commandView = null;
                commandViewModel = null;
            }
        }

        public static void ParseCommand(string command)
        {
            var parser = new CommandParser();
            var parsedData = parser.Parse(command);

            string parsedDataString = $"{parsedData.MainCommand} - {parsedData.OperationCommand} - {parsedData.Hours} - {parsedData.Minutes} - {parsedData.Seconds}";

            Logger.Log(parsedDataString, LogLevel.DEBUG);
        }

        /// <summary>
        /// Properly closes an application.
        /// </summary>
        public static void ExitApplication()
        {
            taskbarIcon.Dispose();
            Application.Current.Shutdown();
        }

        #region Private Methods

        private static void ShowMainWindow()
        {
            mainWindow = new MainWindow();
            mainWindow.GlobalHotkeyPressed += (s, e) => ShowCommandView();
            mainWindow.Show();
            mainWindow.Hide();
        }

        private static void CreateAppFolder()
        {
            Directory.CreateDirectory(APP_TEMPPATH);
        }

        private static void LoggingSetup()
        {
            Logger.LoggerInstance = new FileLogger(APP_TEMPPATH + LOG_FILENAME);
            Logger.LoggerInstance.GotException += (s, e) => MessageBox.Show(e.Message);
            Logger.LoggingLevel = LogLevel.DEBUG;
            Logger.Log("\n--------Start of a program--------", LogLevel.DEBUG);
        }

        #endregion
    }
}