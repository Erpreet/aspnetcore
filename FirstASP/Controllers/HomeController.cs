using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstASP.Models;

namespace FirstASP.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TestPage(string item)
        {
            if(!string.IsNullOrWhiteSpace(item))
            {
                AddedItems.Add(item);
            }

            ViewBag.Items = AddedItems;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static List<Person> People = new List<Person>();
        public void CreatePerson(string firstName, string lastName)
        {
            People.Add(new Person()
            {
                FirstName = firstName.Trim(),
                LastName = lastName.Trim()
            });
        }

        public void DeletePersonByFirstName( string firstName)
        {
            People.Remove(GetPersonByFirstName(firstName));
           
        }

        public Person GetPersonByFirstName(string firstName)
        {
            return People.Where(x => x.FirstName.Trim().ToUpper() == firstName.Trim().ToUpper()).SingleOrDefault();
        }
    }
}
