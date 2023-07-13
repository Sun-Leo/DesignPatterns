using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class GetProductHandler
    {
        private readonly Context _context;

        public GetProductHandler(Context context)
        {
            _context = context;
        }

        public List< GetProductResult> Handle()
        {
            var values = _context.Products.Select(x => new GetProductResult
            {
                ProductID = x.ProductID,
                Name=x.ProductName,
                Stock=x.ProductStock,
                Price=x.ProductPrice,
                Status=x.ProductStatus
            }


            ).ToList();
            return values;
        }
    }
}
