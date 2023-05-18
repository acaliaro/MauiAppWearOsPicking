﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppWearOsPicking.Messages;
using System.Collections.ObjectModel;

namespace MauiAppWearOsPicking
{
    public partial class MainViewModel : BaseViewModel, IRecipient<ScannerMessage>
    {

        [ObservableProperty]
        ObservableCollection<Picking> pickings = new();

        [ObservableProperty]
        Picking currentPicking;

        int current = 0;
        public MainViewModel()
        {

            FillData();
        }

        private void FillData()
        {
            if(current == 0)
            {
                Pickings.Clear();
                Pickings.Add(new Picking("1234567890123", "001", "Latte 1l", "Location A", 5));
                Pickings.Add(new Picking("2234567890123", "002", "Burro 500g", "Location B", 3));
                Pickings.Add(new Picking("3234567890123", "003", "Yogurt 30g", "Location C", 1));
                Pickings.Add(new Picking("4234567890123", "004", "Taleggio 100g", "Location E", 6));
            }

            CurrentPicking = Pickings[current];
        }

        [RelayCommand]
        async Task PickAsync()
        {
            CurrentPicking.QuantitaPicked++;

            if(CurrentPicking.QuantitaPicked == CurrentPicking.Quantita)
                await SkipAsync();
        }

        [RelayCommand]
        async Task SkipAsync()
        {
            if (current < Pickings.Count - 1)
            {
                current++;
                FillData();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Attenzione", "Picking concluso", "Ok");
                current = 0;
                FillData();
            }
        }

        public async void Receive(ScannerMessage message)
        {
            System.Diagnostics.Debug.WriteLine(message != null ? message.Value : "MainViewModel");

            if(CurrentPicking.Barcode == message.Value)
            {
                await PickAsync();
            }
          
        }
    }
}
