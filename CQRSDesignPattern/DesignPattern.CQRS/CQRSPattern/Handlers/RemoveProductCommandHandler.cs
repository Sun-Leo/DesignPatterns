using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class RemoveProductCommandHandler
    {
        private readonly Context _context;

        public RemoveProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveProductCommand removeProduct)
        {
            var value = _context.Products.Find(removeProduct.Id);
            _context.Products.Remove(value);
            _context.SaveChanges();

        }
    }
}
