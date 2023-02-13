using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Medyx_EMR_BCA.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Medyx_EMR_BCA.Controllers
{
    public class DMNhanVienController : Controller
    {
        private readonly IConfiguration _config;
        public IActionResult Index()
        {
            var model = collection.Find(FilterDefinition<DMNhanVien>.Empty).ToList();
            return View(model);
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
        private IMongoCollection<DMNhanVien> collection;

        public DMNhanVienController(IConfiguration config)
        {
            _config = config;
            //var client = new MongoClient("mongodb://localhost:27017");
            //string constr = ConfigurationManager.AppSettings["MongoDBconnectionString"];
            string constr = _config.GetValue<string>("Medyx_BCADatabase:ConnectionString");
            var client = new MongoClient(constr);
            //IMongoDatabase db = client.GetDatabase("Medyx_BCA");
            //IMongoDatabase db = client.GetDatabase(ConfigurationManager.AppSettings["MongoDBDataBase"]);
            IMongoDatabase db = client.GetDatabase(_config.GetValue<string>("Medyx_BCADatabase:DatabaseName"));
            this.collection = db.GetCollection<DMNhanVien>("DMNhanVien");
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(DMNhanVien emp)
        {
            collection.InsertOne(emp);
            ViewBag.Message = "Employee added successfully!";
            //return View();
            return RedirectToAction("Index");
        }
        public IActionResult Update(string id)
        {
            ObjectId oId = new ObjectId(id);
            DMNhanVien emp = collection.Find(e => e.Id == oId).FirstOrDefault();

            return View(emp);
        }
        [HttpPost]
        public IActionResult Update(string id, DMNhanVien emp)
        {
            emp.Id = new ObjectId(id);
            var filter = Builders<DMNhanVien>.Filter.Eq("Id", emp.Id);
            var updateDef = Builders<DMNhanVien>.Update.Set("FirstName", emp.FirstName);
            updateDef = updateDef.Set("LastName", emp.LastName);
            var result = collection.UpdateOne(filter, updateDef);
            if (result.IsAcknowledged)
            {
                ViewBag.Message = "Employee updated successfully!";
            }
            else
            {
                ViewBag.Message = "Error while updating Employee!";
            }
            //return View(emp);
            return RedirectToAction("Index");
        }
        public IActionResult ConfirmDelete(string id)
        {
            ObjectId oId = new ObjectId(id);
            DMNhanVien emp = collection.Find(e => e.Id == oId).FirstOrDefault();
            return View(emp);
        }
        [HttpPost]
        public IActionResult Delete(string id)
        {
            ObjectId oId = new ObjectId(id);
            var result = collection.DeleteOne<DMNhanVien>(e => e.Id == oId);

            if (result.IsAcknowledged)
            {
                TempData["Message"] = "Employee deleted successfully!";
            }
            else
            {
                TempData["Message"] = "Error while deleting Employee!";
            }
            return RedirectToAction("Index");
        }

    }
}
