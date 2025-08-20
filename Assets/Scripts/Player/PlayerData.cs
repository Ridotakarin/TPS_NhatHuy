using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerData: MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    
    public bool hasKey = false;

    public UnityEvent OnDead;
    public int MaxHealth => _maxHealth;
    public int CurrentHealth;
    
    private int _currentHealth;

    private void Start()  
    {
        HealRecover();
        
    }

    public bool IsDead => _currentHealth <= 0;

    public void TakeDamage(int damage)
    {
        if (IsDead) { return; }

        _currentHealth -= damage;
        
        HealthCheck();
        Debug.Log($"{ _currentHealth}");
        if (IsDead)
        {
            AudioManager.Instance.IsDead();
            Die();
        }
    }
    public void ObtainKey() => hasKey = true;
    public void HealthCheck() => CurrentHealth = _currentHealth;
    private void Die() => OnDead.Invoke();
    public void HealRecover()
    {
        _currentHealth = _maxHealth;
        HealthCheck();
    }
    
}