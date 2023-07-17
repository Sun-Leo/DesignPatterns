using BusinessLayer.Abstract;
using DesignPattern.UnitOfWork.Models;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPattern.UnitOfWork.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICustomerService _customerService;

        public DefaultController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CustomerViewModel customerViewModel)
        {
            var value1 = _customerService.TGetById(customerViewModel.SenderID);
            var value2 = _customerService.TGetById(customerViewModel.ReceiverID);

            value1.CustomerBalance -= customerViewModel.Amount;
            value2.CustomerBalance += customerViewModel.Amount;

            List<Customer> modifiedCustomer = new List<Customer>() 
            { 
            value1,
            value2
            };
            _customerService.TMultiUpdate(modifiedCustomer);
            return View();
        }
    }
}
