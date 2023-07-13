using DesignPattern.ChainOfResponsibility.ChainOfResponsibility;
using DesignPattern.ChainOfResponsibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.ChainOfResponsibility.Controllers
{
    public class ChainOfController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel customerProcess)
        {
            Employee treasurer=new Treasurer();
            Employee managerAssistant= new ManagerAssistant();
            Employee manager= new Manager();
            Employee regionalDirector= new RegionalDirector();

            treasurer.SetNextApprover(managerAssistant);
            managerAssistant.SetNextApprover(manager);
            manager.SetNextApprover(regionalDirector);

            treasurer.ProcessRequest(customerProcess);
            return View();
        }
    }
}
