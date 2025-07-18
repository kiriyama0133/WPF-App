using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace myapp
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();

            // 创建viewmodel
            this.DataContext = mainViewModel;
        }

        private void CustomTitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (e.ClickCount == 1)
                {
                    this.DragMove();
                }
                else if (e.ClickCount == 2)
                {
                    MaximizeRestoreButton_Click(sender, e);
                }
            }
        }


        private const double CollapsedWidth = 78; // When the menu is "collapsed" (only icons)
        private const double ExpandedWidth = 160;  // When the menu is "expanded" (icons + text)

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da1 = new DoubleAnimation();
            da1.Duration = TimeSpan.FromSeconds(0.3); // A slightly faster, snappier duration (0.3s-0.5s is common)
            // Optional: Add an EasingFunction for smoother animation
            da1.EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut };
            // Determine current state and set From/To values accordingly
            if (menu_listbox.ActualWidth > CollapsedWidth + 5) // Use a small buffer to avoid floating point issues
            {
                // Currently expanded, so collapse it
                da1.From = menu_listbox.ActualWidth;
                da1.To = CollapsedWidth;
            }
            else
            {
                // Currently collapsed (or near collapsed), so expand it
                da1.From = menu_listbox.ActualWidth;
                da1.To = ExpandedWidth;
            }
            // Start the animation on the WidthProperty of menu_listbox
            menu_listbox.BeginAnimation(WidthProperty, da1);
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeRestoreButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                MaximizeRestoreIcon.Kind = Material.Icons.MaterialIconKind.SquareOutline;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                MaximizeRestoreIcon.Kind = Material.Icons.MaterialIconKind.WindowRestore;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}