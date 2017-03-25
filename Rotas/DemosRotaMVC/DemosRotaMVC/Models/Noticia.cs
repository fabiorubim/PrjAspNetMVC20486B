using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemosRotaMVC.Models
{
    public class Noticia
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }

        [DisplayFormat(DataFormatString="{0: dd/MM/yy HH:mm:ss}")]
        public DateTime Data { get; set; }
        public string Categoria { get; set; }
    }
}