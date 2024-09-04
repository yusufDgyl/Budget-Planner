using Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Work
{
    public class DefterIsletme
    {
        // defter işletme bilgilerini her sayfada tek tek veritabanından çekmek yerine session'a buradaki bilgileri atarak kullanacağız.

        public Defterler Defter { get; set; }
        public Isletme Isletme { get; set; }
        


    }
}
