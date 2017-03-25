using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoApi.Models
{
    public class Livro
    {
        public int Id { get; set; }
        [Required]
        public string ISBN { get; set; }

        public string Nome { get; set; }


    }
}