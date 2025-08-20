using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Mob : Enemy
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider followHealth;
    [SerializeField] private Animator _animator;
    private float lerpSpeed = 0.01f;

    

    void Start()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }
    public override void TakeDamage(float amount)
    {
        currentHealth -= amount;
        UpdateHealth();
        if(currentHealth <= 0)
        {
            AudioManager.Instance.ZomDead();
            DeadState();
                
            Destroy(gameObject,5f);
        }
    }
    public override void UpdateHealth()
    {
        if(healthSlider.value != currentHealth)
        {
            healthSlider.value = currentHealth;
        }
        if (followHealth.value != healthSlider.value)
        {
            followHealth.value = Mathf.Lerp(followHealth.value, healthSlider.value, lerpSpeed);
        }
    }
    public void DeadState()
    {
        
        int state = Random.Range(1, 10);
        Debug.Log(state);
        if(state <= 5)
        {
            _animator.Play("Z_FallingBack");
        }
        else
        {
            _animator.Play("Z_FallingForward");
        }
        
    }
}
