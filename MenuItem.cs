public abstract class MenuItem {
    private string name;
    private string description;
    private int price;

    public abstract int CalculatePrice();
}