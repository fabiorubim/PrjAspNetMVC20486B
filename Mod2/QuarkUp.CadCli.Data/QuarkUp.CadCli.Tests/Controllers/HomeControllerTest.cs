using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuarkUp.CadCli.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace QuarkUp.CadCli.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        //Dados o HomeController - Uma história
        [TestMethod]
        public void O_METODO_INDEX_DEVERA_RETORNAR_A_VIEW_INDEX()
        {
            //arrange =>ambiente
            var homeController = new HomeController();

            //act => ação que vai desencadear o que será testado

            //var result = (ViewResult) HomeController.Index(); //Se der exceção irá parar o teste

            var result = homeController.Index() as ViewResult; 

            //assert => testar o resultado
            Assert.AreEqual("Index",result.ViewName);//só é possível testar o nome da  View se for colocado de forma explícita, ex: return View("Index");


        }


        //Se não quiser uasr um nome comprido e explcaitivo para o método de teste use o TestCategory
        [TestMethod]
        [TestCategory("testando tal coisa")]
        public void TesteTrue()
        {
            //arrange
            var flag = true;

            //assert
            Assert.AreEqual(true,flag);
        }
    }
}
