namespace Exercicio_2;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		var valorquilo = Convert.ToInt32(ValorQuilo.Text);
		var qtdeproduto = Convert.ToInt32(QtdeProduto.Text);

		var total = valorquilo * qtdeproduto;

		DisplayAlert("Valor", "O valor a ser pago: " + total, "Confirmar");
	}
}

