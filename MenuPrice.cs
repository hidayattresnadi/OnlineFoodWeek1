public class Food : MenuItem {
    private int spiciness;
    public override int CalculatePrice()
    {
        return 20000;
    }
}

public class Beverage : MenuItem {
    private int size;
    public override int CalculatePrice()
    {
        return 10000;
    }
}

public class Dessert : MenuItem {
    private int sugarLevel;
    public override int CalculatePrice()
    {
        return 5000;
    }
}