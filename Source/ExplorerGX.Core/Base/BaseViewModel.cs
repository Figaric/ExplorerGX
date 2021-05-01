using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ExplorerGX.Core
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private readonly object _locker = new object();

        #region On Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        protected async Task RunCommandAsync(Expression<Func<bool>> isBusyFlag, Func<Task> action)
        {
            lock(_locker)
            {
                if (isBusyFlag.GetValue())
                    return; // If the command is already running, return

                isBusyFlag.SetValue(true);
            }

            try
            {
                await action.Invoke();
            }
            finally
            {
                isBusyFlag.SetValue(false);
            }
        }
    }
}
