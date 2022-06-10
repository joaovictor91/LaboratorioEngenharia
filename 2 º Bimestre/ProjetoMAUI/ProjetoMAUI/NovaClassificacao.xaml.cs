using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Models;

namespace ProjetoMAUI;

public partial class NovaClassificacao : ContentPage
{
	private FirebaseClient banco;

	public NovaClassificacao()
	{
		InitializeComponent();
		banco = new FirebaseClient("https://labengenhariamauijoao-default-rtdb.firebaseio.com/");
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		var classficacao = new Classificacao()
        {
			NomeC = Nome.Text
        };
        
		await banco.Child("Classificacaos").PostAsync(classficacao);
		await DisplayAlert("Resposta", "Registro Inserido!", "OK");
	}
}