using UnityEngine;
using UnityEngine.UI;

public class PayButtonHandler : MonoBehaviour
{
    public Button payButton;
    public Animator clerkAnimator;
    public Canvas thanksCanvas;
    private CartManager cartManager;

    void Start()
    {
        cartManager = CartManager.Instance;
        payButton.onClick.AddListener(OnPayButtonClicked);
    }

    void OnPayButtonClicked()
    {
        clerkAnimator.SetTrigger("Wave");
        cartManager.ClearCart();
        gameObject.SetActive(false);
        thanksCanvas.gameObject.SetActive(true);
    }
}