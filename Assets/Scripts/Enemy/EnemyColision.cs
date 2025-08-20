using UnityEngine;

public class EnemyColision : MonoBehaviour
{
    [SerializeField] private Mutant _mutant;
    [SerializeField] private Mob _mob;

    void Start()
    {
        _mutant = GetComponent<Mutant>();
        _mob = GetComponent<Mob>();
        if(_mutant!= null)
        {
            _mutant.UpdateHealth();
        }
        if(_mob != null)
        {
            _mob.UpdateHealth();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Grenade") && _mutant != null)
        {
            _mutant.TakeDamage(100f);
            Debug.Log("100 HP");
        }
        if (other.CompareTag("Grenade") && _mob != null)
        {
            _mob.TakeDamage(100f);
            Debug.Log("100 HP");
        }

    }
}
