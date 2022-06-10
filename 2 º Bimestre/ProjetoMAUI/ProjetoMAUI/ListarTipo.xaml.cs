using Firebase.Database;
using ProjetoMAUI.Models;

namespace ProjetoMAUI;

public partial class ListarTipo : ContentPage
{
	private FirebaseClient banco;

	private List<Tipo> Tipos;//Estruturar a list view
	public ListarTipo()
	{
		InitializeComponent();

		banco = new FirebaseClient("https://labengenhariamauijoao-default-rtdb.firebaseio.com/");
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		var tipos = (await banco.Child("Tipos").OnceAsync<Tipo>()).Select(
						item => new Tipo()
						{
							ID = item.Key,
							NomeT = item.Object.NomeT
						}).ToList();
		Dados.ItemsSource = tipos;
	}

	private void Dados_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		var tipo = (Tipo)e.Item;
		Navigation.PushAsync(new AlterarExcluirTipo(tipo));
    }
}