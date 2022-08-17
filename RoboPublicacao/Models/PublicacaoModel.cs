using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboPublicacao.Models
{
    public class PublicacaoModel
    {
        public string Proprietario   { get; set; }
        public string Midia          { get; set; }
        public string Publicacao     { get; set; }
        public string CaminhoArquivo { get; set; }
        public string Extensao       { get; set; }
    }
}
