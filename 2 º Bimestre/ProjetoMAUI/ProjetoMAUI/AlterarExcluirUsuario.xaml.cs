using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Models;

namespace ProjetoMAUI;

public partial class AlterarExcluirUsuario : ContentPage
{
    private FirebaseClient banco;
    private Usuario usuario;

    public AlterarExcluirUsuario(Usuario u)
	{
		InitializeComponent();

        banco = new FirebaseClient("https://labengenhariamauijoao-default-rtdb.firebaseio.com/");
        this.usuario = u;
    }

    protected async override void OnAppearing()
    {
        Nome.Text = this.usuario.NomeU;
        Login.Text = this.usuario.Login;
        Senha.Text = this.usuario.Senha;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        this.usuario.NomeU = Nome.Text;
        this.usuario.Login = Login.Text;
        this.usuario.Senha = Senha.Text;

        await banco.Child("Usuarios").Child(usuario.ID).PutAsync(usuario);
        DisplayAlert("Alert", "Registro Alterado!", "OK");
        Navigation.PopAsync();
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await banco.Child("Usuarios").Child(usuario.ID).DeleteAsync();
        DisplayAlert("Alert", "Registro Alterado!", "OK");
        Navigation.PopAsync();
    }
}