namespace Exercicio_3;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		var valor = Convert.ToInt32(Valor.Text);

		var n = valor;

		if (n > 10)
		{
			DisplayAlert("Resposta", "O Valor é informado é maior que 10", "OK");
		}
		else if (n < 10)
		{
			DisplayAlert("Resposta", "O Valor é informado é menor que 10", "OK");
		}
		else if (n == 10)
		{
			DisplayAlert("Resposta", "O Valor que é informado é igual a 10", "OK");
		}
	}
}

