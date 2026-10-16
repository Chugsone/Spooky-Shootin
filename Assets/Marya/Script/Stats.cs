using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Lone Stats")] 
    [Range(1,6)]public int healthLvl;
    [Range(1,6)] public int speedLvl;


    [Header("Damage")]
    [Range(1,6)] public int meleeDmgLvl;
    [Range(1,6)] public int rangeDmgLvl;
    // might add life steal and aoe if those get added into game 

    [Header("Range")] // calculations could be x^(smaller/larger)
    [Range(1,4)] public int meleeRangeLvl;
    [Range(1,4)] public int rangeRangeLvl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
