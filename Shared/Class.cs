namespace GriffinsStore1.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

public static class CartService
{
    public static List<CartItem> CartItems { get; set; } = new List<CartItem>();

    public static void AddToCart(CartItem item)
    {
        var existingItem = CartItems.FirstOrDefault(x => x.Name == item.Name);

        if (existingItem != null)
        {
            existingItem.Quantity += item.Quantity;
        }
        else
        {
            CartItems.Add(item);
        }
    }

    public static void RemoveFromCart(CartItem item)
    {
        CartItems.Remove(item);
    }

    public static void ClearCart()
    {
        CartItems.Clear();
    }

    public static int GetCartCount()
    {
        return CartItems.Sum(x => x.Quantity);
    }

    public static decimal GetCartTotal()
    {
        return CartItems.Sum(x => x.Price * x.Quantity);
    }
}

public class CartItem
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int Quantity { get; set; } = 1;
}