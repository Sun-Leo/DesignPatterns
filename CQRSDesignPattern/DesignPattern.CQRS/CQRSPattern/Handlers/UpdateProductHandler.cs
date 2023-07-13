using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class UpdateProductHandler
    {
        private readonly Context _context;

        public UpdateProductHandler(Context context)
        {
            _context = context;
        }

        public void Handle(GetProductByIDResult getProductByID)
        {
            var value = _context.Products.Find(getProductByID.ProductID);
            value.ProductName = getProductByID.ProductName;
            value.ProductPrice = getProductByID.ProductPrice;
            value.ProductStock = getProductByID.ProductStock;
            value.ProductStatus = getProductByID.ProductStatus;
            _context.SaveChanges();
        }
    }
}
