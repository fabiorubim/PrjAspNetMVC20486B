using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuarkUp.CadCli.Domain.Entities;
using QuarkUp.CadCli.Domain.Repositories;
using QuarkUp.CadCli.UI.Controllers;
using QuarkUp.CadCli.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace QuarkUp.CadCli.Tests.Controllers
{
    [TestClass]
    public class ClientesControllerTest
    {
        [TestMethod]
        public void Verificando_Retorno_De_Dados() 
        { 
            var fakeRepository = new FakeRepository();
            //arange
            var controller = new ClientesController(fakeRepository);

            //act
            var viewResult = controller.Index() as ViewResult;
            var totalClientes = ((IEnumerable<ClienteVM>)viewResult.Model).Count();
            
            //assert
            Assert.AreEqual(3,totalClientes);

        }
    }

    public class FakeRepository:IClienteRepository
    {

        public IEnumerable<Domain.Entities.Cliente> Obter() //Procurar sobre MOQ, é um mock
        {
            return new List<Cliente>
            {
                new Cliente{},
                new Cliente{},
                new Cliente{}
            };
        }

        public Domain.Entities.Cliente Obter(int id)
        {
            throw new NotImplementedException();
        }

        public void Adicionar(Domain.Entities.Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Editar(Domain.Entities.Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Domain.Entities.Cliente cli)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
