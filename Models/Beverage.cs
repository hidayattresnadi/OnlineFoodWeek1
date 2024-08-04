namespace OnlineFood.Models
{
    public class Beverage : MenuItem
    {
        private int Size;
        public Beverage(string name, string description, int basePrice, int size)
            : base(name, description, basePrice)
        {
            this.Size = size;
        }
        public int GetSize()
        {
            return Size;
        }
        public override int CalculatePrice()
        {
            int price = Price + (1000 * Size);
            return price;
        }
    }
}