using Microsoft.Maui.Controls;
using System;
using System.Text.RegularExpressions;

namespace MiPark
{
    public partial class OwnerRegister : ContentPage
    {
        public OwnerRegister()
        {
            InitializeComponent();
            dobPicker.MaximumDate = DateTime.Now;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            // Verifica se todos os campos est�o preenchidos
            if (string.IsNullOrWhiteSpace(dniEntry.Text) ||
                string.IsNullOrWhiteSpace(nameEntry.Text) ||
                string.IsNullOrWhiteSpace(surnameEntry.Text) ||
                string.IsNullOrWhiteSpace(emailEntry.Text) ||
                string.IsNullOrWhiteSpace(ibanEntry.Text) ||
                string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                return;
            }

            // Verifica��o do formato do DNI
            if (!ValidateDNI(dniEntry.Text))
            {
                await DisplayAlert("Erro", "DNI inv�lido. O formato correto � 8 n�meros seguidos por uma letra.", "OK");
                return;
            }

            // Verifica��o do formato do IBAN
            if (!ValidateIBAN(ibanEntry.Text))
            {
                await DisplayAlert("Erro", "IBAN inv�lido. O formato correto s�o 2 letras seguidas por 22 n�meros.", "OK");
                return;
            }

            // Verifica��o do formato do e-mail
            if (!EmailIsValid(emailEntry.Text))
            {
                await DisplayAlert("Erro", "E-mail inv�lido. Por favor, insira um endere�o de e-mail v�lido.", "OK");
                return;
            }

            // Verifica��o da for�a da senha
            if (passwordEntry.Text.Length < 8)
            {
                await DisplayAlert("Erro", "A senha deve ter pelo menos 8 caracteres.", "OK");
                return;
            }

            var owner = new Owner
            {
                DNI = dniEntry.Text,
                Name = nameEntry.Text,
                Surname = surnameEntry.Text,
                DoB = dobPicker.Date,
                Email = emailEntry.Text,
                Iban = ibanEntry.Text,
                Password = passwordEntry.Text // Certifique-se de que a classe Owner tenha uma propriedade p�blica Password
            };
            await DataStorage.SaveOwnerDataAsync(owner);
            await DisplayAlert("Registro", "Propietario registrado exitosamente.", "OK");
            await Navigation.PopAsync();
        }

        private bool ValidateDNI(string dni)
        {
            return Regex.IsMatch(dni, @"^\d{8}[A-Za-z]$");
        }

        private bool ValidateIBAN(string iban)
        {
            return Regex.IsMatch(iban, @"^[A-Za-z]{2}\d{22}$");
        }

        private bool EmailIsValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
