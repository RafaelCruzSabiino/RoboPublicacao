using RoboPublicacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboPublicacao.Interfaces
{
    public interface IPlataforma
    {
        bool Login(DadosAcessoModel model);
        bool LogOut();
        bool Publish(PublicacaoModel model);
    }
}
