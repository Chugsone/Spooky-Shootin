using UnityEngine;


public class Buying : MonoBehaviour
{
    [Header("CurrentLvl")]
    public int HealthLvl = 1;
    public int SpeedLvl = 1;

    public int MeleeDmgLvl = 1;
    public int RangeDmgLvl = 1;

    public int MeleeRangeLvl = 1;
    public int RangeRangeLvl = 1;

    [Header("MaxLvl")]
    // max lvl
    public int MaxHealthLvl = 6;
    public int MaxSpeedLvl = 6;

    public int MaxMeleeDmgLvl = 6;
    public int MaxRangeDmgLvl = 6;

    public int MaxMeleeRangeLvl = 4;
    public int MaxRangeRangeLvl = 4;

    [Header("Lvl price")]

    public int HealthLvlPrice = 1;
    public int SpeedLvlPrice = 1;

    public int MeleeDmgLvlPrice = 1;
    public int RangeDmgLvlPrice = 1;

    public int MeleeRangeLvlPrice = 1;
    public int RangeRangeLvlPrice = 1;

    public CandycornManager cm;

    private void Update()
    {
        HealthLvl = Mathf.Clamp(HealthLvl, 1, MaxHealthLvl);
        SpeedLvl = Mathf.Clamp(SpeedLvl, 1, MaxSpeedLvl);

        MeleeDmgLvl = Mathf.Clamp(MeleeDmgLvl, 1, MaxMeleeDmgLvl);
        RangeDmgLvl = Mathf.Clamp(RangeDmgLvl, 1, MaxRangeDmgLvl);

        MeleeRangeLvl = Mathf.Clamp(MeleeRangeLvl, 1, MaxMeleeRangeLvl);
        RangeRangeLvl = Mathf.Clamp(RangeRangeLvl, 1, MaxRangeRangeLvl);
    }

    
    // Body levelUp buttons
    public void HealthUpgradeButton()
    {
        if (HealthLvl < MaxHealthLvl && cm.candyCount >= HealthLvlPrice)
        {
            cm.candyCount -= HealthLvlPrice;
            HealthLvl += 1;
            Debug.Log(HealthLvl);
        }
    }

    public void SpeedUpgradeButton()
    {
        if (SpeedLvl < MaxSpeedLvl && cm.candyCount >= SpeedLvlPrice)
        {
            cm.candyCount -= SpeedLvlPrice;
            SpeedLvl += 1;
            Debug.Log(SpeedLvl);
        }
    }


    // damage levelUp buttons
    public void MeleeDmgUpgradeButton()
    {
        if (MeleeDmgLvl < MaxMeleeDmgLvl && cm.candyCount >= MeleeDmgLvlPrice)
        {
            cm.candyCount -= MeleeDmgLvlPrice;
            MeleeDmgLvl += 1;
            Debug.Log(MeleeDmgLvl);
        }
    }

    public void RangeDmgUpgradeButton()
    {
        if (RangeDmgLvl < MaxRangeDmgLvl && cm.candyCount >= RangeDmgLvlPrice)
        {
            cm.candyCount -= RangeDmgLvlPrice;
            RangeDmgLvl += 1;
            Debug.Log(RangeDmgLvl);
        }
    }


    // range levelUp buttons
    public void MeleeRangeUpgradeButton()
    {
        if (MeleeRangeLvl < MaxMeleeRangeLvl && cm.candyCount >= MeleeRangeLvlPrice)
        {
            cm.candyCount -= MeleeRangeLvlPrice;
            MeleeRangeLvl += 1;
            Debug.Log(MeleeRangeLvl);
        }
    }

    public void RangeRangeUpgradeButton()
    {
        if (RangeRangeLvl < MaxRangeRangeLvl && cm.candyCount >= RangeRangeLvlPrice)
        {
            cm.candyCount -= RangeRangeLvlPrice;
            RangeRangeLvl += 1;
            Debug.Log(RangeRangeLvl);
        }
    }
}
