using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuarkUp.CadCli.UI.Models
{
    public class ClienteVM
    {
        //[Key]//Atributo - Campo abaixo seja a PK - Data Annotation - Não usa na tela
        public int Id { get; set; }
        
        [Required(ErrorMessage="O nome é obrigatório")]//Indica o campo requerido
        //[Column("NomeCompleto")] Troca o nome do campo abaixo
        //[Column(TypeName="VARCHAR")] //Define/troca o tipo - Não usa na tela
        [StringLength(100)]
        public string Nome { get; set; }

        [Range(18, 60, ErrorMessage = "Informe um valor entre {1} e {2}")]
        public int Idade {get;set;}

    }
}