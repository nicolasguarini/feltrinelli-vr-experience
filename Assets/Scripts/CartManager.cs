using System.Collections.Generic;
using UnityEngine;

public class CartManager : MonoBehaviour
{
    public static CartManager Instance { get; private set; }

    private List<MediaItem> mediaItems = new List<MediaItem>();

    private bool hasVisitedFloor2 = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("CartManager started.");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("CartManager instance returned.");
        }
    }

    public void AddItem(MediaItem item)
    {
        if (!mediaItems.Contains(item))
        {
            mediaItems.Add(item);
            Debug.Log($"{item.itemName} added to cart. Price: {item.price}");
        }
        else
        {
            Debug.Log($"{item.itemName} is already in the list.");
        }
    }

    public void RemoveItem(MediaItem item)
    {
        if (mediaItems.Contains(item))
        {
            mediaItems.Remove(item);
            Debug.Log($"{item.itemName} removed from cart.");
        }
    }

    public float CalculateTotal()
    {
        float total = 0f;
        foreach (MediaItem item in mediaItems)
        {
            total += item.price;
        }
        return total;
    }

    public List<MediaItem> GetItems()
    {
        return mediaItems;
    }

    public int GetItemsCount()
    {
        return mediaItems.Count;
    }

    public void ClearCart()
    {
        mediaItems.Clear();
        Debug.Log("Cart cleared.");
    }

    public void SetHasVisitedFloor2(bool hasVisitedFloor2)
    {
        this.hasVisitedFloor2 = hasVisitedFloor2;
    }

    public bool GetHasVisitedFloor2()
    {
        return hasVisitedFloor2;
    }
}