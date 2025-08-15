using UnityEngine;
using UnityEngine.Events;

public class Health: MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public UnityEvent OnDead;
    public int MaxHealth => _maxHealth;
    public int CurrentHealth;
    
    private int _currentHealth;

    private void Start()  
    {
        _currentHealth = _maxHealth;
        HealthCheck();
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
            Die();
        }
    }

    public void HealthCheck() => CurrentHealth = _currentHealth;
    private void Die() => OnDead.Invoke();
}