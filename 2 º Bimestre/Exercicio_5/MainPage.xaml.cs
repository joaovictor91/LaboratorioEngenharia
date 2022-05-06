namespace Exercicio_5;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		var n1 = Convert.ToDouble(N1.Text);
		var n2 = Convert.ToDouble(N2.Text);
		var n3 = Convert.ToDouble(N3.Text);
		var n4 = Convert.ToDouble(N4.Text);
		var media = (n1 + n2 + n3 + n4) / 4;

		if (media > 7)
		{
			DisplayAlert("Resposta", "O Aluno foi Aprovado", "Confirmar");
		}
		else if (media < 7)
		{
			DisplayAlert("Resposta", "O Aluno foi Reprovado", "Confirmar");
		}
	}
}

