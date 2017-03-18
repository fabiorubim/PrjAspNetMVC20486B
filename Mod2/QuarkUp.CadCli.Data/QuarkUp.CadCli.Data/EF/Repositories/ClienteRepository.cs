using QuarkUp.CadCli.Domain.Entities;
using QuarkUp.CadCli.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkUp.CadCli.Data.EF.Repositories
{
    public class ClienteRepository:IClienteRepository
    {

        private readonly CadCliContext _ctx = new CadCliContext();

        public IEnumerable<Cliente> Obter()
        {
            return _ctx.Clientes
                //.Skip(10).Take(20) --> paginação antes do ToList
                    .ToList();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }


        public Cliente Obter(int id)
        {
            return _ctx.Clientes.Find(id);
        }


        public void Adicionar(Cliente cliente)
        {
            _ctx.Clientes.Add(cliente);
            salvar();
        }

        public void Editar(Cliente cliente)
        {
            _ctx.Entry(cliente).State = EntityState.Modified;
        }

        private void salvar()
        {
            _ctx.SaveChanges();
        }



        public void Excluir(Cliente cli)
        {
            _ctx.Clientes.Remove(cli);
            salvar();
        }
    }
}
