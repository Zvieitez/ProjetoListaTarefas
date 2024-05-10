using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using ProjetoListaTarefas.Models;

namespace ProjetoListaTarefas.Controllers
{
    public class UsuarioController : Controller
    {

        private static List<Usuario> _usuario = new List<Usuario>()
        {
            new Usuario { UsuarioId= 1, NomeUsuario="Zandra Vieitez" },
            new Usuario { UsuarioId= 2, NomeUsuario="Lucas Almeida" },
            new Usuario { UsuarioId= 3, NomeUsuario="Ângelo Polatto" },
            new Usuario { UsuarioId= 4, NomeUsuario="Lêda Almeida" },
        };

        public IActionResult Index()
        {
            return View(_usuario);
        }

        [HttpGet] 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Create(Usuario usuario) 
        {
            if (ModelState.IsValid)
            {
                usuario.UsuarioId = _usuario.Count > 0 ? _usuario.Max(u => u.UsuarioId) + 1 : 1;
                _usuario.Add(usuario);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var usuario = _usuario.FirstOrDefault(u => u.UsuarioId == id);

            if (usuario == null)
            {
                return NotFound();
            }
            _usuario.Remove(usuario);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var usuario= _usuario.FirstOrDefault(u => u.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var existingUsuario = _usuario.FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId);
                if (existingUsuario != null)
                {
                    existingUsuario.NomeUsuario = usuario.NomeUsuario;
                }
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public IActionResult Detalhes(int id)
        {
            var usuario = _usuario.FirstOrDefault(u => u.UsuarioId == id);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);

        }

    }
}

