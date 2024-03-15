using Microsoft.Maui.Controls;
using System;

namespace MiPark;

public partial class ParkInfo : ContentPage
{
    private Park _selectedPark;

    public ParkInfo(Park selectedPark)
    {
        InitializeComponent();
        _selectedPark = selectedPark;
        addressLabel.Text = $"Endere�o: {_selectedPark.Street}";
        cityLabel.Text = $"Cidade: {_selectedPark.City}";
        zipCodeLabel.Text = $"C�digo Postal: {_selectedPark.ZIPCODE}";
    }

    private async void OnSaveAvailabilityClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Disponibilidade Salva", "A disponibilidade foi atualizada com sucesso.", "OK");
    }
}
