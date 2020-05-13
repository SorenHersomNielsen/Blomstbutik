using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Blomstbutik
{
    public class BlomstViewModel
    {
        private string navnBlomst;
        private int antalBlomst;
        private string farveBlomst;

        public ObservableCollection<Ordreblomst> OC_Blomst { get; set; }
          = new ObservableCollection<Ordreblomst>();

        public string NavnBlomst { get => navnBlomst; set => navnBlomst = value; }

        public int AntalBlomst { get => antalBlomst; set => antalBlomst = value; }

        public string FarveBlomst { get => farveBlomst; set => farveBlomst = value; }

        public string jsonText { get; set; }

        public string filename { get; set; }

        public StorageFolder localfolder { get; set; }


        public RelayCommand AddNyBlomst { get; set; }
        public RelayCommand SelectedBlomstCommand { get; set; }
        public RelayCommand SletListeCommand { get; set; }

        public Ordreblomst SelectedBlomst { get; set; }

        public BlomstViewModel()
        {
            OC_Blomst = new ObservableCollection<Ordreblomst>();
            OC_Blomst.Add(new Ordreblomst("tulipan", 2, "Rød"));
            OC_Blomst.Add(new Ordreblomst("tulipan", 3, "Grøn"));

            AddNyBlomst = new RelayCommand(AddBlomst);
            SelectedBlomst = new Ordreblomst();
            SelectedBlomstCommand = new RelayCommand(SletBlomst);
            SletListeCommand = new RelayCommand(SletBlomsterListe);
            localfolder = ApplicationData.Current.LocalFolder;
        }

        public void AddBlomst()
        {
            Ordreblomst ordreblomst = new Ordreblomst(NavnBlomst, AntalBlomst, FarveBlomst);

            OC_Blomst.Add(ordreblomst);
        }
        private void SletBlomst()
        {
            OC_Blomst.Remove(SelectedBlomst);
        }
        public void SletBlomsterListe()
        {
            OC_Blomst.Clear();
        }
        public string getjson()
        {
            string jsonListe = JsonConvert.SerializeObject(OC_Blomst);
            return jsonListe;
        }
        public async void GemDataTilDiskAsync()
        {
            this.jsonText = getjson();

        StorageFile file = await localfolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

        await FileIO.WriteTextAsync(file, this.jsonText);
    }
}
}
