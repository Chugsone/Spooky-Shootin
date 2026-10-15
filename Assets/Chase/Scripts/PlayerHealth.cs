using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private LayerMask targetLayers;
    public Slider healthBarSlider;
    public TextMeshProUGUI healthBarValueText;

    public int maxHealth;
    public int currHealth;

    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        healthBarValueText.text = currHealth.ToString() + "/" + maxHealth.ToString();

        healthBarSlider.value = currHealth;
        healthBarSlider.maxValue = maxHealth;

        
    }

    private void TakeDamage(int damage)
    {
        currHealth -= damage;

        StartCoroutine(FlashRed());

        if (currHealth <= 0)
        {
            SceneManager.LoadScene("Loser");
        }
    }
    private void UpdateHealthUI()
    {
        if (healthBarValueText != null)
        {
            healthBarValueText.text = currHealth.ToString() + "/" + maxHealth.ToString();
        }
        if (healthBarSlider != null)
        {
            healthBarSlider.maxValue = maxHealth;
            healthBarSlider.value = currHealth;
        }
    }
    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
    private bool IsInLayerMask(GameObject obj, LayerMask mask)
    {
        return (mask.value & (1 << obj.layer)) != 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsInLayerMask(collision.gameObject, targetLayers))
        {
            TakeDamage(1);
        }
    }
}
