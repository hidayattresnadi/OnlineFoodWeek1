namespace OnlineFood.Models {
    public class Restaurant {
    private string name;
    public Restaurant (string name){
        this.name = name;
    }
    private List<MenuItem> Menu = new List<MenuItem>();
    private List<Order> Orders = new List<Order>();
    public string Name {
        get { return name; }
        set { name = value; }
    }

    public bool ValidateItems(MenuItem item){
        if (Menu.Any(x => x.Name == item.Name && x.Description == item.Description && x.Price == item.Price))
        {
            if (item is Food foodItem){
            if (Menu.OfType<Food>().Any(x => x.GetSpiciness() == foodItem.GetSpiciness()))
            {
                return false;
            }
        }
        if (item is Beverage beverageItem){
            if (Menu.OfType<Beverage>().Any(x => x.GetSize() == beverageItem.GetSize()))
            {
                return false;
            }
        }
        if (item is Dessert dessertItem){
            if (Menu.OfType<Dessert>().Any(x => x.GetSugarLevel() == dessertItem.GetSugarLevel()))
            {
                return false;
            }
        }
        }
        return true;
    }

    public void AddItems(MenuItem item){
        bool isNotAvailable = ValidateItems(item);
        if (isNotAvailable == false){
            if (item is Food){
                Console.WriteLine("Item with the same spiciness level already exists. Cannot add this item.");
            }
            else if(item is Beverage){
                Console.WriteLine("Item with the same size level already exists. Cannot add this item.");
            }
            else if(item is Dessert){
                Console.WriteLine("Item with the same sugar level already exists. Cannot add this item.");
            }
        }
        if(isNotAvailable){
           Menu.Add(item);
           Console.WriteLine("Menu item is added into " + name); 
        } 
    }
    public void ReceiveOrders(Order order){
        Orders.Add(order);
        Console.WriteLine("Order is added");
    }
    public void CalculateRevenue(){
        int totalPrices = Orders.Where(x=>x.GetOrderStatus()=="Delivered").Sum(x=>x.CalculateTotal());
        Console.WriteLine("this is revenue from restaurant: " + name);
        Console.WriteLine(totalPrices);
    }

    public List<Order> GetOrder(){
        return Orders;
    }
    }
}
