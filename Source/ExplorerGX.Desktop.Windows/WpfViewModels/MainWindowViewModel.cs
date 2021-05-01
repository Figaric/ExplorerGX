using ExplorerGX.Core;
using System.Windows;

namespace ExplorerGX.Desktop.Windows
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Private fields

        private readonly MainWindow _window;

        private readonly WindowResizer _resizer;

        private WindowDockPosition _dockPosition = WindowDockPosition.Undocked;

        #endregion

        #region Inner Padding Size

        private readonly int _innerPaddingSize = 10;

        public int InnerPaddingSize => _window.WindowState == WindowState.Maximized ? 0 : _innerPaddingSize;

        public Thickness InnerPaddingSizeThickness => new Thickness(InnerPaddingSize);

        #endregion

        #region Resize Border Thickness

        private readonly int _resizeBorder = 4;

        public int ResizeBorder => _window.WindowState == WindowState.Maximized ? 0 : _resizeBorder;

        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + _innerPaddingSize);

        #endregion

        #region Title Bar Height

        public int TitleBarHeight => 46;

        public int CaptionHeight => _window.WindowState == WindowState.Maximized ? TitleBarHeight - _innerPaddingSize : TitleBarHeight - _resizeBorder;

        #endregion

        public MainWindowViewModel(MainWindow window)
        {
            _window = window;

            _resizer = new WindowResizer(_window);

            // Window State events initialization
            _window.StateChanged += (s, e) => WindowResized();
            _resizer.WindowDockChanged += OnWindowDockChanged;
        }

        #region On Window State Changed

        private void OnWindowDockChanged(WindowDockPosition dockPosition)
        {
            _dockPosition = dockPosition;

            WindowResized();
        }

        public void WindowResized()
        {
            // Update resize border
            OnPropertyChanged(nameof(ResizeBorderThickness));

            // Update inner padding size
            OnPropertyChanged(nameof(InnerPaddingSizeThickness));

            // Update title bar height
            OnPropertyChanged(nameof(CaptionHeight));
        }

        #endregion
    }
}
