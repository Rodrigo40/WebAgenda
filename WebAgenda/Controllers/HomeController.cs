using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAgenda.Entity;
using WebAgenda.Models;

namespace WebAgenda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                if (UsuarioEntity.GetInstancia().Nome != string.Empty)
                {
                    var listaTerefa = new TarefasModel();
                    if (listaTerefa.ListarTarefas() != null)
                    {
                        return View(listaTerefa);
                    }
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception)
            {

            }
            return View();
        }
        public IActionResult Login(string email, string password)
        {
            UsuarioEntity.GetInstancia().Nome = string.Empty;
            UsuarioEntity entity = new UsuarioEntity();
            UsuarioModel user = new UsuarioModel();
            int resposta = 0;

            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
            {
                ViewBag.erro = "Todos os campos são obrigatórios!";
            }
            else
            {
                entity.Email = email;
                entity.Password = password;

                resposta = user.Login(entity);
                UsuarioEntity.GetInstancia().Nome = user.GetUsuarios()[0].Nome;

                if (resposta == 1)
                {
                    // Falta carregar os dados do usuario
                    TempData["SuccessMessage"] = "Bem vindo, é sempre bom ve-ló!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.erro = "Usuario ou senha inválidos!";
                }
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Logout()
        {
            TempData["SuccessMessage"] = $"A sua sessão foi finalizada ({UsuarioEntity.GetInstancia().Nome})";
            UsuarioEntity.GetInstancia().Nome = string.Empty;
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // Ações para as Tarefas
        public IActionResult NovaTarefa(string titulo, string tarefa, string dataTarefa)
        {
            try
            {
                if (UsuarioEntity.GetInstancia().Nome != string.Empty)
                {
                    if (string.IsNullOrWhiteSpace(titulo) && string.IsNullOrWhiteSpace(tarefa) && string.IsNullOrWhiteSpace(dataTarefa))
                    {
                        ViewBag.erro = "";
                    }
                    else
                    {
                        var listaTerefa = new TarefasModel();
                        var novaTarefa = new TarefasModel();
                        ViewBag.ok = novaTarefa.NovaTarefa(titulo, tarefa, dataTarefa);
                        TempData["SuccessMessage"] = ViewBag.ok;
                        return View("Index", listaTerefa);
                    }
                }
                else
                {
                    return RedirectToAction("Login");
                }

            }
            catch (Exception)
            {

            }
            return View();
        }
        public IActionResult EditarTarefas(int id)
        {
            try
            {
                var entidade = new TarefasEntity();
                var tarefa = new TarefasModel();
                entidade.ListaTarefas = tarefa.ListarTarefasById(id);
                return View(entidade);
            }
            catch (Exception)
            {

            }
            return View();
        }
        public IActionResult Salvar(int id, string titulo, string tarefa, string dataTarefa)
        {
            // Update data from Tarefas table
            var update = new TarefasModel();
            TempData["SuccessMessage"] = update.EditarTarefa(id, titulo, tarefa, dataTarefa);
            return RedirectToAction("Index");
        }
        public IActionResult Eliminar(int id)
        {
            // Update data from Tarefas table
            var eliminar = new TarefasModel();
            TempData["SuccessMessage"] = eliminar.EliminarTarefa(id);
            return RedirectToAction("Index");
        }
        // Fim
    }
}