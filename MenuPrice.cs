public class Food : MenuItem {
    private int Spiciness;

    public Food(string name, string description, int basePrice, int spiciness) 
        : base(name, description, basePrice) {
        this.Spiciness = spiciness;
    }
    public int GetSpiciness(){
        return Spiciness;
    }
    public override int CalculatePrice()
    {
        int price = Price + (1000*Spiciness);
        return price;
    }
}

public class Beverage : MenuItem {
    private int Size;
    public Beverage(string name, string description, int basePrice, int size) 
        : base(name, description, basePrice) {
        this.Size = size;
    }
    public int GetSize(){
        return Size;
    }
    public override int CalculatePrice()
    {
        int price = Price + (1000*Size);
        return price;
    }
}

public class Dessert : MenuItem {
    private int SugarLevel;
    public Dessert(string name, string description, int basePrice, int SugarLevel) 
        : base(name, description, basePrice) {
        this.SugarLevel = SugarLevel;
    }
    public int GetSugarLevel(){
        return SugarLevel;
    }
    public override int CalculatePrice()
    {
       int price = Price + 1000*SugarLevel;
       return price;
    }
}