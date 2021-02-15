using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public GameObject healthBarGO;
    public Slider healthbarSlider;
    public Color maxHealthColour;
    public Color minHealthColour;
    public Image healthFillImage;

    public bool isAlienBuddy;
    public bool isPlayer;
    public GameObject player;

    [Header("Alien Buddy Settings")]
    public float deathCounter = 15f;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbarSlider.maxValue = maxHealth;
        if (isAlienBuddy)
        {
            healthbarSlider.maxValue = deathCounter;
        }

        player = GameObject.FindGameObjectWithTag("Player");
        SetHealthBarSlider();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlienBuddy)
        {
            LookAtPlayer();
            SetHealthBarSlider();
            ReduceHealthGradually();
        }
        
    }

    void ReduceHealthGradually()
    {
        deathCounter -= Time.deltaTime;
        

        if (deathCounter<=0)
        {
            deathCounter = 0;
            Destroy(gameObject);
        }
        healthbarSlider.value = deathCounter;
        healthFillImage.color = Color.Lerp(minHealthColour, maxHealthColour, healthbarSlider.value / healthbarSlider.maxValue);
    }

    void LookAtPlayer()
    {
        healthBarGO.transform.LookAt(player.transform);
    }
    public void ChangeHealth(float change)
    {
        currentHealth += change;
        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        SetHealthBarSlider();
    }

    void SetHealthBarSlider()
    {
        healthbarSlider.value = currentHealth;
        healthFillImage.color = Color.Lerp(minHealthColour, maxHealthColour, currentHealth / maxHealth);
    }
}




