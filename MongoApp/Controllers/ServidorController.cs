using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoApp.Models;
using MongoDB.Driver;

namespace MongoApp.Controllers
{
    public class ServidorController : Controller
    {
        private readonly MongoDBContext _mongoDBContext = 
            new MongoDBContext();

        public IActionResult Index()
        {
            return View(_mongoDBContext.Servidores.Find(s => true)
                .ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Servidor servidor)
        {
            if (ModelState.IsValid)
            {
                _mongoDBContext.Servidores.InsertOne(servidor);
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}