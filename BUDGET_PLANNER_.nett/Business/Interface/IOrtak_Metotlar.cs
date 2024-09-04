using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    interface IOrtak_Metotlar
    {
        bool Ekle();
        bool Guncelle();
        bool Sil();
        void TumunuGetir();
    }
}
