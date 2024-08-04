namespace OnlineFood.Models 
{
    public class Order {
    private Guid OrderId;
    private List<MenuItem> MenuItems = new List<MenuItem>();

    private string OrderStatus = "Processed";

    public List<MenuItem> GetAllMenuItems(){
        return MenuItems;
    }
    public Guid AddMenu(List <MenuItem> items){
        MenuItems=items;
        Guid newOrderId = Guid.NewGuid();
        OrderId = newOrderId;
        return newOrderId;
    }
    public int CalculateTotal(){
        int totalPrices = MenuItems.Sum(x=>x.CalculatePrice());
        return totalPrices;
    }

    public Guid GetOrderId(){
        return OrderId;
    }
    
    public string GetOrderStatus(){
        return OrderStatus;
    }

    public void SetOrderStatus(string orderStatus){
        OrderStatus = orderStatus;
    }
    }
}
