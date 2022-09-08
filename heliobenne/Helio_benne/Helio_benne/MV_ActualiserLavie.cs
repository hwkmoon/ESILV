using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

namespace Helio_benne
{
    class MV_ActualiserLaVie : INotifyCollectionChanged, IEnumerable
    {
        private ObservableCollection<MV_Vie> mvlavie { get; set; }

        public MV_ActualiserLaVie()
        {
            mvlavie = new ObservableCollection<MV_Vie>();
        }
        public ObservableCollection<MV_Vie> ListeMVVie
        {
            get { return this.mvlavie; }
            set
            {
                mvlavie = value;
            }
        }

        #region implémentation de l'interface System.Collections.Specialized.INotifyCollectionChanged

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, args);
            }
        }

        #endregion

        #region implémentation de l'interface  System.Collections.IEnumerable

        public IEnumerator GetEnumerator()
        {
            return mvlavie.GetEnumerator();
        }


        #endregion


        public ObservableCollection<MV_Vie> actualiserLaVie()
        {
            M_GestionnaireDonnees gd = new M_GestionnaireDonnees();
            List<M_Vie> liste_vie = new List<M_Vie>();
            liste_vie = gd.GetPresenceVie();

            foreach (M_Vie vie in liste_vie)
            {
                string time = vie.Time;
                string vieon = vie.NombreDechets;
                MV_Vie mv_vie = new MV_Vie(time, vieon);
                mvlavie.Add(mv_vie);
            }
            return mvlavie;
        }
    }
}
