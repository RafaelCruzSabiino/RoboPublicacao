using RoboPublicacao.Interfaces;
using RoboPublicacao.Models;
using RoboPublicacao.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboPublicacao.Plataformas
{
    public class Facebook : IPlataforma
    {
        private SeleniumUtils _seleniumUtils;
        private const string  _urlPlataforma = "https://www.facebook.com/";

        public Facebook() 
        {
            _seleniumUtils = new SeleniumUtils();
        }

        public bool Login(DadosAcessoModel model)
        {
            var result = true;

            try 
            {
                _seleniumUtils.AcessarPlataforma(_urlPlataforma);

                _seleniumUtils.EnviarDado("input[name*='email']", "CSSSELECTOR", model.Login);
                _seleniumUtils.EnviarDado("input[name*='pass']", "CSSSELECTOR", model.Senha);
                _seleniumUtils.Clicar("button[name*='login']", "CSSSELECTOR");
            }
            catch(Exception ex) 
            {
                EventLog.CreateEventSource("RoboPublicacao", ex.Message);
                _seleniumUtils.FinalizarConexao();
                result = false;
            }

            return result;
        }

        public bool LogOut()
        {
            throw new NotImplementedException();
        }

        public bool Publish(PublicacaoModel model)
        {
            var result = true;

            try
            {
                _seleniumUtils.Clicar("span[text*='No que você está pensando']", "CSSSELECTOR");
            }
            catch (Exception ex)
            {
                EventLog.CreateEventSource("RoboPublicacao", ex.Message);
                _seleniumUtils.FinalizarConexao();
                result = false;
            }

            return result;
        }
    }
}
