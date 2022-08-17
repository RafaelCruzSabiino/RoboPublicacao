using Newtonsoft.Json;
using RoboPublicacao.Models;
using RoboPublicacao.Plataformas;
using RoboPublicacao.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoboPublicacao.Flows
{
    public class MasterFlow
    {
        private string _nameFileDadosAcesso;
        private string _pathPlanilhaPublicacao;

        private FileUtil _fileUtil 
        {
            get { return new FileUtil(); }
        }

        private ExcelUtil _excelUtil
        {
            get { return new ExcelUtil(); }
        }

        public MasterFlow() 
        {
            var appSettings = ConfigurationManager.AppSettings;

            _nameFileDadosAcesso    = appSettings.GetValues("nameFileDadosAcesso").FirstOrDefault();
            _pathPlanilhaPublicacao = appSettings.GetValues("pathPlanilhaPublicacao").FirstOrDefault();
        }

        public void Execute() 
        {
            List<string> lstArquivosPublicacao = _fileUtil.GetListaArquivoPublicacao(_pathPlanilhaPublicacao);

            if (lstArquivosPublicacao.Any()) 
            {
                List<Thread> lstThread = new List<Thread>();

                foreach (string path in lstArquivosPublicacao) 
                {
                    if (_fileUtil.Validar(path))
                    {
                        //Thread th = new Thread(() => 
                        //{                        
                        Queue<PublicacaoModel> lstDadosPublicacao = _excelUtil.GetDadosPublicacao(path);

                        while (lstDadosPublicacao.Count > 0) 
                        {
                            PublicacaoModel dadosPublicacao = lstDadosPublicacao.Dequeue();

                            List<DadosAcessoModel> modelJson = JsonConvert.DeserializeObject<List<DadosAcessoModel>>(File.ReadAllText(_fileUtil.GetFullPath(_nameFileDadosAcesso)));

                            if (modelJson.Any()) 
                            {
                                DadosAcessoModel dadosAcesso = modelJson.FirstOrDefault(j => j.ProprietarioGuid.Equals(dadosPublicacao.Proprietario));

                                if (dadosAcesso.Midia.Equals("FACEBOOK")) 
                                {
                                    var facebook = new Facebook();
                                    bool validar = false;

                                    validar = facebook.Login(dadosAcesso);
                                    validar = validar ? facebook.Publish(dadosPublicacao) : false;
                                    validar = validar ? facebook.LogOut() : false;

                                    if (!validar) 
                                    {
                                        lstDadosPublicacao.Enqueue(dadosPublicacao);
                                    }
                                }
                            }
                        }
                        //});

                        //lstThread.Add(th);
                    }
                }
            }
        }
    }
}
