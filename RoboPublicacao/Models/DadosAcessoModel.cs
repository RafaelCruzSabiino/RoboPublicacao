using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboPublicacao.Models
{
    [Serializable]
    public class DadosAcessoModel
    {
        [JsonProperty(PropertyName = "ProprietarioGuid")]
        public string ProprietarioGuid { get; set; }

        [JsonProperty(PropertyName = "ProprietarioNome")]
        public string ProprietarioNome { get; set; }

        [JsonProperty(PropertyName = "Midia")]
        public string Midia { get; set; }

        [JsonProperty(PropertyName = "Login")]
        public string Login { get; set; }

        [JsonProperty(PropertyName = "Senha")]
        public string Senha { get; set; }
    }
}
