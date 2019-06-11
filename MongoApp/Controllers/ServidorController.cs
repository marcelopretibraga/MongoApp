using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoApp.Models;
using MongoDB.Bson;
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

        [HttpGet]
        public IActionResult Delete(string Id)
        {
            //View(_mongoDBContext.Servidores.Find(s => s.Id == ObjectId.Parse(Id)));
            var servidorDel = _mongoDBContext.Servidores
                .Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
            return View(servidorDel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string Id)
        {
            var servidorDel = _mongoDBContext.Servidores
                .DeleteOne(s => s.Id == ObjectId.Parse(Id));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string Id)
        {
            var serv = _mongoDBContext.Servidores.Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
            return View(serv);
        }

        [HttpPost]
        public ActionResult Edit(Servidor servidor, string id)
        {
            if (ModelState.IsValid)
            {
                servidor.Id = ObjectId.Parse(id);
                var filter = new BsonDocument("_id", ObjectId.Parse(id));
                //var filter = Builders<Servidor>.Filter.Eq(s => s.Id, servidor.Id);
                _mongoDBContext.Servidores.ReplaceOne(filter, servidor);
                
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}