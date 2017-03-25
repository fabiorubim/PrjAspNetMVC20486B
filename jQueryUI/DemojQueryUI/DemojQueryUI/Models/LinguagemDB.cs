using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemojQueryUI.Models
{
    public class LinguagemDB:DbContext
    {
        public LinguagemDB():base("LinguagemConn")
        {
            Database.SetInitializer(new Carga());
        }

        public DbSet<Linguagem> Linguagens { get; set; }       
    }

    public class Carga : DropCreateDatabaseIfModelChanges<LinguagemDB>
    {
        protected override void Seed(LinguagemDB context)
        {
            var linguagens = new List<Linguagem>
            {
              new Linguagem{Nome="ActionScript"},
              new Linguagem{Nome="AppleScript"},
              new Linguagem{Nome="Asp"},
              new Linguagem{Nome="BASIC"},
              new Linguagem{Nome="C"},
              new Linguagem{Nome="C++"},
              new Linguagem{Nome="Clojure"},
              new Linguagem{Nome="COBOL"},
              new Linguagem{Nome="ColdFusion"},
              new Linguagem{Nome="C#"},
              new Linguagem{Nome="Erlang"},
              new Linguagem{Nome="Fortran"},
              new Linguagem{Nome="Groovy"},
              new Linguagem{Nome="Haskell"},
              new Linguagem{Nome="Java"},
              new Linguagem{Nome="JavaScript"},              
              new Linguagem{Nome="Lisp"},
              new Linguagem{Nome="Perl"},
              new Linguagem{Nome="PHP"},
              new Linguagem{Nome="Python"},
              new Linguagem{Nome="Ruby"},
              new Linguagem{Nome="Scala"},
              new Linguagem{Nome="Scheme"}
            };

            context.Linguagens.AddRange(linguagens);
        }
    }
}