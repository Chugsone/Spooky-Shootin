using UnityEngine;

public class SetActive : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject[] GroupedObjects; // what objects are set active or not
    [SerializeField] private bool ActiveState;// testing variable (Aka temporary)


    private void ActiveStatus()
    {

        if (ActiveState == true)
        {
            foreach (GameObject GroupedObject in GroupedObjects)
            {
                GroupedObject.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject GroupedObject in GroupedObjects)
            {
                GroupedObject.SetActive(false);
            }
        }
    }

    private void Start()
    {

    }

    public void Update()
    {
        ActiveStatus();
    }
}