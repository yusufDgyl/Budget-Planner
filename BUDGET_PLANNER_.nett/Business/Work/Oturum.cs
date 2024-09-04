using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Work
{
    public class Oturum
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string kulAdi;

        public string KulAdi
        {
            get { return kulAdi; }
            set { kulAdi = value; }
        }
        bool loginMi;

        public bool LoginMi
        {
            get { return loginMi; }
            set { loginMi = value; }
        }
    }
}
