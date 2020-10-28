using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using web_app_mvc.Models;

namespace web_app_mvc.Controllers
{
    public class ArtigoController : Controller
    {

        //private readonly IConfiguration configuration;

        public IActionResult Index()
        {
            string connectionString = "datasource=localhost;port=3306;database=artdesign;username=root;password=admin"; /*configuration.GetConnectionString("Def");*/
            var connection = new MySqlConnection(connectionString);

            connection.Open();

            using var command = new MySqlCommand("SELECT * FROM Artigos;", connection);
            using var reader = command.ExecuteReader();

            List<object> list = new List<object>();

            while (reader.Read())
            {
                var art = new ArtigosModel() { 
                    Id=(int)reader.GetValue(0), 
                    Descricao=(string)reader.GetValue(1), 
                    Quantidade=(int)reader.GetValue(2) };
                list.Add(art);
            }

            ViewData["data"] = list.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult SubmitArt(List<ArtigosModel> artigo = null)
        {
            artigo = artigo == null ? new List<ArtigosModel>() : artigo;

            return View(artigo);
        }

    }
}
