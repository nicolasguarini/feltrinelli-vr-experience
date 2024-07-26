using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Cart : MonoBehaviour
{
    private CartManager cartManager;
    public GameObject listItemPrefab;
    public Transform content;
    public TextMeshProUGUI totalPriceText;
    public TextMeshProUGUI nItemsText;

    void Start()
    {
        cartManager = CartManager.Instance;
        cartManager.SetHasVisitedFloor2(true);
        UpdateCartDisplay();
    }

    public void AddToCart(MediaItem item)
    {
        if (!cartManager.GetItems().Contains(item))
        {
            cartManager.AddItem(item);
            item.gameObject.SetActive(false);
            UpdateCartDisplay();
        }
    }

    public void RemoveFromCart(MediaItem item)
    {
        if (cartManager.GetItems().Contains(item))
        {
            cartManager.RemoveItem(item);
            item.gameObject.SetActive(true);
            item.RestoreOriginalTransform();
            UpdateCartDisplay();
        }
    }

    public void UpdateCartDisplay()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (MediaItem item in cartManager.GetItems())
        {
            GameObject listItem = Instantiate(listItemPrefab, content);
            TMP_Text[] texts = listItem.GetComponentsInChildren<TMP_Text>();
            texts[0].text = item.itemName;
            texts[1].text = "$" + item.price.ToString("F2");

            Button removeButton = listItem.GetComponentInChildren<Button>();
            removeButton.onClick.AddListener(() => RemoveItemAndUpdate(item));
        }

        totalPriceText.text = "$" + CalculateTotal().ToString("F2");
        nItemsText.text = cartManager.GetItems().Count.ToString();
    }

    private void RemoveItemAndUpdate(MediaItem item)
    {
        RemoveFromCart(item);
        UpdateCartDisplay();
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