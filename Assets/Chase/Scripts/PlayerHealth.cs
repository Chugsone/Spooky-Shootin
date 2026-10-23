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

    public int maxHealth = 100; 
    public int currHealth;

    [Header("Background Swapping")]
    public Image backgroundImage;
    public Sprite bgNormal;      
    public Sprite bgAt50;
    public Sprite bgAt25;

    private SpriteRenderer spriteRenderer;
    private Coroutine flashCoroutine;

    void Start()
    {
        currHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

        UpdateHealthUI();
        CheckBackgroundSwap();
    }

    private void TakeDamage(int damage)
    {
        currHealth -= damage;
        currHealth = Mathf.Max(0, currHealth);

        UpdateHealthUI();     
        CheckBackgroundSwap(); 

        if (flashCoroutine != null) StopCoroutine(flashCoroutine);
        flashCoroutine = StartCoroutine(FlashRed());

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

    private void CheckBackgroundSwap()
    {
        if (backgroundImage == null) return;

        float healthPercentage = (float)currHealth / maxHealth;

        if (healthPercentage <= 0.25f && bgAt25 != null)
        {
            backgroundImage.sprite = bgAt25;
        }
        else if (healthPercentage <= 0.50f && bgAt50 != null)
        {
            backgroundImage.sprite = bgAt50;
        }
        else if (bgNormal != null)
        {
            backgroundImage.sprite = bgNormal;
        }
    }

    private IEnumerator FlashRed()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = Color.white;
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsInLayerMask(collision.gameObject, targetLayers))
        {
            TakeDamage(1);
        }
    }
}
