using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfReusabilitySample.ViewModel;

namespace WpfReusabilitySample.Services
{
    public interface ICatsService
    {
        IEnumerable<Cat> GetAll();
    }
}
