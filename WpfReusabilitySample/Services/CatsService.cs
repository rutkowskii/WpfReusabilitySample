using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfReusabilitySample.ViewModel;

namespace WpfReusabilitySample.Services
{
    public class CatsService : ICatsService
    {
        public IEnumerable<Cat> GetAll()
        {
            return getCatsQuickly();
        }
        private static IEnumerable<Cat> getCatsQuickly()
        {

            

            for (int i = 0; i < 40; i++)
            {
                Thread.Sleep(1000);
                yield return new Cat { Name = "RUMCAJS", Nickname = "FAJNY KOT" };
                Thread.Sleep(1000);
                yield return new Cat { Name = "FELEK", Nickname = "KOT HUNCWOT" };
            }
        }
    }
}
