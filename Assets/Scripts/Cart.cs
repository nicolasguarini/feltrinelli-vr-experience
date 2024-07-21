using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    private List<MediaItem> cartItems = new List<MediaItem>();

    public void AddToCart(MediaItem item)
    {
        if (!cartItems.Contains(item))
        {
            cartItems.Add(item);
            Debug.Log($"{item.itemName} added to cart. Price: {item.price}");
        }
        else
        {
            Debug.Log($"{item.itemName} is already in the cart.");
        }
    }

    public float CalculateTotal()
    {
        float total = 0f;
        foreach (MediaItem item in cartItems)
        {
            total += item.price;
        }
        return total;
    }
}