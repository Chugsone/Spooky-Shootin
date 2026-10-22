using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public CandycornManager cm;
    [SerializeField] private AudioClip itemPickupSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Candycorn"))
        {
            AudioSource.PlayClipAtPoint(itemPickupSound, transform.position, 1f);
            Destroy(other.gameObject);
            cm.candyCount++;
        }
    }
}
