using QuarkUp.CadCli.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkUp.CadCli.Domain.Repositories
{
    public interface IClienteRepository:IDisposable
    {
        IEnumerable<Cliente> Obter();

        Cliente Obter(int id);

        void Adicionar(Cliente cliente);
        void Editar(Cliente cliente);
        //void Salvar();//Para UoW =>Unity of Work
        //Procurar sobre CQRS

        void Excluir(Cliente cli);
    }
}
