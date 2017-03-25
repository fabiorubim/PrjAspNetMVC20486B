using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoApi.Models
{
    public class LivroDB:DbContext
    {
        public LivroDB():base("LivroConn")
        {

        }

        public DbSet<Livro> Livros { get; set; }
    }
}