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
    class MV_ActualiserDechet : INotifyCollectionChanged, IEnumerable
    {
        private ObservableCollection<MV_Dechet> mvdechets { get; set; }


        public MV_ActualiserDechet()
        {
            mvdechets = new ObservableCollection<MV_Dechet>();
        }
        public ObservableCollection<MV_Dechet> ListeMVDechet
        {
            get { return this.mvdechets; }
            set
            {
                mvdechets = value;
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
            return mvdechets.GetEnumerator();
        }


        #endregion


        public ObservableCollection<MV_Dechet> actualiserDechet()
        {
            M_GestionnaireDonnees gd = new M_GestionnaireDonnees();
            List<M_Dechet> listedechets = new List<M_Dechet>();
            listedechets = gd.GetDechets();

            foreach (M_Dechet dechet in listedechets)
            {
                string time = dechet.Time;
                string nbd = dechet.NombreDechets;
                MV_Dechet mv_dechet = new MV_Dechet(time, nbd);
                mvdechets.Add(mv_dechet);
            }
            return mvdechets;
        }
     
    }
}