using QuarkUp.CadCli.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarkUp.CadCli.Data.EF.Maps
{
    internal class UsuarioMap:EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            //Tabela
            ToTable("Usuario");
             
            //PK
            //HasKey(c=> new {c.Id, c.Nome}); --> Ex. PK Composta
            HasKey(c=>c.Id);

            //Campos
            Property(c=>c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Nome)
                .HasColumnType("varchar") 
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.Senha)
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

            //FK
        }
    }
}
