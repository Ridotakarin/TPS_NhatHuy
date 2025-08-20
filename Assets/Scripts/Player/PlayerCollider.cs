using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private InputActionReference _interact;

    private PlayerData playerData;
    private int damage;


    private void Start()
    {
        playerData = GetComponent<PlayerData>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mob") == true)
        {
            damage = 5;
            playerData.TakeDamage(damage);
            AudioManager.Instance.GetHurt();

        }
        else if (collision.gameObject.CompareTag("Boss") == true)
        {
            damage = 10;
            playerData.TakeDamage(damage);
            AudioManager.Instance.GetHurt();

        }
        
    }
    
}
