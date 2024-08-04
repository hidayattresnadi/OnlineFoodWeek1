public interface IOrderingSystem {
    void AddRestaurant(Restaurant restaurant);
    Guid PlaceOrder(string restaurantName, List<MenuItem> orderedItems);
    void DisplayOrderDetails(Guid orderId);
    void UpdateOrderStatus(Guid orderId, string orderStatus);
    void CancelOrder(Guid orderId);
    void GetOrderStatus(Guid orderId);

}