﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiAppWearOsPicking
{
    public partial class MainViewModel : BaseViewModel
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
                Pickings.Add(new Picking("001", "Latte 1l", "Location A", 5));
                Pickings.Add(new Picking("002", "Burro 500g", "Location B", 3));
                Pickings.Add(new Picking("003", "Yogurt 30g", "Location C", 1));
                Pickings.Add(new Picking("004", "Taleggio 100g", "Location E", 6));
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
    }
}