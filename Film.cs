using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    public class Film : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly static Dictionary<string, string[]> relatedProperties = new Dictionary<string, string[]>()
        {
            ["Tytuł"] = new string[] { "ImięNazwisko", "FormatListy" },
            ["Reżyser"] = new string[] { "ImięNazwisko", "FormatListy" },
            ["Wydawca"] = new string[] { "Wiek", "FormatListy" },
            ["DataWydania"] = new string[] { "Wiek", "FormatListy" }
        };
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (relatedProperties.ContainsKey(propertyName))
                foreach (string relatedProperty in relatedProperties[propertyName])
                    OnPropertyChanged(relatedProperty);
            //śledzenie zapobiegające stack overflow?
        }

        static uint następneID = 0;
        /*uint wiek = 0;*/
        string
            tytuł,
            reżyser,
            studio
            ;
        DateTime?
            dataWydania
            ;

        public string Tytuł
        {
            get => tytuł;
            set
            {
                tytuł = value;
                OnPropertyChanged();
            }
        }
        public string Reżyser
        {
            get => reżyser;
            set
            {
                reżyser = value;
                OnPropertyChanged();
            }
        }
        public string Studio
        {
            get => studio;
            set
            {
                studio = value;
                OnPropertyChanged();
            }
        }
        public DateTime? DataWydania
        {
            get => dataWydania;
            set
            {
                dataWydania = value;
                OnPropertyChanged();
            }
        }
        public string Info { get => $"{tytuł}, {reżyser}"; }
        public string FormatListy { get => $"{tytuł}, {reżyser}, {studio}"; }
        public uint ID { get; } = następneID++;
        public string FormatID { get => "ID: " + ID; }
    }
}
