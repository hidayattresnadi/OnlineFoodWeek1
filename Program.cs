class Program {
    public static void Main() {
        // Create onlineFoodOrder system
        OnlineFoodOrderingSystem onlineFoodOrderingSystem= new();
        Restaurant warteg = new("warteg");
        Restaurant warteg1 = new("warteg");
        Restaurant pizzaHut = new ("pizzaHut");
        Restaurant domino = new ("Domino");
        // Restoran Warteg
        Food bakso = new("Bakso","make daging ayam dan mie",10000,3);
        Food bakso2 = new("Bakso","make daging ayam dan mie",10000,3);
        Beverage milkTea = new("Milk Tea","susu dan teh",10000,3);
        Beverage milkTea2 = new("Milk Tea","susu dan teh",10000,3);
        Dessert mocchi = new("Mochi","kenyal dan enak",10000,3);
        Dessert mocchi2 = new("Mochi","kenyal dan enak",10000,3);
        Dessert mocchi3 = new("Mochi","kenyal dan enak",10000,4);
        warteg.AddItems(bakso);
        warteg.AddItems(milkTea);
        warteg.AddItems(mocchi);

        // Add Dupplicate Menu
        warteg.AddItems(bakso2);
        warteg.AddItems(milkTea2);
        warteg.AddItems(mocchi2);

        onlineFoodOrderingSystem.AddRestaurant(warteg);
        onlineFoodOrderingSystem.AddRestaurant(pizzaHut);
        onlineFoodOrderingSystem.AddRestaurant(domino);

        // Add Dupplicate Restaurant
        onlineFoodOrderingSystem.AddRestaurant(warteg1);

        // Resturant Pizza
        pizzaHut.AddItems(bakso2);
        pizzaHut.AddItems(milkTea2);
        pizzaHut.AddItems(mocchi2);


        // Ordering process from customer
        List<MenuItem> ordersCustomer1 = [bakso, milkTea,mocchi];
        List<MenuItem> ordersCustomer2 = [bakso, milkTea,mocchi3];
        Guid newOrderId2 = onlineFoodOrderingSystem.PlaceOrder("warteg",ordersCustomer1);
        Guid newOrderId = onlineFoodOrderingSystem.PlaceOrder("warteg",ordersCustomer1);
        // food is not exist at restaurant
        onlineFoodOrderingSystem.PlaceOrder("warteg",ordersCustomer2);
        // Customer add not exist restaurant
        onlineFoodOrderingSystem.PlaceOrder("warteg123",ordersCustomer1);
        Console.WriteLine(newOrderId);
        onlineFoodOrderingSystem.DisplayOrderDetails(newOrderId);
        onlineFoodOrderingSystem.DisplayOrderDetails(newOrderId);
        onlineFoodOrderingSystem.UpdateOrderStatus(newOrderId,"Delivered");
        // onlineFoodOrderingSystem.CancelOrder(newOrderId2);
        onlineFoodOrderingSystem.UpdateOrderStatus(newOrderId2,"Delivered");
        // onlineFoodOrderingSystem.CancelOrder(newOrderId);
        warteg.CalculateRevenue();
        onlineFoodOrderingSystem.GetOrderStatus(newOrderId);

        // warteg.AddItems()
    }
}

