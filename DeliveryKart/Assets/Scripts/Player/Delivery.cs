using UnityEngine;

public class Delivery : MonoBehaviour
{
    [Header("Color Settings")]
    [SerializeField] Color32 hasPackage = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackage = new Color32(1, 1, 1, 1);

    [Header("References")]
    [SerializeField] bool hasDeliveryPackage;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private float destroyDelay = 0.5f;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Delivery" && !hasDeliveryPackage)
        {
            hasDeliveryPackage = true;
            spriteRenderer.color = hasPackage;
            Destroy(collision.gameObject, destroyDelay);
        }

        if(collision.gameObject.tag == "Customer" && hasDeliveryPackage)
        {
            hasDeliveryPackage = false;
            spriteRenderer.color = noPackage;
        }
    }
}