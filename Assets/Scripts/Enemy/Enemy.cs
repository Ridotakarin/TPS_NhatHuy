using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float damage;

    public abstract void TakeDamage(float amount);
    public virtual void DisplayHealth()
    {

    }
}
