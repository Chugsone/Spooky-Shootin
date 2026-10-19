using UnityEngine;

public class ShopTesting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject[] ShopObjects; // what objects are set active or not
    [SerializeField] private bool ShopActive;// testing variable (Aka temporary)


    private void Shop()
    {

        if (ShopActive == true)
        {
            foreach (GameObject ShopObject in ShopObjects)
            {
                ShopObject.SetActive(true);
            } 
        }
        else
        {
            foreach (GameObject ShopObject in ShopObjects)
            {
                ShopObject.SetActive(false);
            }
        } 
    }

    private void Start()
    {
    
    }

    public void Update()
    {
        Shop();
    }
}
