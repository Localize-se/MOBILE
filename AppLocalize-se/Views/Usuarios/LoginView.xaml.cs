using AppLocalize_se.ViewModels.Usuarios;

namespace AppLocalize_se.Views.Usuarios;

public partial class LoginView : ContentPage
{
	UsuarioViewModel usuarioViewModel;
	public LoginView()
	{
		InitializeComponent();

		usuarioViewModel = new UsuarioViewModel();
		BindingContext = usuarioViewModel;

	}

    
}