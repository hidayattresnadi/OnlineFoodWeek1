namespace OnlineFood.Models
{
    public class Dessert : MenuItem
    {
        private int SugarLevel;
        public Dessert(string name, string description, int basePrice, int SugarLevel)
            : base(name, description, basePrice)
        {
            this.SugarLevel = SugarLevel;
        }
        public int GetSugarLevel()
        {
            return SugarLevel;
        }
        public override int CalculatePrice()
        {
            int price = Price + 1000 * SugarLevel;
            return price;
        }
    }
}