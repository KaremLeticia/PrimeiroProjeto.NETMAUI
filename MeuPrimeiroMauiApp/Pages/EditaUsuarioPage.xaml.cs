using MeuPrimeiroMauiApp.Model;
using System.Xml.XPath;

namespace MeuPrimeiroMauiApp.Pages;

public partial class EditaUsuarioPage : ContentPage
{
	Usuario _usuario;
	public EditaUsuarioPage()
	{
		InitializeComponent();
		_usuario = new Usuario();

		this.BindingContext = _usuario;
	}


    private async void btnCadastrar_Clicked(object sender, EventArgs e)
    {
		if(string.IsNullOrWhiteSpace(_usuario.Email) ||
            string.IsNullOrWhiteSpace(_usuario.Senha))
		{
			await DisplayAlert("Aten��o", "Preencha todas as informa��es", "Fechar");
			return;
		}

        //var cadastro = await App.BancoDados.UsuarioDataTable.SalvaUsuario(_usuario);
        var cadastro = 1;
        await DisplayAlert("Sucesso", "Usu�rio cadastrado!", "Fechar");

        if (cadastro > 0)
		{
            await Navigation.PopAsync();
		}

    }

	private async void btnVoltar_Clicked(object sender, EventArgs e)
	{
        await Navigation.PopAsync();
    }
}