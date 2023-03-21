namespace AppLocalize_se.Views.Usuarios;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();

	}

    private void BtnLogin_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Paginas.LoginView());
    }

    private void BtnCadastrar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Paginas.CadastrarView());
    }

    private void BtnMaisTarde_Clicked(object sender, EventArgs e)
    {

    }
}