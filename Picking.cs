using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiAppWearOsPicking
{
    public partial class Picking : ObservableObject
    {
        [ObservableProperty]
        string codice;

        [ObservableProperty]
        string descrizione;

        [ObservableProperty]
        string locazione;

        [ObservableProperty]
        int quantita;

        [ObservableProperty]
        int quantitaPicked;

        public Picking() { }

        public Picking(string codice, string descrizione, string locazione, int quantita)
        {
            Codice = codice;
            Descrizione = descrizione;
            Locazione = locazione;
            Quantita = quantita;
            QuantitaPicked = 0;
        }
    }
}
