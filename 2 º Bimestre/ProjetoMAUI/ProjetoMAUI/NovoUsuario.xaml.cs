using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Models;

namespace ProjetoMAUI;

public partial class NovoUsuario : ContentPage
{
	private FirebaseClient banco;
	public NovoUsuario()
	{
		InitializeComponent();

		banco = new FirebaseClient("https://labengenhariamauijoao-default-rtdb.firebaseio.com/");
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		var usuario = new Usuario()
		{
			NomeU = nome.Text,
			Login = LoginU.Text,
			Senha = SenhaU.Text
		};
		await banco.Child("Usuarios").
			PostAsync(usuario);
		await DisplayAlert("Resposta", "Registro Inserido!", "OK");
	}
}