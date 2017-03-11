using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuarkUp.CadCli.UI.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName="varchar")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        //[StringLength(100,MinimumLength=3,ErrorMessage="Informe uma senha de {1} até {2}")]
        public string Senha { get; set; }
    }
}