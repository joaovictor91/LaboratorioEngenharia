using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Models;

namespace ProjetoMAUI;

public partial class NovaCategoria : ContentPage
{
	private FirebaseClient banco;

	public NovaCategoria()
	{
		InitializeComponent();
		banco = new FirebaseClient("https://labengenhariamauijoao-default-rtdb.firebaseio.com/");
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		var categoria = new Categoria()
		{
			Descricao = Nome.Text
		};
		await banco.Child("Categorias").
			PostAsync(categoria);
		await DisplayAlert("Resposta", "Registro Inserido!", "OK");
    }
}