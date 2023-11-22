﻿using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        public IActionResult Login(string email, string password)
        {
            UsuarioEntity entity = new UsuarioEntity();
            UsuarioModel user = new UsuarioModel();
            int resposta = 0;

            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
            {
                ViewBag.erro = "Usuario ou senha inválidos!";
            }
            else
            {
                entity.Email = email;
                entity.Password = password;

                resposta = user.Login(entity);

                if (resposta == 1)
                {
                    return RedirectToAction("Index");
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
    }
}