namespace OnlineFood.Models
{
    public class Food : MenuItem
    {
        private int Spiciness;

        public Food(string name, string description, int basePrice, int spiciness)
            : base(name, description, basePrice)
        {
            this.Spiciness = spiciness;
        }
        public int GetSpiciness()
        {
            return Spiciness;
        }
        public override int CalculatePrice()
        {
            int price = Price + (1000 * Spiciness);
            return price;
        }
    }
}