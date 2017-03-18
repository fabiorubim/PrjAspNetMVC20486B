using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuarkUp.CadCli.UI.Models
{
    public class UsuarioVM
    {
        //[Key] - Não usa na etla
        public int Id { get; set; }

        [Required]
        //[Column(TypeName="varchar")] - Não usa na tela
        [StringLength(100)]
        public string Nome { get; set; }

        //[Column(TypeName = "varchar")] - Não usa na tela
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        //[Column(TypeName = "varchar")] - Não usa na tela
        //[StringLength(100,MinimumLength=3,ErrorMessage="Informe uma senha de {1} até {2}")]
        public string Senha { get; set; }
    }
}