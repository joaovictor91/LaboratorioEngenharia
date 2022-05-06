namespace Exercicio_4;

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

		if (n < 0)
		{
			DisplayAlert("Resposta", "O Valor é informado é NEGATIVO", "OK");
		}
		else if (n > 0)
		{
			DisplayAlert("Resposta", "O Valor é informado é POSITIVO", "OK");
		}
		else if (n == 0)
		{
			DisplayAlert("Resposta", "O Valor que é informado é 0", "OK");
		}
	}
}

