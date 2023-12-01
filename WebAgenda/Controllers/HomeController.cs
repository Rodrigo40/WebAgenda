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
                var listaTerefa = new TarefasModel();
                if (listaTerefa.ListarTarefas() != null)
                {
                    return View(listaTerefa);
                }
            }
            catch (Exception)
            {

            }
            return View();
        }
        public IActionResult Login(string email, string password)
        {
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
                if (string.IsNullOrWhiteSpace(titulo) && string.IsNullOrWhiteSpace(tarefa) && string.IsNullOrWhiteSpace(dataTarefa))
                {
                    ViewBag.erro = "Os campos são obrigatórios!";
                }
                else
                {
                    var listaTerefa = new TarefasModel();
                    var novaTarefa = new TarefasModel();
                    ViewBag.ok = novaTarefa.NovaTarefa(titulo, tarefa, dataTarefa);
                    return View("Index",listaTerefa);
                }
            }
            catch (Exception)
            {

            }
            return View();
        }
        // Fim
    }
}