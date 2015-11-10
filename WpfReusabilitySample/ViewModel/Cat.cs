using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfReusabilitySample.ViewModel
{
    public class Cat : ObservableObject
    {
        private string _name;
        public string Name
        {
            set {
                _name = value;
                RaisePropertyChanged("Name");
            }
            get { return _name; }
        }
        private string _nickname;
        public string Nickname
        {
            set
            {
                _nickname = value;
                RaisePropertyChanged("Nickname");
            }
            get { return _nickname; }
        }

    }
}
