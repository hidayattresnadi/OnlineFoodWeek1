public abstract class MenuItem {
    private string name;
    private string description;
    private int price;

    public MenuItem(string name, string description,int price) {
        this.name = name;
        this.description = description;
        this.price = price;
    }

    public string Name {
        get { return name; }
        set { name = value; }
    }

    public string Description {
        get { return description; }
        set { description = value; }
    }

    public int Price {
        get { return price; }
        set { price = value; }
    }
    public abstract int CalculatePrice();
}