using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Models;

namespace ProjetoMAUI;

public partial class AlterarExcluirClassificacao : ContentPage
{
    private FirebaseClient banco;
    private Classificacao classificacao;
    public AlterarExcluirClassificacao(Classificacao cl)
	{
		InitializeComponent();

        banco = new FirebaseClient("https://labengenhariamauijoao-default-rtdb.firebaseio.com/");
        this.classificacao = cl;
    }

    protected async override void OnAppearing()
    {
        Nome.Text = this.classificacao.NomeC;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        this.classificacao.NomeC = Nome.Text;
        await banco.Child("Classificacaos").Child(classificacao.ID).PutAsync(classificacao);
        DisplayAlert("Alert", "Registro Alterado!", "OK");
        Navigation.PopAsync();
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await banco.Child("Classificacaos").Child(classificacao.ID).DeleteAsync();
        DisplayAlert("Exclusão", "Registro Excluido!", "OK");
        Navigation.PopAsync();
    }
}
