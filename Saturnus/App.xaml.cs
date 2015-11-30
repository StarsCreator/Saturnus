using System.Windows;
using System.Windows.Forms;
using Hardcodet.Wpf.TaskbarNotification;
using ManagedWinapi;

namespace Saturnus
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private Hotkey _hotkey;
        private TaskbarIcon _notify;
        //private MainViewModel _model;
        private Main _main;

        protected override void OnStartup(StartupEventArgs e)
        {
            #region HotKey

            _hotkey = new Hotkey
            {
                Alt = true,
                Ctrl = true
                //KeyCode = Keys.Q
                //KeyCode = System.Windows.Forms.Keys.Space
            };
            _hotkey.HotkeyPressed += hotkey_HotkeyPressed;
            try
            {
                _hotkey.Enabled = true;
            }
            catch (HotkeyAlreadyInUseException)
            {
                System.Windows.MessageBox.Show("Could not register hotkey (already in use).", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            #endregion

            #region NotifyIcon
            _notify = (TaskbarIcon)FindResource("NotifyIcon");
            #endregion

            #region Window

            _main = new Main();

            #endregion

            base.OnStartup(e);
        }

        private void hotkey_HotkeyPressed(object sender, System.EventArgs e)
        {
            _main.ShowDialog();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _notify.Dispose();
            _hotkey.Dispose();
            base.OnExit(e);
        }
    }
}