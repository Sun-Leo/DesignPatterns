using DesignPattern.CQRS.CQRSPattern.Queries;
using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;
using DesignPattern.CQRS.Entities;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class GetProductByIDQueryHandler
    {
        private readonly Context _context;

        public GetProductByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductByIDResult Handle(GetProductByIDQuery byIDQuery)
        {
            var values=_context.Set<Product>().Find(byIDQuery.Id);
            return new GetProductByIDResult
            {
                ProductName = values.ProductName,
                ProductStock = values.ProductStock,
                ProductPrice = values.ProductPrice,
                ProductStatus = values.ProductStatus,
                ProductID = values.ProductID
            };
        }
    }
}
