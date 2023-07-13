using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.CQRSPattern.Handlers;
using DesignPattern.CQRS.CQRSPattern.Queries;
using DesignPattern.CQRS.CQRSPattern.Results;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.CQRS.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductHandler _getProductHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetProductByIDQueryHandler _getProductByIDQueryHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly UpdateProductHandler _updateProductHandler;

        public DefaultController(GetProductHandler getProductHandler, CreateProductCommandHandler createProductCommandHandler, GetProductByIDQueryHandler getProductByIDQueryHandler, RemoveProductCommandHandler removeProductCommandHandler, UpdateProductHandler updateProductCommandHandler)
        {
            _getProductHandler = getProductHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _getProductByIDQueryHandler = getProductByIDQueryHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _updateProductHandler = updateProductCommandHandler;
        }

        public IActionResult Index()
        {
            var value = _getProductHandler.Handle();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand createProduct)
        {
            _createProductCommandHandler.Handle(createProduct);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var value = _getProductByIDQueryHandler.Handle(new GetProductByIDQuery(id));
            return View(value);
        }

        [HttpPost]
        public IActionResult GetProduct(GetProductByIDResult getProduct)
        {
           
            _updateProductHandler.Handle(getProduct);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }
    }
}
