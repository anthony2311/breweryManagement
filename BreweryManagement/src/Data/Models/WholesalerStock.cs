namespace Data.Models
{
    public class WholesalerStock
    {
        public int quantity { get; set; }
        public int WholesalerId { get; set; }
        public Wholesaler Wholesaler { get; set; }
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
    }
}