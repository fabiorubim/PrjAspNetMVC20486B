using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuarkUp.CadCli.UI.Models
{
    public class CadCliContext:DbContext
    {
        public CadCliContext():base("CadCliConn")
        {
            //Seta no contexto a classe que irá gerar a carga inicial
            Database.SetInitializer(new CargaInicial());
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }

    public class CargaInicial:DropCreateDatabaseIfModelChanges<CadCliContext>
    {
        protected override void Seed(CadCliContext context)
        {
            var clientes = new List<Cliente> {
                new Cliente{Nome="Fabio Biasi",Idade=29},
                new Cliente{Nome="Marina Maia",Idade=27},
                new Cliente{Nome="Renato Rubim",Idade=30},
                new Cliente{Nome="Tulio Fernando",Idade=31},
                new Cliente{Nome="Tomaz Basso",Idade=32},
                new Cliente{Nome="Euclydes de Souza",Idade=33}                
            };

            context.Clientes.AddRange(clientes);

            var usuarios = new List<Usuario>{ 
                new Usuario{
                        Nome="Tospericageja",
                        Email="toto@gmail.com",
                        Senha=StringHelper.Encrypt("123456")},

                new Usuario{
                        Nome="Fernando",
                        Email="fernando@gmail.com",
                        Senha=StringHelper.Encrypt("123456")},

                new Usuario{
                        Nome="João",
                        Email="joao@gmail.com",
                        Senha=StringHelper.Encrypt("123456")}
            };

            context.Usuarios.AddRange(usuarios);

            context.SaveChanges();

        }
    }

}