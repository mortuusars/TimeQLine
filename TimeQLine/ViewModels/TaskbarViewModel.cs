using System;
using System.Windows.Input;
using MortuusLogger;

namespace TimeQLine
{
    public class TaskbarViewModel
    {
        public ICommand TrayDoubleClickCommand { get; private set; }

        public ICommand RunCommandWindowCommand { get; private set; }
        public ICommand ConfigCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }

        public TaskbarViewModel()
        {
            TrayDoubleClickCommand = new RelayCommand(act => { Program.ShowCommandView(); }); //Empty for now

            RunCommandWindowCommand = new RelayCommand(act => { Program.ShowCommandView(); });
            ConfigCommand = new RelayCommand(act => { Logger.Log("Config opened", LogLevel.DEBUG); });
            ExitCommand = new RelayCommand(act => { Program.ExitApplication(); });
        }
    }
}
