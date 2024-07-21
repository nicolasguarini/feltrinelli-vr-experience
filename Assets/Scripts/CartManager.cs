using System.Collections.Generic;
using UnityEngine;

public class CartManager : MonoBehaviour
{
    public static CartManager Instance { get; private set; }

    private List<MediaItem> mediaItems = new List<MediaItem>();

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
}