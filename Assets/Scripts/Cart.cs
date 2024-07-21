using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Cart : MonoBehaviour
{
    private List<CD> cartItems = new List<CD>();

    public void AddToCart(CD cd)
    {
        if (!cartItems.Contains(cd))
        {
            cartItems.Add(cd);
            Debug.Log($"{cd.cdName} added to cart. Price: {cd.price}");
        }
        else
        {
            Debug.Log($"{cd.cdName} is already in the cart.");
        }
    }

    public float CalculateTotal()
    {
        float total = 0f;
        foreach (CD cd in cartItems)
        {
            total += cd.price;
        }
        return total;
    }
}