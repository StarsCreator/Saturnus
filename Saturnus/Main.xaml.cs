using System.Windows;
using System.Windows.Input;
using System.Windows.Controls.Primitives;

namespace Saturnus
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                {
                    Visibility = Visibility.Hidden;
                    ResultsPopup.IsOpen = false;
                    break;
                }
            }
        }

        private void Window_Activated(object sender, System.EventArgs e)
        {
            InputFld.Focus();
            InputFld.SelectAll();
            //ResultsPopup.IsOpen = true;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Deactivated(object sender, System.EventArgs e)
        {
            //ResultsPopup.IsOpen = false;
            //Visibility = Visibility.Hidden;
            //ResultsPopup.IsOpen = false;
        }

        private void InputFld_KeyDown(object sender, KeyEventArgs e)
        {
                        
        }

        private void InputFld_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    if (ResultBox.Items.Count > 0)
                    {
                        if (ResultBox.SelectedIndex == -1)
                            ResultBox.SelectedIndex = 0;
                        else if (ResultBox.SelectedIndex < ResultBox.Items.Count - 1)
                            ResultBox.SelectedIndex++;
                    }
                    break;

                case Key.Up:
                    if (ResultBox.Items.Count > 0)
                    {
                        if (ResultBox.SelectedIndex == -1)
                            ResultBox.SelectedIndex = 0;
                        else if (ResultBox.SelectedIndex > 0)
                            ResultBox.SelectedIndex--;
                    }
                    break;
            }
        }
    }
}