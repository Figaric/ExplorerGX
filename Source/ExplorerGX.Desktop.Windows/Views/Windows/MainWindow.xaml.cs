using System.Windows;

namespace ExplorerGX.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel(this);

            this.PageFrame.Content = new MainPage();
        }
    }
}
