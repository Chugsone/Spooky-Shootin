using UnityEngine;

public class SetActive : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject[] GroupedObjects; // what objects are set active or not
    public bool ActiveState;// testing variable (Aka temporary)

    public WaveSpawner WavSpwn; //wave spawner script
    public PlayerHealth PlyrHlth; //Player Health script


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

    public void DeActivate()
    {
        ActiveState = false;
        WavSpwn.SpawnWave();
        PlyrHlth.ResetHealth();
    }

    public void Activate()
    {
        ActiveState = true;
    }
}