using MeuPrimeiroMauiApp.Data;
using MeuPrimeiroMauiApp.Model;
using MeuPrimeiroMauiApp.Pages;

namespace MeuPrimeiroMauiApp
{
public partial class App : Application
{

        static SQLiteData _bancoDados;

        public static SQLiteData BancoDados
        {
            get
            {
                if (_bancoDados == null)
                {
                    _bancoDados =
                        new SQLiteData(DependencyService
                        .Get<ISQLiteBD>()
                        .SQLiteLocalPath("Dados.db3"));
                }
                return _bancoDados;
            }

        }

        public static Usuario Usuario { get; set; }


        public App()
        {
            InitializeComponent();

            MainPage =  new NavigationPage (new LoginUsuarioPage());
        }
    }
}
