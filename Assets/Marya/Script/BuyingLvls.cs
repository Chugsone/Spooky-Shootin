using UnityEngine;
using TMPro;

public class BuyingLvls : MonoBehaviour
{
    [Header("CurrentLvl")]
    public int HealthLvl = 1;
    public int SpeedLvl = 1;

    public int PistolDmgLvl = 1;
    public int ShotgunDmgLvl = 1;

    public int PistolRangeLvl = 1;
    public int ShotgunRangeLvl = 1;

    [Header("MaxLvl")]
    // max lvl
    public int MaxHealthLvl = 6;
    public int MaxSpeedLvl = 6;

    public int MaxPistolDmgLvl = 6;
    public int MaxShotgunDmgLvl = 6;

    public int MaxPistolRangeLvl = 4;
    public int MaxShotgunRangeLvl = 4;

    [Header("Lvl price")]

    public int HealthLvlPrice = 1;
    public int SpeedLvlPrice = 1;

    public int PistolDmgLvlPrice = 1;
    public int ShotgunDmgLvlPrice = 1;

    public int PistolRangeLvlPrice = 1;
    public int ShotgunRangeLvlPrice = 1;

    public CandycornManager cm;

    [Header("Lvl input for text")]


    [SerializeField] private TextMeshProUGUI InputHealthLvl;
    [SerializeField] private TextMeshProUGUI InputSpeedLvl;

    [SerializeField] private TextMeshProUGUI InputPistolMeleeLvl;
    [SerializeField] private TextMeshProUGUI InputShotgunMeleeLvl;

    [SerializeField] private TextMeshProUGUI InputPistolRangeLvl;
    [SerializeField] private TextMeshProUGUI InputShotgunRangeLvl;


    [Header("Price input for text")]


    [SerializeField] private TextMeshProUGUI InputHealthPrice;
    [SerializeField] private TextMeshProUGUI InputSpeedPrice;

    [SerializeField] private TextMeshProUGUI InputPistolMeleePrice;
    [SerializeField] private TextMeshProUGUI InputShotgunMeleePrice;

    [SerializeField] private TextMeshProUGUI InputPistolRangePrice;
    [SerializeField] private TextMeshProUGUI InputShotgunRangePrice;

    private void Update()
    {
        // keeps lvls within a certain range
        HealthLvl = Mathf.Clamp(HealthLvl, 1, MaxHealthLvl);
        SpeedLvl = Mathf.Clamp(SpeedLvl, 1, MaxSpeedLvl);

        PistolDmgLvl = Mathf.Clamp(PistolDmgLvl, 1, MaxPistolDmgLvl);
        ShotgunDmgLvl = Mathf.Clamp(ShotgunDmgLvl, 1, MaxShotgunDmgLvl);

        PistolRangeLvl = Mathf.Clamp(PistolRangeLvl, 1, MaxPistolRangeLvl);
        ShotgunRangeLvl = Mathf.Clamp(ShotgunRangeLvl, 1, MaxShotgunRangeLvl);


        // input lvl text
        InputHealthLvl.text = (HealthLvl-1).ToString() + "/" + (MaxHealthLvl - 1);
        InputSpeedLvl.text = (SpeedLvl-1).ToString() + "/" + (MaxSpeedLvl - 1);

        InputPistolMeleeLvl.text = (PistolDmgLvl - 1).ToString() + "/" + (MaxPistolDmgLvl - 1);
        InputShotgunMeleeLvl.text = (ShotgunDmgLvl - 1).ToString() + "/" + (MaxShotgunDmgLvl - 1);

        InputPistolRangeLvl.text = (PistolRangeLvl - 1).ToString() + "/" + (MaxPistolRangeLvl - 1);
        InputShotgunRangeLvl.text = (ShotgunRangeLvl - 1).ToString() + "/" + (MaxShotgunRangeLvl - 1);

        // input Price text

        InputHealthPrice.text = HealthLvl.ToString();
        InputSpeedPrice.text = SpeedLvl.ToString();

        InputPistolMeleePrice.text = PistolDmgLvl.ToString();
        InputShotgunMeleePrice.text = ShotgunDmgLvl.ToString();

        InputPistolRangePrice.text = PistolRangeLvl.ToString();
        InputShotgunRangePrice.text = ShotgunRangeLvl.ToString();


        // update prices
        HealthLvlPrice = HealthLvl;
        SpeedLvlPrice = SpeedLvl;

        PistolDmgLvlPrice = PistolDmgLvl;
        ShotgunDmgLvlPrice = ShotgunDmgLvl;

        PistolRangeLvlPrice = PistolRangeLvl;
        ShotgunRangeLvlPrice = ShotgunRangeLvl;
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
        if (PistolDmgLvl < MaxPistolDmgLvl && cm.candyCount >= PistolDmgLvlPrice)
        {
            cm.candyCount -= PistolDmgLvlPrice;
            PistolDmgLvl += 1;
            Debug.Log(PistolDmgLvl);
        }
    }

    public void RangeDmgUpgradeButton()
    {
        if (ShotgunDmgLvl < MaxShotgunDmgLvl && cm.candyCount >= ShotgunDmgLvlPrice)
        {
            cm.candyCount -= ShotgunDmgLvlPrice;
            ShotgunDmgLvl += 1;
            Debug.Log(ShotgunDmgLvl);
        }
    }


    // range levelUp buttons
    public void MeleeRangeUpgradeButton()
    {
        if (PistolRangeLvl < MaxPistolRangeLvl && cm.candyCount >= PistolRangeLvlPrice)
        {
            cm.candyCount -= PistolRangeLvlPrice;
            PistolRangeLvl += 1;
            Debug.Log(PistolRangeLvl);
        }
    }

    public void RangeRangeUpgradeButton()
    {
        if (ShotgunRangeLvl < MaxShotgunRangeLvl && cm.candyCount >= ShotgunRangeLvlPrice)
        {
            cm.candyCount -= ShotgunRangeLvlPrice;
            ShotgunRangeLvl += 1;
            Debug.Log(ShotgunRangeLvl);
        }
    }
}
