using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Models;

namespace ProjetoMAUI;

public partial class NovoTipo : ContentPage
{
	private FirebaseClient banco;
	public NovoTipo()
	{
		InitializeComponent();

		banco = new FirebaseClient("https://labengenhariamauijoao-default-rtdb.firebaseio.com/");
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		var tipo = new Tipo()
		{
			NomeT = Nome.Text
		};

		await banco.Child("Tipos").PostAsync(tipo);
		await DisplayAlert("Resposta", "Registro Inserido!", "OK");

	}
}