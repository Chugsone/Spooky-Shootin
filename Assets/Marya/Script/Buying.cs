using UnityEngine;


public class Buying : MonoBehaviour
{
    [Header(CurrentLvl)]
    public int HealthLvl = 1;
    public int SpeedLvl = 1;

    public int MeleeDmgLvl = 1;
    public int RangeDmgLvl = 1;

    public int MeleeRangeLvl = 1;
    public int RangeRangeLvl = 1;

    [Header(MaxLvl)]
    // max lvl
    public int MaxHealthLvl = 6;
    public int MaxSpeedLvl = 6;

    public int MaxMeleeDmgLvl = 6;
    public int MaxRangeDmgLvl = 6;

    public int MaxMeleeRangeLvl = 4;
    public int MaxRangeRangeLvl = 4;

    // Body levelUp buttons
    public void HealthUpgradeButton()
    {
        if (HealthLvl < MaxHealthLvl)
        {
            HealthLvl += 1;
            Debug.Log(HealthLvl);
        }
    }

    public void SpeedUpgradeButton()
    {

    }


    // damage levelUp buttons
    public void MeleeDmgUpgradeButton()
    {

    }

    public void RangeDmgUpgradeButton()
    {

    }


    // range levelUp buttons
    public void MeleeRangeUpgradeButton()
    {

    }

    public void RangeRangeUpgradeButton()
    {

    }
}
