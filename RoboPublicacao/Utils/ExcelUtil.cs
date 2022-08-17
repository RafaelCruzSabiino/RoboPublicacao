using ClosedXML.Excel;
using RoboPublicacao.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboPublicacao.Utils
{
    public class ExcelUtil
    {
        public Queue<PublicacaoModel> GetDadosPublicacao(string path) 
        {
            var result = new Queue<PublicacaoModel>();

            try 
            {
                XLWorkbook xls  = new XLWorkbook(path);
                var planilha    = xls.Worksheets.First(p => p.Name.Equals("Dados"));
                int totalLinhas = planilha.Rows().Count();

                for (var i = 2; i <= totalLinhas; i++)
                {
                    PublicacaoModel model = new PublicacaoModel()
                    {
                        Proprietario   = planilha.Cell(i, 1).Value.ToString(),
                        Midia          = planilha.Cell(i, 2).Value.ToString(),
                        Publicacao     = planilha.Cell(i, 3).Value.ToString(),
                        CaminhoArquivo = planilha.Cell(i, 4).Value.ToString(),
                        Extensao       = planilha.Cell(i, 5).Value.ToString(),
                    };

                    result.Enqueue(model);
                }
            }
            catch(Exception ex)
            {
                EventLog.CreateEventSource("RoboPublicacao", ex.Message);
            }

            return result;
        }
    }
}
