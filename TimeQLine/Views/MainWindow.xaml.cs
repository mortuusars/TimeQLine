using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace TimeQLine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event EventHandler GlobalHotkeyPressed;

        public MainWindow() {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            IntPtr handle = new WindowInteropHelper(this).Handle;
            HwndSource source = HwndSource.FromHwnd(handle);
            source.AddHook(HwndHook);

            //Register
            bool isRegistered = RegisterHotKey(handle, HOTKEY_ID, MOD_CONTROL + MOD_SHIFT, HOME);

            if (isRegistered)
                MortuusLogger.Logger.Log("Global hotkey registered", MortuusLogger.LogLevel.DEBUG);                
        }

        #region Global Hotkey

        //Modifiers:
        private const uint MOD_NONE = 0x0000; //[NONE]
        private const uint MOD_ALT = 0x0001; //ALT
        private const uint MOD_CONTROL = 0x0002; //CTRL
        private const uint MOD_SHIFT = 0x0004; //SHIFT

        //Keys
        private const uint HOME = 0x24;

        private const int HOTKEY_ID = 1;


        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);


        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) {
            const int WM_HOTKEY = 0x0312;
            switch (msg) {
                case WM_HOTKEY:
                    switch (wParam.ToInt32()) {
                        case HOTKEY_ID:
                            int vkey = (((int)lParam >> 16) & 0xFFFF);
                            if (vkey == HOME) {
                                GlobalHotkeyPressed?.Invoke(this, EventArgs.Empty);
                            }
                            handled = true;
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }

        #endregion
    }
}
