using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Models;

namespace ProjetoMAUI;

public partial class AlterarExcluir : ContentPage
{
    private FirebaseClient banco;
    private Categoria categoria;
	public AlterarExcluir(Categoria c)
	{
		InitializeComponent();
        banco = new FirebaseClient("https://labengenhariamauijoao-default-rtdb.firebaseio.com/");
        this.categoria = c;
    }
    protected async override void OnAppearing()
    {
        Nome.Text = this.categoria.Descricao;
    }

        //Botão alterar
        private async void Button_Clicked(object sender, EventArgs e)
    {
        this.categoria.Descricao = Nome.Text;
        await banco.Child("Categorias")
            .Child(categoria.ID)
            .PutAsync(categoria);
        DisplayAlert("Alert", "Registro Alterado!", "OK");
        Navigation.PopAsync();
    }


    //Botão Excluir
    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await banco.Child("Categorias")
            .Child(categoria.ID)
            .DeleteAsync();
        DisplayAlert("Exclusão", "Registro Excluido!", "OK");
        Navigation.PopAsync();
    }
}