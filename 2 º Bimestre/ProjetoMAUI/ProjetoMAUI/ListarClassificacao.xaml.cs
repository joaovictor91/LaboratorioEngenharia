using Firebase.Database;
using ProjetoMAUI.Models;

namespace ProjetoMAUI;

public partial class ListarClassificacao : ContentPage
{
	private FirebaseClient banco;

	private List<Classificacao> Classificacaos;//Estruturar a list view
	public ListarClassificacao()
	{
		InitializeComponent();

		banco = new FirebaseClient("https://labengenhariamauijoao-default-rtdb.firebaseio.com/");
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		var classificacaos = (await banco.Child("Classificacaos").OnceAsync<Classificacao>()).Select(
					item => new Classificacao()
					{
						ID = item.Key,
						NomeC = item.Object.NomeC
					}).ToList();
		Dados.ItemsSource = classificacaos;
	}

	private void Dados_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		var classficacao = (Classificacao)e.Item;
		Navigation.PushAsync(new AlterarExcluirClassificacao(classficacao));
	}
}