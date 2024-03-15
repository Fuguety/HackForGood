namespace MiPark;

public partial class ClientAreaPage : ContentPage
{
    private string _username;
    private string _userId;

    public ClientAreaPage(string username, string userId)
    {
        InitializeComponent();
        _username = username;
        _userId = userId;
        WelcomeMessage.Text = $"�Bienvenido a la �rea del Cliente de MiPark, {_username}!";
    }


    private async void OnRegisterVehicleClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterVehiclePage(_userId));
    }

    private async void OnSearchGaragesClicked(object sender, EventArgs e)
    {
        // Navega para a p�gina de busca de garagens
        // Substitua "MapPage" pelo nome real da sua p�gina de mapa
        await Navigation.PushAsync(new MapPage());
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        // Implemente sua l�gica de deslogar aqui
        // Por exemplo, voltar para a p�gina de login
        await Navigation.PopToRootAsync();
    }
}