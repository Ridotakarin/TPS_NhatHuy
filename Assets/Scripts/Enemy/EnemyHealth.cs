using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider followHealth;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    

    private float lerpSpeed = 0.05f;
    void Start()
    {
        
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthSlider.value != currentHealth)
        {
            healthSlider.value = currentHealth;
        }
        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            TakeDamage(10f);
        }
        if (healthSlider.value != followHealth.value)
        {
            followHealth.value = Mathf.Lerp(followHealth.value,currentHealth,lerpSpeed);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;    
    }
}
