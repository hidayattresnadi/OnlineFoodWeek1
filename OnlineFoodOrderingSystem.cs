public class OnlineFoodOrderingSystem : IOrderingSystem {
    private static List<Restaurant> Restaurants = new List<Restaurant>();
    public void AddRestaurant(Restaurant restaurant){
        Restaurant checkAvailableRestaurant=Restaurants.FirstOrDefault(x=>x.Name == restaurant.Name);
        if(checkAvailableRestaurant != null){
            Console.WriteLine("Restaurant name is added already, please use another name");
            return;
        }
        Restaurants.Add(restaurant);
        Console.WriteLine("Restaurant is added");
    }
    public Guid PlaceOrder(string restaurantName, List<MenuItem> orderedItems){
        int indexRestaurant = Restaurants.FindIndex(re => re.Name == restaurantName);
        if (indexRestaurant == -1) {
            Console.WriteLine("Order placement failed because Restaurant is not found");
            return Guid.Empty;
        }
        int count = 0;
        foreach (var item in orderedItems)
        {
            bool isNotAvailable = Restaurants[indexRestaurant].ValidateItems(item);
            if (isNotAvailable == true){
                break;
            }
            count++;
        }
        if (count < orderedItems.Count()) {
            Console.WriteLine("Food is not exist at this restaurant");
            return Guid.Empty;
        }
        orderedItems.Sum(x=>x.CalculatePrice());
        var newOrder = new Order();
        var orderId = newOrder.AddMenu(orderedItems);
        Restaurants[indexRestaurant].ReceiveOrders(newOrder);
        return orderId;    
    }
    public void DisplayOrderDetails(Guid orderId){
        Order foundOrder = null;
        foreach (var item in Restaurants)
        {
            foundOrder=item.GetOrder().FirstOrDefault(s =>s.GetOrderId() == orderId);
            if (foundOrder != null){
                break;
            }
        }
        if (foundOrder == null){
            Console.WriteLine("Order is not found");
        }
        else {
            Console.WriteLine("Your status order is "+foundOrder.GetOrderStatus());
            Console.WriteLine("Order Id: "+foundOrder.GetOrderId());
            foreach (var item in foundOrder.GetAllMenuItems())
            {
                Console.WriteLine("Item you ordered is: "+item.Name);
                Console.WriteLine("Price from this item is: " + item.CalculatePrice());
            }
            Console.WriteLine("total order price is: "+foundOrder.CalculateTotal());
        }
    }

    public void CancelOrder(Guid orderId){
        int foundOrder = 0;
        bool isRemoved =false;
        foreach (var item in Restaurants)
        {
            foundOrder=item.GetOrder().FindIndex(s =>s.GetOrderId() == orderId);
            if(foundOrder != -1){
                item.GetOrder()[foundOrder].SetOrderStatus("Cancelled");
                isRemoved=true;
                break;
            }
        }
        if (isRemoved){
            Console.WriteLine("Order is cancelled");
        }
        else{
            Console.WriteLine("Order is not found");
        }
    }
    public void UpdateOrderStatus(Guid orderId, string orderStatus){
        if (orderStatus != "Delivered" && orderStatus != "Cancelled"){
            Console.WriteLine("Order status can be changed to Delivered or Cancelled only");
            return;
        }
        int foundOrder = 0;
        bool isChanged =false;
        foreach (var item in Restaurants)
        {
            foundOrder=item.GetOrder().FindIndex(s =>s.GetOrderId() == orderId);
            if(foundOrder != -1){
                item.GetOrder()[foundOrder].SetOrderStatus(orderStatus);
                isChanged=true;
                break;
            }
        }
        if (isChanged){
            Console.WriteLine("Order status is updated to "+ orderStatus);
        }
        else{
            Console.WriteLine("Order is not found");
        }
    }
    public void GetOrderStatus(Guid orderId){
        Order foundOrder = null;
        foreach (var item in Restaurants)
        {
            foundOrder=item.GetOrder().FirstOrDefault(s =>s.GetOrderId() == orderId);
            if (foundOrder != null){
                break;
            }
        }
        if (foundOrder == null){
            Console.WriteLine("Order is not found");
        }
        else{
            Console.WriteLine(foundOrder.GetOrderStatus());
        }
    }   
}