using Microsoft.Maui.Controls;
using System;

namespace MiPark
{
    public partial class ParkRegister : ContentPage
    {
        private Owner _currentOwner;

        public ParkRegister(Owner currentOwner)
        {
            InitializeComponent();
            _currentOwner = currentOwner;

            // Defina o pa�s como "Espa�a" por padr�o e desative a edi��o inicialmente
            countryEntry.Text = "Espa�a";
            countryEntry.IsEnabled = false;
        }
        private void OnCountryCheckboxChanged(object sender, CheckedChangedEventArgs e)
        {
            // Permita a edi��o do campo Pa�s se o CheckBox estiver marcado
            countryEntry.IsEnabled = e.Value;
        }

        private async void OnRegisterGarageClicked(object sender, EventArgs e)
        {
            // Cria uma nova inst�ncia de Park com os dados do formul�rio
            var park = new Park
            {
                Street = streetEntry.Text,
                Number = numberEntry.Text,
                AdditionalInfo = additionalInfoEntry.Text,
                City = cityEntry.Text,
                Province = provinceEntry.Text,
                ZIPCODE = zipCodeEntry.Text,
                Country = countryEntry.Text
            };

            _currentOwner.AddPark(park);

            await DataStorage.SaveOwnerDataAsync(_currentOwner);

            await DisplayAlert("Registro", "Garagem registrada com sucesso.", "OK");
            await Navigation.PushAsync(new DashboardPage(_currentOwner));
        }
    }
}