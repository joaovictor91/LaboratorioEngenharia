namespace Exercicio_1;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		var valorpago = Convert.ToInt32(ValorPago.Text);
		var valorproduto = Convert.ToInt32(ValorProduto.Text);

		var troco = valorpago - valorproduto;
		if (troco > 0)
		{
			DisplayAlert("Resposta", "O Troco é de: " + troco, "Confirmar");
		}
		else if (troco == 0)
		{
			DisplayAlert("Resposta", "Não há troco", "Confirmar");
		}
		else
		{
			DisplayAlert("Resposta", "O valor pago é insuficiente restam: " + troco, "Confirmar");
		}
	}
}

