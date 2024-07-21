using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    private CartManager cartManager;

    void Start()
    {
        cartManager = CartManager.Instance;
    }

    public void AddToCart(MediaItem item)
    {
        if (!cartManager.GetItems().Contains(item))
        {
            cartManager.AddItem(item);
        }
    }

    public float CalculateTotal()
    {
        float total = 0f;
        foreach (MediaItem item in cartManager.GetItems())
        {
            total += item.price;
        }
        return total;
    }
}