﻿using Microsoft.AspNetCore.Mvc;
using ProjetoListaTarefas.Models;


namespace ProjetoListaTarefas.Controllers
{
    public class TarefaController : Controller
    {

        private static List<Tarefa> _tarefa = new List<Tarefa>()
        {
            new Tarefa { TarefaId= 1, NomeTarefa="Reunião com o cliente", Descricao="Definir objetivo do negócio", DtInicio=DateTime.Today, DtFim=DateTime.Today, StatusTarefa="To Do" },
            new Tarefa { TarefaId= 2, NomeTarefa="Requisitos", Descricao="Levantamento de Requisitos", DtInicio=DateTime.Today, DtFim=DateTime.Today, StatusTarefa="To Do" },
            new Tarefa { TarefaId= 3, NomeTarefa="Design", Descricao="Elaborar Protótipos", DtInicio=DateTime.Today, DtFim=DateTime.Today, StatusTarefa="Doing" },
            new Tarefa { TarefaId= 4, NomeTarefa="Testes", Descricao="Testes de Integração", DtInicio=DateTime.Today, DtFim=DateTime.Today, StatusTarefa="Done" },
            new Tarefa { TarefaId= 5, NomeTarefa="Implantação", Descricao="Integração contínua e preparação de ambiente para implantação", DtInicio=DateTime.Today, DtFim=DateTime.Today, StatusTarefa="Done" },
            new Tarefa { TarefaId= 6, NomeTarefa="Otimização", Descricao="Análises e otimizações para melhorar o desempenho do sistema", DtInicio=DateTime.Today, DtFim=DateTime.Today, StatusTarefa="Ice Box" }
        };

        public IActionResult Index()
        {
            return View(_tarefa);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
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
                    existingTarefa.Descricao = tarefa.Descricao;
                    existingTarefa.DtInicio = tarefa.DtInicio;
                    existingTarefa.DtFim = tarefa.DtFim;
                    existingTarefa.StatusTarefa = tarefa.StatusTarefa;
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
