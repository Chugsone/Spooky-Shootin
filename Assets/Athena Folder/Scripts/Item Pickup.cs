using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public CandycornManager cm;
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
            Destroy(other.gameObject);
            cm.candyCount++;
        }
    }
}
