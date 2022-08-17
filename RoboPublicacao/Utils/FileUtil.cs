using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboPublicacao.Utils
{
    public class FileUtil 
    {
        public string GetFullPath(string file) 
        {
            return Path.GetFullPath(file);
        }

        public List<string> GetListaArquivoPublicacao(string path) 
        {
            var result = new List<string>();

            try 
            {
                Directory.GetFiles(path).ToList().ForEach(d => 
                {
                    result.Add(d);
                });
            }
            catch(Exception ex)
            {
                EventLog.CreateEventSource("RoboPublicacao", ex.Message);
            }

            return result;
        }

        public bool Validar(string path) 
        {
            var result = true;

            try 
            {
                var arquivo = File.ReadAllText(path);              
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}
