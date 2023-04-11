using AppLocalize_se.ViewModels.Usuarios;

namespace AppLocalize_se.Views.Usuarios;

public partial class CadastrarView : ContentPage
{
	UsuarioViewModel viewModel;
	public CadastrarView()
	{
		InitializeComponent();

		viewModel = new UsuarioViewModel();
		BindingContext = viewModel;
	}
}