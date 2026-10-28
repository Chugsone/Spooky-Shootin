using UnityEngine;
using TMPro;

public class candycorn_amount_text : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Candycorn_amount;
    public CandycornManager cm;

    // Update is called once per frame
    void Update()
    {
        Candycorn_amount.text = cm.candyCount.ToString();
    }
}
