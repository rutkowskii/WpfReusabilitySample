using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfReusabilitySample.Utils
{
    public class AsyncAction : ObservableObject
    {
        private Action<CancellationToken> _a;
        private CancellationTokenSource _cts;

        public AsyncAction(Action<CancellationToken> a)
        {
            _a = a;

        }

        public async void Run()
        {
            IsRunning = true;
            _cts = new CancellationTokenSource();
            await Task.Run(() => {
                try {
                    _a(_cts.Token);
                }catch(OperationCanceledException e)
                {
                    if(OnCancel != null) OnCancel(this, new EventArgs());
                }
                finally
                {
                    _cts.Dispose();
                }
            });
            IsRunning = false;
        }
        public void Cancel()
        {
            _cts.Cancel();
            IsRunning = false;
        }

        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
            private set
            {
                _isRunning = value;
                RaisePropertyChanged("IsRunning");
            }
        }

        public event EventHandler OnCancel;


    }
}
