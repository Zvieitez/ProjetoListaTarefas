using Microsoft.AspNetCore.Mvc;
using ProjetoListaTarefas.Models;
using ProjetoListaTarefas.Models;

namespace ProjetoListaTarefas.Controllers
{
    public class TarefaController : Controller
    {

        private static List<Tarefa> _tarefa = new List<Tarefa>()
        {
            new Tarefa { TarefaId= 1, NomeTarefa="Definir Tarefa", Descricao="Definir Ações", StatusTarefa="To Do" },
            new Tarefa { TarefaId= 2, NomeTarefa="Fazendo Tarefa", Descricao="Definir Ações", StatusTarefa="Doing" },
            new Tarefa { TarefaId= 3, NomeTarefa="Tarefa Finalizada", Descricao="Definir Ações", StatusTarefa="Done" }
        };

        public IActionResult Index()
        {
            return View(_tarefa);
        }

        [HttpGet] //anotação de pegar
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //anotação de enviar | qdo não coloca a anotação, o defaul é [HttpGet]
        public IActionResult Create(Tarefa tarefa) //recebe os dados do formulário
        {
            if (ModelState.IsValid)
            {
                //ternário: se o valor de _clienteId>0 então some +1 a _clienteId, se não tem, o _clienteID é 1
                tarefa.TarefaId = _tarefa.Count > 0 ? _tarefa.Max(t => t.TarefaId) + 1 : 1;
                _tarefa.Add(tarefa);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var tarefa = _tarefa.FirstOrDefault(t => t.TarefaId == id);

            if (tarefa == null)
            {
                return NotFound();
            }
            _tarefa.Remove(tarefa);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var tarefa = _tarefa.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                var existingTarefa = _tarefa.FirstOrDefault(t => t.TarefaId == tarefa.TarefaId);
                if (existingTarefa != null)
                {
                    existingTarefa.NomeTarefa = tarefa.NomeTarefa;
                }
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        public IActionResult Detalhes(int id)
        {
            var tarefa = _tarefa.FirstOrDefault(t => t.TarefaId == id);

            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);

        }

    }
}
