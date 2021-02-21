using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public float rateOfHealthDepletion = 0.5f;

    public Slider healthbarSlider;
    public Color maxHealthColour;
    public Color minHealthColour;
    public Image healthFillImage;

    public bool isPlayer;

    
    void Start()
    {
        currentHealth = maxHealth;
        if (isPlayer)
        {
            healthbarSlider.maxValue = maxHealth;
            SetHealthBarSlider();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            ReduceHealthGradually();
            SetHealthBarSlider();
        }
        
    }

    void ReduceHealthGradually()
    {
        currentHealth -= Time.deltaTime * rateOfHealthDepletion;
        CheckIfGameOver();
    }

    public void ChangeHealth(float change)
    {
        currentHealth += change;
        CheckIfGameOver();
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (isPlayer)
        {
            SetHealthBarSlider();
        }
    }

    void CheckIfGameOver()
    {
        if (currentHealth <= 0)
        {
            if (!isPlayer)
            {
                Dead(this.gameObject);
            }
            else
            {
                Debug.Log("Game Over");
                SceneManager.LoadScene("GameOver Scene");
            }
            
        }
    }
    void SetHealthBarSlider()
    {
        healthbarSlider.value = currentHealth;
        healthFillImage.color = Color.Lerp(minHealthColour, maxHealthColour, currentHealth / maxHealth);
    }

    void Dead(GameObject obj)
    {
        EnemyWaveHandler enemyInWave = GetComponent<EnemyWaveHandler>(); 
        if (enemyInWave) enemyInWave.Dead();
        Destroy(gameObject);
    }
}




