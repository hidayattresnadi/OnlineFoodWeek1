using OnlineFood.Models;
class Program {
    public static void Main() {
        // Create onlineFoodOrder system
        OnlineFoodOrderingSystem onlineFoodOrderingSystem= new();
        Restaurant warteg = new("warteg");
        Restaurant warteg1 = new("warteg");
        Restaurant pizzaHut = new ("pizzaHut");
        Restaurant domino = new ("Domino");
        Food bakso = new("Bakso","make daging ayam dan mie",10000,3);
        Food pizza = new("Pizza","chciken Peperoni",70000,3);
        Food bakso2 = new("Bakso","make daging ayam dan mie",10000,3);
        Beverage milkTea = new("Milk Tea","susu dan teh",10000,3);
        Beverage milkTea2 = new("Milk Tea","susu dan teh",10000,3);
        Dessert mocchi = new("Mochi","kenyal dan enak",10000,3);
        Dessert mocchi2 = new("Mochi","kenyal dan enak",10000,3);
        Dessert mocchi3 = new("Mochi","kenyal dan enak",10000,4);

        // Add menu at warteg Restaurant
        warteg.AddItems(bakso);
        warteg.AddItems(milkTea);
        warteg.AddItems(mocchi);

        // Add Dupplicate Menu at warteg
        warteg.AddItems(bakso2);
        warteg.AddItems(milkTea2);
        warteg.AddItems(mocchi2);

        onlineFoodOrderingSystem.AddRestaurant(warteg);
        onlineFoodOrderingSystem.AddRestaurant(pizzaHut);
        onlineFoodOrderingSystem.AddRestaurant(domino);

        // Add Dupplicate Restaurant
        onlineFoodOrderingSystem.AddRestaurant(warteg1);

        // Add menu at Resturant Pizza
        pizzaHut.AddItems(pizza);
        pizzaHut.AddItems(milkTea2);


        // Ordering process from customer to warteg Restaurant
        List<MenuItem> ordersCustomer1 = [bakso, milkTea,mocchi];
        List<MenuItem> ordersCustomer2 = [bakso, milkTea,mocchi3];
        List<MenuItem> ordersCustomer3 = [pizza, milkTea];
        Guid newOrderId3 = onlineFoodOrderingSystem.PlaceOrder("warteg",ordersCustomer1);
        Guid newOrderId2 = onlineFoodOrderingSystem.PlaceOrder("warteg",ordersCustomer1);
        Guid newOrderId = onlineFoodOrderingSystem.PlaceOrder("warteg",ordersCustomer1);
        // order food which is not exist at warteg restaurant
        onlineFoodOrderingSystem.PlaceOrder("warteg",ordersCustomer2);
        // Customer add not exist restaurant
        onlineFoodOrderingSystem.PlaceOrder("warteg123",ordersCustomer1);
        Console.WriteLine(newOrderId);
        onlineFoodOrderingSystem.DisplayOrderDetails(newOrderId);
        onlineFoodOrderingSystem.UpdateOrderStatus(newOrderId,"Delivered");
        onlineFoodOrderingSystem.UpdateOrderStatus(newOrderId3,"Delivered");
        // Tryin cancel Order
        onlineFoodOrderingSystem.CancelOrder(newOrderId2);
        warteg.CalculateRevenue();
        onlineFoodOrderingSystem.GetOrderStatus(newOrderId);

        // Order food from Piza Restaurant
        Guid newOrderId4 = onlineFoodOrderingSystem.PlaceOrder("pizzaHut",ordersCustomer3);
        onlineFoodOrderingSystem.DisplayOrderDetails(newOrderId4);
        onlineFoodOrderingSystem.UpdateOrderStatus(newOrderId4,"Delivered");
        pizzaHut.CalculateRevenue();
    }
}