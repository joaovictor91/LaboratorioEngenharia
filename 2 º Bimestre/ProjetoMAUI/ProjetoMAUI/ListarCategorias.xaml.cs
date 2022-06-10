using Firebase.Database;
using ProjetoMAUI.Models;

namespace ProjetoMAUI;

public partial class ListarCategorias : ContentPage
{
	private FirebaseClient banco;

	private List<Categoria> Categorias;//Estruturar a list view

	public ListarCategorias()
	{
		InitializeComponent();
		banco = new FirebaseClient("https://labengenhariamauijoao-default-rtdb.firebaseio.com/");
	}

	protected async override void OnAppearing()
    {
		base.OnAppearing();
		var categorias = (await banco.Child("Categorias").OnceAsync<Categoria>()).Select(
					item => new Categoria()
					{
						ID = item.Key,
						Descricao = item.Object.Descricao
					}).ToList();
		Dados.ItemsSource = categorias;
    }

    private void Dados_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		var categoria = (Categoria)e.Item;
		Navigation.PushAsync(new AlterarExcluir(categoria));
    }
}