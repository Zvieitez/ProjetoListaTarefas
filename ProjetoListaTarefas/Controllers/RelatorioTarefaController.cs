using Microsoft.AspNetCore.Mvc;
using ProjetoListaTarefas.Models;

namespace ProjetoListaTarefas.Controllers
{
    public class RelatorioTarefaController : Controller
    {
        private static List<RelatorioTarefas> _relatorio = new List<RelatorioTarefas>()
        {
            new RelatorioTarefas { RelatorioId= 1, NomeRelatorio="Tarefas a Fazer", StatusTarefa="To Do" },
            new RelatorioTarefas { RelatorioId= 2, NomeRelatorio="Tarefas em Progresso", StatusTarefa="Doing" },
            new RelatorioTarefas { RelatorioId = 3, NomeRelatorio="Tarefas Realizadas", StatusTarefa = "Done" },
            new RelatorioTarefas { RelatorioId = 4, NomeRelatorio="Tarefas a Implementar", StatusTarefa = "Ice Box" }
        };

        public IActionResult Index()
        {
            return View(_relatorio);
        }
        [HttpGet] 
        public IActionResult Create()
        {
            return View();
        }

       [HttpPost] 
        public IActionResult Create(RelatorioTarefas relatorio) 
        {
            if (ModelState.IsValid)
            {
                relatorio.RelatorioId = _relatorio.Count > 0 ? _relatorio.Max(r => r.RelatorioId) + 1 : 1;
                _relatorio.Add(relatorio);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var relatorio = _relatorio.FirstOrDefault(r => r.RelatorioId == id);

            if (relatorio == null)
            {
                return NotFound();
            }
            _relatorio.Remove(relatorio);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var relatorio = _relatorio.FirstOrDefault(r => r.RelatorioId == id);
            if (relatorio == null)
            {
                return NotFound();
            }

            return View(relatorio);
        }

        [HttpPost]
        public IActionResult Edit(RelatorioTarefas relatorio)
        {
            if (ModelState.IsValid)
            {
                var existingRelatorio = _relatorio.FirstOrDefault(r => r.RelatorioId == relatorio.RelatorioId);
                if (existingRelatorio != null)
                {
                    existingRelatorio.NomeRelatorio = relatorio.NomeRelatorio;
                    existingRelatorio.StatusTarefa = relatorio.StatusTarefa;
                }
                return RedirectToAction("Index");
            }
            return View(relatorio);
        }

        public IActionResult Detalhes(int id)
        {
            var relatorio = _relatorio.FirstOrDefault(r => r.RelatorioId == id);

            if (relatorio == null)
            {
                return NotFound();
            }
            return View(relatorio);

        }

    }
}
    

