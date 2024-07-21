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
        SaveOriginalTransform();
        cart = FindObjectOfType<Cart>();
    }

    public void OnActivate(ActivateEventArgs args)
    {
        MediaItem mediaItem = args.interactableObject.transform.GetComponent<MediaItem>();

        if (mediaItem != null && cart != null)
        {
            cart.AddToCart(mediaItem);
            mediaItem.gameObject.SetActive(false);
        }
    }

    public void SaveOriginalTransform()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        Debug.Log($"Saved original position {originalPosition} and rotation {originalRotation} for {itemName}");
    }

    public void RestoreOriginalTransform()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        Debug.Log($"Restored original position {originalPosition} and rotation {originalRotation} for {itemName}");
    }
}