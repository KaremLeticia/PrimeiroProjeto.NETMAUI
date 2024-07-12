using MeuPrimeiroMauiApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuPrimeiroMauiApp.Data
{
    public class UsuarioData
    {
        private SQLiteAsyncConnection _conexaoDB;

        public UsuarioData(SQLiteAsyncConnection conexaoDB) 
        {
            _conexaoDB = conexaoDB;
        }
       
        public Task<List<Usuario>> ListaUsuario()
        {
            var lista = _conexaoDB
                .Table<Usuario>()
                .ToListAsync();
            return lista;
           
        }

        public Task<Usuario> ObtemUsuario(string email, string senha)
        {
            var usuario = _conexaoDB
                .Table<Usuario>()
                .Where(x => x.Email == email && x.Senha == senha)
                .FirstOrDefaultAsync();
            return usuario;
        
        }


        public Task<Usuario> ObtemUsuario(Guid id)
        {
            var usuario = _conexaoDB
                .Table<Usuario>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return usuario;

        }

        public async Task <int> SalvaUsuario(Usuario usuario)
        {
            var usuarioIsSalvo = await ObtemUsuario(usuario.Id);

            if(usuarioIsSalvo == null)
            {
                return await _conexaoDB.InsertAsync(usuario);
            }
            else 
            {
                return await _conexaoDB.UpdateAsync(usuario);
            }
        
        }

        public async Task <int> ExcluirUsuario(Guid id)
        {
           return await _conexaoDB.DeleteAsync(id);
        }
    }
}

 
