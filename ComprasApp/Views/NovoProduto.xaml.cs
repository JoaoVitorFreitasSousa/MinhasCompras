using ComprasApp.Models;

namespace ComprasApp.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e) // Fun��o para adionar um novo produto
    {
		try
		{
			Produto p = new Produto
			{
				Descricao = txt_descri��o.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text), // Convertendo string para double
				Preco = Convert.ToDouble(txt_preco.Text),
			}; // Instanciando um objeto com as informa��es do XAML

			await App.Database.Insert(p);
			await DisplayAlert("Sucesso!", "Produto Inserido", "Ok");
			await Navigation.PushAsync(new MainPage());
		} catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");
		}
    }
}