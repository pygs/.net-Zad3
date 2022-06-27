using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace zad3
{
    class Model
    {
        public LinkedList<Film> Lista { get; set; } = new LinkedList<Film>(new Film[] {
            new Film() {
                Tytuł = "Kształt Twojego Głosu",
                Reżyser = "Naoko Yamada",
                Studio = "Kyoto Animation",
                DataWydania = DateTime.Parse("17.09.2016")
            },
        });

        internal void OtwórzSzczegóły(Film wybrany)
        {
            Szczegóły szczegóły = new Szczegóły(wybrany);
            szczegóły.Show();
        }
        internal void DodajNowy()
        {
            Film nowa = new Film();
            Lista.AddLast(nowa);
            Szczegóły szczegóły = new Szczegóły(nowa);
            szczegóły.Show();
            ICollectionView view = CollectionViewSource.GetDefaultView(Lista);
            view.Refresh();
        }
    }
}
