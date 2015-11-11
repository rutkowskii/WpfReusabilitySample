using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using WpfReusabilitySample.Services;
using WpfReusabilitySample.Utils;

namespace WpfReusabilitySample.ViewModel
{

   

   
    public class MainViewModel : ViewModelBase
    {
        private ICatsService _iCatsService;
        private AsyncAction _loadAction;


        public MainViewModel(ICatsService ics)
        {
            Title1 = "TO JEST TYTUŁ NR 11111111";
            _iCatsService = ics;

            _loadAction = new AsyncAction((ct) =>
            {
                foreach (var cat in _iCatsService.GetAll())
                {
                    ct.ThrowIfCancellationRequested();
                    App.Current.Dispatcher.Invoke(delegate
                    {
                        CatsCollection.Add(cat);
                    });
                }
            });
            _loadAction.PropertyChanged += _loadAction_PropertyChanged;

            Title2 = "TO JEST TYTUŁ NR 22222222";
            CatsCollection = new ObservableCollection<Cat>();
            CatsCollection.CollectionChanged += CatsCollection_CollectionChanged;
            CleanCommand = new RelayCommand(CleanCatsCollections);
            LoadCommand = new RelayCommand(LoadCats, () => !_loadAction.IsRunning);
            CancelCommand = new RelayCommand(() => _loadAction.Cancel(), () => _loadAction.IsRunning);
        }

        private void CatsCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("NoCat");
        }

        public bool NoCat
        {
            get { return CatsCollection.Count == 0; }
        }

        private void _loadAction_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "IsRunning")
            {
                LoadCommand.RaiseCanExecuteChanged();
                CancelCommand.RaiseCanExecuteChanged();
            }
        }

        private void CleanCatsCollections()
        {
            CatsCollection.Clear();
        }
        private void LoadCats()
        {
            _loadAction.Run();
        }


        private string _title1;
        private string _title2;
        public string Title1 {
            get
            {
                return _title1;
            }
            set
            {
                _title1 = value;
                RaisePropertyChanged("Title1");
            }
        }
        public string Title2
        {
            get
            {
                return _title2;
            }
            set
            {
                _title2 = value;
                RaisePropertyChanged("Title2");
            }
        }

        private ObservableCollection<Cat> _catsCollection;
        public ObservableCollection<Cat> CatsCollection
        {
            get { return _catsCollection; }
            set
            {
                _catsCollection = value;
                RaisePropertyChanged("CatsCollection");
            }
        }
        public RelayCommand CleanCommand { get; private set; }
        public RelayCommand LoadCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
    }
}