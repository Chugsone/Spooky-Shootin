using UnityEngine;

public class ShopTesting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject[] ShopObjects;


    private void Shop()
    {



        foreach (GameObject ShopObject in ShopObjects)
        {
            ShopObject.SetActive(false);
        }
    }

    private void Start()
    {
        Shop();
    }
}
