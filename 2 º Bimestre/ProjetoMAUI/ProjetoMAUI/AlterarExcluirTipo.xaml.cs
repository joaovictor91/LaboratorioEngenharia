using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Models;

namespace ProjetoMAUI;

public partial class AlterarExcluirTipo : ContentPage
{
    private FirebaseClient banco;
    private Tipo tipo;
    public AlterarExcluirTipo(Tipo t)
	{
		InitializeComponent();

        banco = new FirebaseClient("https://labengenhariamauijoao-default-rtdb.firebaseio.com/");
        this.tipo = t;
    }

    protected async override void OnAppearing()
    {
        Nome.Text = this.tipo.NomeT;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        this.tipo.NomeT = Nome.Text;
        await banco.Child("Tipos").Child(tipo.ID).PutAsync(tipo);
        DisplayAlert("Alert", "Registro Alterado!", "OK");
        Navigation.PopAsync();
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await banco.Child("Tipos").Child(tipo.ID).DeleteAsync();
        DisplayAlert("Alert", "Registro Alterado!", "OK");
        Navigation.PopAsync();
    }
}