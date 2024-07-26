using UnityEngine;
using TMPro;

public class CheckoutUIManager : MonoBehaviour
{
    public TextMeshProUGUI totalText;
    public TextMeshProUGUI nItemsText;
    CartManager cartManager;

    void Start()
    {
        cartManager = CartManager.Instance;
        float total = cartManager.CalculateTotal();
        int nItems = cartManager.GetItemsCount();
        totalText.text = $"Total: ${total:F2}";
        nItemsText.text = $"{nItems} Items in cart";
    }
}