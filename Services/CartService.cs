using GAME4YOU.Entities;
using System.Linq;

public class CartService
{
    private List<CartItem> _cartItems = new(); 

    public IReadOnlyList<CartItem> GetCartItems() => _cartItems.AsReadOnly();

    public void AddToCart(Product product)
    {
        var cartItem = _cartItems.FirstOrDefault(item => item.ProductId == product.Id);
        if (cartItem != null)
        {
            cartItem.Quantity++;  
        }
        else
        {
            _cartItems.Add(new CartItem { Product = product, ProductId = product.Id, Quantity = 1 });  
        }
    }

    public void RemoveFromCart(Product product)
    {
        var cartItem = _cartItems.FirstOrDefault(item => item.ProductId == product.Id);
        if (cartItem != null)
        {
            _cartItems.Remove(cartItem);
        }
    }

    public void ClearCart()
    {
        _cartItems.Clear();
    }

    public int GetCartItemCount()
    {
        return _cartItems.Sum(item => item.Quantity); 
    }

    public int GetCartItemCountByProduct(int productId)
    {
        var cartItem = _cartItems.FirstOrDefault(item => item.ProductId == productId);
        return cartItem?.Quantity ?? 0;
    }

    public void UpdateQuantity(Product product, int newQuantity)
    {
        var cartItem = _cartItems.FirstOrDefault(item => item.Product.Id == product.Id);
        if (cartItem != null)
        {
            cartItem.Quantity = newQuantity;
        }
    }
}
