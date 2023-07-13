namespace DesignPattern.CQRS.CQRSPattern.Commands
{
    public class CreateProductCommand
    {
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public bool ProductStatus { get; set; }
    }
}
