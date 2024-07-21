using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MediaItem : MonoBehaviour
{
    public string itemName;
    public float price;

    private Cart cart;

    [HideInInspector] public Vector3 originalPosition;
    [HideInInspector] public Quaternion originalRotation;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        cart = FindObjectOfType<Cart>();
    }

    public void OnActivate(ActivateEventArgs args)
    {
        MediaItem mediaItem = args.interactableObject.transform.GetComponent<MediaItem>();

        if (mediaItem != null && cart != null)
        {
            cart.AddToCart(mediaItem);
        }
    }
}