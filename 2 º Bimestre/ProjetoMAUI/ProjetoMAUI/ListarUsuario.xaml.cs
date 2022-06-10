using Firebase.Database;
using ProjetoMAUI.Models;

namespace ProjetoMAUI;

public partial class ListarUsuario : ContentPage
{
	private FirebaseClient banco;

	private List<Usuario> Usuario;
	public ListarUsuario()
	{
		InitializeComponent();

		banco = new FirebaseClient("https://labengenhariamauijoao-default-rtdb.firebaseio.com/");
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();

		var usuarios = (await banco.Child("Usuarios").OnceAsync<Usuario>()).Select(
			item => new Usuario {
				ID = item.Key,
				NomeU = item.Object.NomeU, 
				Login = item.Object.Login,
				Senha = item.Object.Senha
			}).ToList();
		Dados.ItemsSource = usuarios;

	}

	private void Dados_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		var usuario = (Usuario)e.Item;
		Navigation.PushAsync(new AlterarExcluirUsuario(usuario));
    }
}