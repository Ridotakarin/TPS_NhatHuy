using UnityEngine;
using UnityEngine.UI;
public class Mutant : Enemy
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider followHealth;


    private float lerpSpeed = 0.01f;

    void Start()
    {
        maxHealth = 1500;
        currentHealth = maxHealth;
        

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }
    public override void UpdateHealth()
    {
        if (healthSlider.value != currentHealth)
        {
            healthSlider.value = currentHealth;
        }
        
        if (healthSlider.value != followHealth.value)
        {
            followHealth.value = Mathf.Lerp(followHealth.value, currentHealth, lerpSpeed);
        }
    }
    public override void TakeDamage(float amount)
    {
        currentHealth -= amount;
        UpdateHealth();
    }
    
}
