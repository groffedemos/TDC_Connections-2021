using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SiteContagem.Pages
{
    public class IndexModel : PageModel
    {
        private static readonly Contador _CONTADOR = new Contador();

        public void OnGet([FromServices]ILogger<IndexModel> logger,
            [FromServices]IConfiguration configuration)
        {
            int valorAtualContador;
            lock (_CONTADOR)
            {
                _CONTADOR.Incrementar();
                valorAtualContador = _CONTADOR.ValorAtual;
            }

            logger.LogInformation($"Contador - Valor atual: {valorAtualContador}");

            if (valorAtualContador % 10 == 0)
                throw new Exception("Simulação de falha");
            
            TempData["Contador"] = valorAtualContador;
            TempData["Local"] = _CONTADOR.Local;
            TempData["Kernel"] = _CONTADOR.Kernel;
            TempData["TargetFramework"] = _CONTADOR.TargetFramework;
            TempData["MensagemFixa"] = "Teste";
            TempData["MensagemVariavel"] = configuration["MensagemVariavel"];
        }
    }
}