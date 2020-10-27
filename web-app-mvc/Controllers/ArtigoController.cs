using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace web_app_mvc.Controllers
{
    public class ArtigoController : Controller
    {

        private readonly IConfiguration configuration;

        public IActionResult Index()
        {
            string connectionString = configuration.GetConnectionString("Def");
            var connection = new MySqlConnection(connectionString);

            connection.Open();

            using var command = new MySqlCommand("SELECT * FROM Artigos;", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var value = reader.GetValue(0);
                ViewData["data"] = value;
            }


            return View();
        }
    }
}
