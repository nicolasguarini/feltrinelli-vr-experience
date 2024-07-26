using UnityEngine;
using UnityEngine.UI;

public class CheckoutButtonHandler : MonoBehaviour
{
    public Button checkoutButton;
    public Animator clerkAnimator;
    public Canvas checkoutCanvas;

    private CartManager cartManager;

    void Start()
    {
        cartManager = CartManager.Instance;
        if (cartManager.GetItemsCount() > 0) {
            gameObject.SetActive(true);
            checkoutButton.onClick.AddListener(OnCheckoutButtonClicked);
        } else {
            gameObject.SetActive(false);
        }
    }

    void OnCheckoutButtonClicked()
    {
        clerkAnimator.SetTrigger("Talk");
        checkoutCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}