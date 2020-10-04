using System.ComponentModel;
using System.Windows.Input;

namespace TimeQLine
{
    public class CommandViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Input { get; set; }
        public ICommand ConfirmCommand { get; private set; }

        public CommandViewModel()
        {
            ConfirmCommand = new RelayCommand(act => Program.ParseCommand(Input));
        }
    }
}
