using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CD : MonoBehaviour
{
    public string cdName;
    public float price;

    [HideInInspector] public Vector3 originalPosition;
    [HideInInspector] public Quaternion originalRotation;

    private Cart cart;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        cart = FindObjectOfType<Cart>();
    }

    public void OnActivate(ActivateEventArgs args) 
    {
        CD cd = args.interactableObject.transform.GetComponent<CD>();

        if (cd != null && cart != null)
        {
            cart.AddToCart(cd);
        }
    }
}
