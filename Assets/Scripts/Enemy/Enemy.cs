using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    
    public float maxHealth;
    public float currentHealth;


    public abstract void TakeDamage(float amount);
    public virtual void UpdateHealth()
    {
        
    }
}
