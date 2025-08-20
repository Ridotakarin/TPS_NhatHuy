using UnityEngine;
using UnityEngine.UI;
public class Mutant : Enemy
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider followHealth;
    [SerializeField] private Animator animator;
    [SerializeField] private UI_PlayerHealth gamePanel;


    private float lerpSpeed = 0.01f;

    void Start()
    {
        maxHealth = 1500;
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        if(gamePanel == null )
        {
            gamePanel = GameObject.Find("UIManager").GetComponent<UI_PlayerHealth>();
        }
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
        if(currentHealth <=0)
        {
            animator.Play("IsDead");
            gamePanel.GameOverPanel();
        }

    }
    
}
