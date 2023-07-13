using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;
using DesignPattern.CQRS.Entities;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly Context _context;

        public CreateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateProductCommand command)
        {
            _context.Products.Add(new Product
            {
                ProductName = command.ProductName,
                ProductStock = command.ProductStock,
                ProductPrice = command.ProductPrice,
                ProductStatus = command.ProductStatus
            });
            _context.SaveChanges();
        }
    }
}
