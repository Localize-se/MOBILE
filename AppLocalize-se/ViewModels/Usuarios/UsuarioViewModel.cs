using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppLocalize_se.Services.Usuarios;
using AppLocalize_se.Models;
using AppLocalize_se.Views.Usuarios;

namespace AppLocalize_se.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {

        private UsuarioService uService;
        public ICommand RegistrarCommand { get; set; }
        public ICommand AutenticarCommand { get; set; }
        public ICommand DirecionarCadastroCommand { get; set; }

        public UsuarioViewModel()
        {
            uService = new UsuarioService();
            InicializarCommands();
        }

        public void InicializarCommands()
        {
            RegistrarCommand = new Command(async () => await RegistrarUsuario());
            AutenticarCommand = new Command(async () => await AutenticarUsuario());
            DirecionarCadastroCommand = new Command(async () => await DirecionarParaCadastro());
        }


        #region AtributosPropriedades

        private string login = string.Empty;

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }

        private string senha = string.Empty;

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                OnPropertyChanged();
            }
        }

       

        #endregion

        #region Métodos

        public async Task RegistrarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Username = Login;
                u.PasswordString = Senha;

                Usuario uRegistrado = await uService.PostRegistrarUsuarioAsync(u);
                if (uRegistrado.Id != 0)
                {
                    string mensagem = $"Usuario Id {uRegistrado.Id} registrado com suceso.";
                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
            catch (Exception ex)

            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");

            }
        }
        #endregion
        public async Task AutenticarUsuario()//Método para registrar um usuário 
        {
            try
            {
                Usuario u = new Usuario();
                u.Email = Login;
                u.PasswordString = Senha;

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);
                if (!string.IsNullOrEmpty(uAutenticado.Token))
                {
                    string mensagem = $"Bem-vindo(a) {uAutenticado.Username}. ";

                    //Guradando dados do usuário para uso futuro
                    Preferences.Set("UsuarioId", uAutenticado.Id);
                    Preferences.Set("UsuarioUsename", uAutenticado.Username);
                    Preferences.Set("UsuarioPerfil", uAutenticado.Perfil);
                    Preferences.Set("UsuarioToken", uAutenticado.Token);
                    Preferences.Set("UsuarioEmail", uAutenticado.Email);

                    await Application.Current.MainPage
                        .DisplayAlert("Informação", mensagem, "Ok");

                    Application.Current.MainPage = new AppShell();

                }
                else
                {
                    await Application.Current.MainPage
                           .DisplayAlert("Informação", "Dados incorretos :(", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

       /* public async Task AutenticarRmUsuario()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }*/

            public async Task DirecionarParaCadastro()//Método para a exibição da view de Cadastro
            {
                try
                {
                await Application.Current.MainPage.
                        Navigation.PushAsync(new CadastrarView());
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
                }
            }




        
    }
}