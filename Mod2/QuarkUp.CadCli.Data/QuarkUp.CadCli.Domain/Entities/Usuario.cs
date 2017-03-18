using QuarkUp.CadCli.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkUp.CadCli.Domain.Entities
{
    public class Usuario
    {
        public IDictionary<string, string> Notificacoes { get; set; }

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = StringHelper.Encrypt(senha);
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                Notificacoes.Add("Nome", "Nome inválido");
            }
        }

        public bool isValid()
        {
            return Notificacoes.Count == 0;
        }

        public int Id { get; set; } 
        
        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public void Alterar(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = StringHelper.Encrypt(senha);
            Validar();
        }
    }
}