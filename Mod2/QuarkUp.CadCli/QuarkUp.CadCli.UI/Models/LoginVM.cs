using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuarkUp.CadCli.UI.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage="Informe o e-mail de acesso")]
        [EmailAddress(ErrorMessage="E-mail inválido")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Senha obrigatória")]
        public string Password { get; set; }
    }
}