using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private Health health;
    private int damage;


    private void Start()
    {
        health = GetComponent<Health>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mob") == true)
        {
            damage = 5;
            health.TakeDamage(damage);
        }
        else if (collision.gameObject.CompareTag("Boss") == true)
        {
            damage = 10;
            health.TakeDamage(damage);
            
        }
    }
}
