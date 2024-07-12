using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroMauiApp.Data
{
    public interface ISQLiteBD
    {
        string SQLiteLocalPath(string bancoDados);
    }
}
